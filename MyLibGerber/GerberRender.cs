
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyLibGerber
{
    public class GerberRender
    {    
        private List<GerberPrimitive> GerberImageList;
        
        Parser parser;
        bool isFlash = false;

        int i=0;
        private Brush[] color = {  new SolidBrush(Color.Green),
                new SolidBrush(Color.Red),new SolidBrush(Color.LightGray) , new SolidBrush(Color.Blue) , new SolidBrush(Color.Beige),new SolidBrush(Color.Magenta) ,new SolidBrush(Color.Cyan) ,new SolidBrush(Color.DarkCyan) ,new SolidBrush(Color.DarkGoldenrod) , new SolidBrush(Color.Crimson) ,new SolidBrush(Color.AliceBlue)  };

        public List<GerberPrimitive> RenderFile(string File){

            parser=new Parser(File);
            GerberImageList = new List<GerberPrimitive>();

            foreach (GerberPrimitive gerberPrimitive in parser.getADHasTable())
                GerberImageList.Add(gerberPrimitive);

            isFlash = true;
            return GerberImageList;
    
        }

        public void ImageObject(Graphics g, List<List<GerberPrimitive>> primitives )
        {
                Random rand = new Random();

                
            
            
                foreach (var listPr in primitives)
                {
                    i = rand.Next(0, color.Length);
                    foreach (var element in listPr)
                    {

                      element.getColor(color[2]);
                      element.render(g);
                    
                }
                }
          //  g.DrawImage(g, 0, 0);
           

        }

        public void setFlash(bool isFlash) { this.isFlash = isFlash; }


    }



    
    


}