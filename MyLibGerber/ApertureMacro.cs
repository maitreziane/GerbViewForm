
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyLibGerber{

    public class ApertureMacro : Aperture
    {
        Aperture macro=null;

        private Regex outline= new Regex(@"4,(1|0),(?<count>\\d*),(?<vertices>.*,)(?<angle>-?\\d*.?\\d*)");
        //private Match match;
        int countchar=0;
        List<string> data_Macro=new List<string>();
        public ApertureMacro(List<string> data_Macro){this.data_Macro=data_Macro;}

        private Aperture ParseMacro(){

            

            if (data_Macro[0].StartsWith("4")){ // macro outline

                int i=0;
                string str="";
                // on test en comptant le nombre de virgule
                if(count( ',',data_Macro[1])>2){

                    MacroOutline macroOutline=new MacroOutline();
                    
                    // il faut ajouter l'angle de rotation de la macro
                        
                      //Console.Write(data_Macro[data_Macro.Count-1].Remove(1));
                        for (int k = 1; k < data_Macro.Count-1; k++)
                        {
                            foreach (char ch in data_Macro[k])
                            {
                                str+=ch;
                                if (ch.Equals(',')){
                                    i+=1;
                                    if (i%2==0){
                                        string [] points=str.Split(',');

                                        macroOutline.addPoint(new Point(Convert.ToSingle(points[0].Replace('.', ',')), Convert.ToSingle(points[1].Replace('.', ','))));
                                        
                                        str=""; 
                                         
                                    }
                                }  
                            }
                            
                        }


                    return macroOutline;
                } 
            
            
                else{
                     
                    MacroOutline macroOutline=new MacroOutline();
                    for (int k = 1; k < data_Macro.Count-1; k++)
                    {
                        string[] points=data_Macro[k].Split(',');
                    
                        macroOutline.addPoint(new Point(Convert.ToSingle(points[0].Replace('.', ',')), Convert.ToSingle(points[1].Replace('.', ','))));
                                        

                    }
                    return macroOutline;
                }
            
            }
        
            

            return macro;
        }





        public Aperture GetMacro(){return this.ParseMacro();}
        public int count(char ch, string data)
        {
            foreach (char value in data)
            {
                if (value.Equals(ch))
                {
                   countchar++; 
                }
            }

            return countchar;
        }

        

        public override float getDiameter()
        {
            throw new NotImplementedException();
        }

        public override float[] getDimension()
        {
            throw new NotImplementedException();
        }
    }



}