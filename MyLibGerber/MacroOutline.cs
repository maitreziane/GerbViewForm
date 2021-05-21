
using System.Collections.Generic;

namespace  MyLibGerber
{

    public class MacroOutline : MacroPrimitive
    {

    List<Point> points= new List<Point>();

    public MacroOutline(List<Point> points, int rotationAngle) : base(rotationAngle)
    {this.points = points;}

        public MacroOutline()
        {
        }

        public void addPoint(Point point){points.Add(point);}

    public List<Point> getPoints()
    {return points;}

    public List<Point> getTranslatedPoints()
    {
        List<Point> result = new List<Point>();
        foreach (Point p in points)
            result.Add(translate(p));

        return result;
    }

        public override MacroPrimitive clone()
        {
            return new MacroOutline(points, getRotationAngle());
        }

        public override float getDiameter()
        {
            throw new System.NotImplementedException();
        }

        public override float[] getDimension()
        {
            throw new System.NotImplementedException();
        }

        
    }
    
}



