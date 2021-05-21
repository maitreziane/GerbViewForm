using System;

namespace MyLibGerber{

    [System.Serializable]
    public class Point {
    
    

    private float x;
    private float y;

    public Point(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float getX()
    {
        return x;
    }

    public float getY()
    {
        return y;
    }

    public double distanceTo(Point p)
    {
        double x = this.x - p.x;
        double y = this.y - p.y;
        return Math.Sqrt(x * x + y * y);
    }


        public Point add(Point p)
    {
        return new Point(this.x + p.x, this.y + p.y);
    }

    public Point subtract(Point p)
    {
        return new Point(this.x - p.x, this.y - p.y);
    }

    public Point round()
    {
        return round(10);
    }

    public Point round(int roundTo)
    {
        return new Point((x + roundTo / 2) / roundTo * roundTo, (y + roundTo / 2) / roundTo * roundTo);
    }


    public Point rotateRelativeToOrigin(Boolean clockwise)
    {
        if (clockwise)
            return new Point(y, -x);
        else
            return new Point(-y, x);
    }


    
    public  string toString()
    {
        return "Point{" +
                "x=" + x +
                ", y=" + y +
                '}';
    }



    public Boolean equals(Object o)
    {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;

        

        Point point = (Point) o;

        if (x != point.x) return false;
        if (y != point.y) return false;

        return true;
    }

    public Boolean equals(Point o, double precision)
    {
        return distanceTo(o) < precision;
    }

  
    public float hashCode()
    {
        float result = x;
        result = 31 * result + y;
        return result;
    }




    }
}