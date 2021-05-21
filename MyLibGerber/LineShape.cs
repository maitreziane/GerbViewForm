using System;
using System.Drawing;

namespace MyLibGerber
{
    public class LineShape : GerberPrimitive
    {   
        Point startPoint, toPoint;
        public LineShape(Point startPoint, Point toPoint, Aperture aperture)
        {
            this.aperture=aperture;
            this.toPoint=toPoint;
            this.startPoint=startPoint;
        }

        public override void getColor(Brush brush)
        {
            this.brush = brush;
        }

        public override void render(Graphics g )
        {   PointF start= new PointF(Convert.ToSingle(startPoint.getX()), Convert.ToSingle(startPoint.getY()));
            PointF to= new PointF(Convert.ToSingle(toPoint.getX()), Convert.ToSingle(toPoint.getY()));
            Pen pen=new Pen(brush, aperture.getDiameter() );
            pen.StartCap=System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap=System.Drawing.Drawing2D.LineCap.Round;
            g.DrawLine(pen, start, to);

            //g.DrawLine(brush, startPoint, toPoint);

            //Console.Write(Convert.ToSingle(startPoint.getX()));
        }
    }
}