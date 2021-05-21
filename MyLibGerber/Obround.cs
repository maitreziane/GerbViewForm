using System;

namespace MyLibGerber
{
    public class Obround : Aperture
    {
        public Obround(float width, float height) : base(width, height)
        {
            this.dimension[0]=width; this.dimension[1]=height;
        }

        public override float getDiameter()
        {
            throw new NotImplementedException();
        }

        public override float[] getDimension()
        {
            return this.dimension;
        }
    }
}