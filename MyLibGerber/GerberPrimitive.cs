using  System.Drawing;
using  System.Linq;
using  System.Drawing.Drawing2D;

namespace MyLibGerber
{
    public abstract class GerberPrimitive{

        protected Brush brush= new SolidBrush(Color.Transparent);

        protected Aperture aperture;


        public abstract void getColor(Brush brush);
        public Aperture GetAperture(){return aperture; }

        public abstract void render( Graphics g);

       
        
        

    }
}