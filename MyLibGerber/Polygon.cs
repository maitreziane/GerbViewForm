using System;



namespace MyLibGerber
{
    public class Polygon : Aperture
    {
        int Vertices;
        public Polygon(float diameter, int vertices)
        {
            this.diameter = diameter;
            this.Vertices = vertices;
        }

        public Polygon() { }

        public int Vertice
        {
                get
                {
                return Vertices;
                }
        
        }
        
        public override float getDiameter()
        {
            return this.diameter;
        }

        public override float[] getDimension()
        {
            throw new NotImplementedException();
        }
    }
}