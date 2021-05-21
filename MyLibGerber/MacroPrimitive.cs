
using System;


namespace MyLibGerber{

    public abstract class MacroPrimitive : Aperture

    {
    private int rotationAngle;
    protected MacroPrimitive(){this.rotationAngle=0;}

    protected MacroPrimitive(int rotationAngle){this.rotationAngle = rotationAngle;}


    protected Point translate(Point p)
    {
        if (rotationAngle == 0)
            return p;
            
        double theta = (Math.PI/180)* rotationAngle;  //toRadians(rotationAngle);
        double x = Math.Cos(theta) * p.getX() - Math.Sin(theta) * p.getY();
        double y = Math.Sin(theta) * p.getX() + Math.Cos(theta) * p.getY();
        return new Point((float) x, (float) y);
    }

    public int getRotationAngle()
    {
        return rotationAngle;
    }

    public void setRotationAngle(int rotationAngle)
    {
        this.rotationAngle = rotationAngle;
    }

    public abstract MacroPrimitive clone();



    }

}