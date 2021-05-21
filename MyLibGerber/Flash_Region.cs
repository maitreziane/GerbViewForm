using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyLibGerber
{
    public class Flash_Region : GerberPrimitive
    {   
        private List<Point> point;
        public Flash_Region(List<Point> point, Aperture aperture)
        {
            this.aperture=aperture;
            this.point=point;

        }

        public override void getColor(Brush brush)
        {
            this.brush = brush;

        }

        public override void render(Graphics g)
        {
            int size=point.Count;
            PointF[] pointFs =new PointF[size];
            float x, y;
            for (int i = 0; i < size; i++)
            { 
                x=point[i].getX();
                y=point[i].getY();
                PointF pointF=new PointF(x,y );
                pointFs.SetValue(pointF, i);

            }
            g.FillPolygon(brush, pointFs);
        }
    }
}