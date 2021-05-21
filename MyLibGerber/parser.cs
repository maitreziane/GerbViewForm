using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MyLibGerber
{

    public class Parser
    {

        

        float x, y;
        private Quadrant quad_mode;
        private Interpolation inter_mode;
        private Region region=Region.NONE;
        private Aperture aperture_get=null;
        private Regex ad_reg=new Regex(@"%ADD(\d\d+)([a-zA-Z_$\.][a-zA-Z0-9_$\.\-]*)(?:,(.*))?\*%$");
        private Regex am1_reg=new Regex(@"%AM([^\*]+)\*([^%]+)?(%)?$");
        private Regex line_reg=new Regex(@"(?:G0?(1))?(?=.*X([\+-]?\d+))?(?=.*Y([\+-]?\d+))?[XY][^DIJ]*(?:D0?([123]))?\*$");
        private Regex circ_reg= new Regex (@"(?:G0?([23]))?(?=.*X([\+-]?\d+))?(?=.*Y([\+-]?\d+))?(?=.*I([\+-]?\d+))?(?=.*J([\+-]?\d+))?[XYIJ][^D]*(?:D0([12]))?\*$");
        private Regex opcode_reg=new Regex(@"D0?([123])\*$");
        private Regex inter_reg=new Regex(@"(?:G0?([123]))\*");
        private Regex am2_reg=new Regex(@"(.*)%$");
        private Regex mode_reg=new Regex(@"%?MO(IN|MM)\*%?$"); // IN or MM
        private Regex quad_reg=new Regex(@"G7([45]).*\*$");
        private Regex dcode_reg=new Regex(@"(?:G54)?D(\d\d+)\*$");
        private Regex regionStart_reg=new Regex(@"G36\*$");
        private Regex regionEnd_reg=new Regex(@"G37\*$");
        private Regex fmt_re=new Regex(@"%?FS([LTD])?([AI])X(\d)(\d)Y\d\d\*%?$");
        private Regex fmt_re_alt=new Regex(@"%FS([LTD])?([AI])X(\d)(\d)Y\d\d\*MO(IN|MM)\*%$");
        private Regex lpol_re = new Regex(@"%LP([DC])\*%$"); // la polarité

        private IDictionary<string, Macro_Data> AMHash =new Dictionary<string, Macro_Data>();
        private IDictionary<int, Aperture> ADHash =new Dictionary<int, Aperture>();
        private List<Point> pointRegion;
        private List<GerberPrimitive> RenderObjects=new List<GerberPrimitive>();

        private string polarity;
        private Macro_Data aperture_macro;
        private GerberPrimitive gerberPrimitive ;
        private Match match;
        private string current_macro="none";
        private string pathFileName { get; }
        private int int_digits = 3;
        private int frac_digits = 4;
        private string gerber_zeros;
        private float current_x, current_y, linear_x, linear_y;
        int current_oper_code;


        // end variables




        public Parser(string pathFileName)
        {
            this.pathFileName=pathFileName;


            foreach (var line in File.ReadLines(pathFileName))
            {
               ParserLine(line.Trim());
            } 
            
        }

        public List<GerberPrimitive> getADHasTable(){return RenderObjects;}

        protected void ParserLine(string line)
        {

            // ################################################################
            // ##############  Example: %LPD*% or %LPC*%                 ######
            // ################################################################
            match = lpol_re.Match(line);
            if (match.Success)
                if (match.Groups[1].Equals("C"))
                    polarity = "C";
                if (match.Groups[1].Equals("D"))
                    polarity = "D";

            // ################################################################
            // ##############  get format coordinnate to work in gerber  ######
            // ################################################################
            match = fmt_re.Match(line);

            if(match.Success){
                int_digits = int.Parse(match.Groups[3].Value);
                frac_digits = int.Parse(match.Groups[4].Value);
                gerber_zeros=match.Groups[1].Value;

            }

            
            // ################################################################
            // ##############  get any coordinnates                      ######
            // ################################################################
            match=line_reg.Match(line);
            if(match.Success && aperture_get !=null){

                    // parse coordinnates
                    if (match.Groups[2].Success){
                        linear_x=parser_gerber_number(match.Groups[2].Value, int_digits, frac_digits, gerber_zeros);
                        current_x=linear_x;
                        
                    }else{
                        linear_x=current_x;
                    }
                    if (match.Groups[3].Success){
                        linear_y=parser_gerber_number(match.Groups[3].Value, int_digits, frac_digits, gerber_zeros);
                        current_y=linear_y;
                        
                    }else{linear_y=current_y;}

            // here we get operation code (D01,D02, D03)
            
            if (match.Groups[4].Success)
                current_oper_code=int.Parse(match.Groups[4].Value);        


            // get point to move for line
            if (current_oper_code==2){x=current_x; y=current_y;}
                        

            } // end to get coordinate

        // ################################################################
        // ##############   Get circular Arc   Multi or Single  ###########         
        // ################################################################

        //match=circ_reg.Match(line);
        //if(match.Success  )
           // if(match.Groups[1].Success)
                   // continue;
                   // Console.Write("{0}\n", line);

             
        // ################################################################
        // ##############        get dataPoints of rigion        ##########
        // ################################################################

            if (region.Equals(Region.START) && inter_mode.Equals(Interpolation.LINEAR))
                //if(inter_mode.Equals(Interpolation.CIRCULAR) )
                    //Console.Write("{0}\n", line);
                //if(inter_mode.Equals(Interpolation.LINEAR) )  
                pointRegion.Add(new Point(current_x, current_y));
            

        // ################################################################
        // ##############        flash region               ...  ##########
        // ################################################################
            if (region.Equals(Region.END ) && aperture_get != null){
                gerberPrimitive=new Flash_Region(pointRegion, aperture_get);
                RenderObjects.Add(gerberPrimitive);
                // il y a encore du travail
            }
                            
        // ################################################################
        // ##############       make to flash line          ...  ##########
        // ################################################################
            
            if (region is Region.END || region is  Region.NONE){
                if(inter_mode.Equals(Interpolation.LINEAR)  && current_oper_code==1 ){
                    if(aperture_get != null) { 
                        gerberPrimitive= new LineShape(new Point(current_x, current_y), new Point(x,y), aperture_get);
                            
                        RenderObjects.Add(gerberPrimitive);
                        x=current_x;
                        y=current_y;
                    }
                }
 
        // ################################################################
        // ##############    flash aperture  Rect,cirle, Obround, macro ###
        // ################################################################
                    
            if (current_oper_code==3){
                if (aperture_get!=null){
                    gerberPrimitive =new Flash(new Point(current_x, current_y), aperture_get);
                            //Console.Write(" {0}\n",gerberPrimitive);
                    RenderObjects.Add(gerberPrimitive);
                }
            }

            }

            
        // ################################################################
        // ##############       get region start            ...  ##########
        // ################################################################
            match=regionStart_reg.Match(line);
            if (match.Success){
                
                pointRegion=new List<Point>();
                region=Region.START;
            }
                

        // ################################################################
        // ##############       get region end              ...  ##########
        // ################################################################
            match=regionEnd_reg.Match(line);
            if (match.Success)
                region=Region.END;
           
            

        // ################################################################
        // ##############   Parser Aperture definitions %ADD...  ##########
        // ################################################################

            match=ad_reg.Match(line);
            if (match.Success)
                    Aperture_Define_parser(int.Parse(match.Groups[1].Value), match.Groups[2].Value,  match.Groups[3].Value.Replace(".", ","));
            

        // ################################################################
        // ##############   Aperture Macros %AM...  #######################
        // ################################################################


            if (current_macro.Equals("none")){

            match=am1_reg.Match(line);
            if (match.Success)
             {
                 current_macro=match.Groups[1].Value; // name de la macro
                 aperture_macro= new  Macro_Data(current_macro);
                 AMHash.Add(current_macro, aperture_macro);

                 if (match.Groups[2].Success)
                       aperture_macro.append(match.Groups[2].Value);

                 if(match.Groups[3].Success) // ici sera valable ssi la macro continue
                    current_macro="none";   
            }
            }else{
            // ici on scan tous les paramettres de la macro
            match=am2_reg.Match(line);

                if (match.Success){
                    aperture_macro.append(match.Groups[1].Value);
                    current_macro="none";
                }else{
                    aperture_macro.append(line);
                }
            
            } 


        // interpolation mode (circular G01 , clockwise G02 or counterclockwise G03)
        // #####################################################################################
        // ##############  (circular G01 , clockwise G02 or counterclockwise G03)     ##########
        // #####################################################################################
        match=inter_reg.Match(line);
        if (match.Success)
            if (match.Groups[1].Equals("1"))
                inter_mode=Interpolation.LINEAR;
            if (match.Groups[1].Equals("2"))
                inter_mode=Interpolation.CLOCKWISE;
            if (match.Groups[1].Equals("3"))
                inter_mode=Interpolation.COUNTERCLOCKWISE;        
                    
        
        // ################################################################
        // #######  get quadrant mode single or multi  G74 or G74  ########
        // ################################################################
        match=quad_reg.Match(line);
        if(match.Success)
            if(match.Groups[1].Equals("4") || match.Groups[1].Equals("5"))
               inter_mode=Interpolation.CIRCULAR; 
            if (match.Groups[1].Equals("4"))
                quad_mode=Quadrant.SINGLE;
            if (match.Groups[1].Equals("5"))
                quad_mode=Quadrant.MULTI;    


        
        
        // ################################################################
        // ##############   get what dcode to use  D10* or D...  ##########
        // ################################################################
        match=dcode_reg.Match(line);
        if (match.Success && int.Parse(match.Groups[1].Value)>= 10  )
            ADHash.TryGetValue(int.Parse(match.Groups[1].Value), out aperture_get);
           

           

          // fin methode parserLine  

        }

        
        // method to get all aperture define in gerber file and set in hashtable (dict)
        // ################################################################
        // ##############    Aperture definitions %ADD...  ################
        // ################################################################
        private int Aperture_Define_parser(int dcode, string typeAperture, string modifiers)

        {
            /**
                - dcode exemple 12
                - typeAperture (R,O,P,C, Macor)
                - modifiers parameters of aperture 
            */

            
            if (typeAperture.Equals("C")){
                ADHash.Add(dcode, new Circle(Convert.ToSingle(modifiers))); 
                return 0;
            }


            if (typeAperture.Equals("R")){
              string[] parm=modifiers.Split('X');
              ADHash.Add(dcode, new Rectangle(Convert.ToSingle(parm[0]),Convert.ToSingle(parm[1]) ));
              return 0;
            }

            if (typeAperture.Equals("O")){
                string[] parm=modifiers.Split('X');
                ADHash.Add(dcode, new Obround(Convert.ToSingle(parm[0]),Convert.ToSingle(parm[1]) ));
                return 0;

            }

            if (typeAperture.Equals("P"))
            {
                string[] parm = modifiers.Split('X');
                ADHash.Add(dcode, new Polygon(Convert.ToSingle(parm[0]), int.Parse(parm[1])));
                return 0;

            }

            // ################################################################
            // ##############  Extrat data of macro contain in hashtable...  ##
            // ################################################################
            Macro_Data data;
            if(AMHash.ContainsKey(typeAperture)){
                AMHash.TryGetValue(typeAperture, out data);
                ADHash.Add(dcode, new ApertureMacro(data.getData()).GetMacro());   
            }

            /// pas encore fini 

          return 0;

    
        }

        


        // ################################################################
        // ##############  convesion d'un string en floatant...  ##########
        // ################################################################
        private float parser_gerber_number(string strNumber, int int_digits, int frac_digits, string zero)
        {   
            
            if (zero.Equals("L") | zero.Equals("D"))
                return (float)(int.Parse(strNumber)*Math.Pow(10, Convert.ToDouble(-frac_digits)));

            if (zero.Equals("T"))
                return (float)(int.Parse(strNumber)* Math.Pow(10, ((int_digits + frac_digits)-strNumber.Length)) );

        return 0;
        }

    }
}