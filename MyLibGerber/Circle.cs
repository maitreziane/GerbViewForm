using System;

namespace MyLibGerber
{

    public class Circle : Aperture
    {
        private float[] diamet=new float[0];
        public Circle(float diameter) : base(diameter)
        {this.diameter=diameter;}

        public override float getDiameter(){return this.diameter;}

        public override float[] getDimension(){ diamet[0]=0; return diamet;}

       
    }

}