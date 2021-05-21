using System;

namespace MyLibGerber
{
    public abstract class Aperture
    {
        
        
        protected float[] dimension= new float[2];
        protected float diameter;
        public Aperture(){}
        public Aperture(float diameter){this.diameter=diameter;}
        public Aperture(float width, float height){this.dimension[0]=width; this.dimension[1]=height;}

        public abstract float getDiameter();

        public abstract float[] getDimension();
        

        

    }
}