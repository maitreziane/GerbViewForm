
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyLibGerber
{
    public class Flash : GerberPrimitive
    {  Point point;
        public Flash(Point point, Aperture aperture)
        {
            this.point=point;
            this.aperture=aperture;

        }

        public override void getColor(Brush brush)
        {
            this.brush = brush;
        }

        public Point getPoint()
    {
        return point;
    }

    public float getX()
    {
        return point.getX();
    }

    public float getY()
    {
    return point.getY();
    }


        public override void render(Graphics g )
        {
            // flash circle
            
            if (GetAperture() is MyLibGerber.Circle){

                float diameter= Math.Max( GetAperture().getDiameter(), 0);
                float r=diameter/2;
                RectangleF rectangle= new RectangleF(getX()-r, getY()-r, diameter,diameter);
                g.FillEllipse(brush, rectangle);
                
            }
            // flash rectangle
            if (GetAperture() is MyLibGerber.Rectangle){

                    Rectangle aperRect= (Rectangle) GetAperture();
                    float width=Math.Max(aperRect.getDimension()[0], 0);
                    float height=Math.Max(aperRect.getDimension()[1], 0);
                    RectangleF rectangle= new RectangleF(getX()-aperRect.getDimension()[0]/2, getY()-aperRect.getDimension()[1]/2, width,height);

                    g.FillRectangle(brush, rectangle);
               
            }

            // flash Polygon 

            if (GetAperture() is MyLibGerber.Polygon){
                Polygon polygon = (Polygon)GetAperture();

                int vertices = polygon.Vertice;
                float diameter = polygon.getDiameter()/2;

                PointF[] pointFs = new PointF[vertices];
                float angle_depart =(float) (Math.PI / 2.0 - Math.PI / vertices);
                float angle_cote = (float) (2.0 * Math.PI / vertices);

                for(int i =0; i< vertices; i++)
                {
                    float x = (float)(diameter * Math.Cos(angle_depart + i * angle_cote) + getX());
                    float y = (float)(diameter * Math.Sin(angle_depart + i * angle_cote) + getY());
                    PointF pointF = new PointF(x, y);
                    pointFs.SetValue(pointF, i);
                }

                g.FillPolygon(brush, pointFs);
                
            }

            // flash Obround 
            if(GetAperture() is MyLibGerber.Obround)
            {
                Obround obround = (Obround)GetAperture();
                float width = Math.Max(obround.getDimension()[0], 0);
                float height = Math.Max(obround.getDimension()[1], 0);
                RectangleF rectangleF = new RectangleF(getX() - obround.getDimension()[0] / 2, getY() - obround.getDimension()[1] / 2, width, height);


                //System.Drawing.Rectangle round = new System.Drawing.Rectangle(rectangleF);

                //this.DrawRoundedRectangle(g, rectangleF,5, brush);
                g.FillRectangle(brush, rectangleF);
            }

            // Macro start
            if (GetAperture() is MyLibGerber.MacroOutline){
                
                
                MacroOutline outline=(MacroOutline) GetAperture();
                int size=outline.getPoints().Count;
                PointF[] pointFs =new PointF[size];

                float x, y;
                for (int i = 0; i < size; i++)
                {   
                    x=outline.getPoints()[i].getX()+getX();
                    y=outline.getPoints()[i].getY()+getY();
                    PointF pointF=new PointF(x,y );
                    pointFs.SetValue(pointF, i);
                }
                
                g.FillPolygon(brush, pointFs);
                


            }
            
        }// end render


        private void DrawRoundedRectangle(Graphics g, System.Drawing.RectangleF rect, int d ,Brush brush)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.X + rect.Width-d, rect.Y, d,d, 270, 90);
            path.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height, d, d, 0, 90);
            path.AddArc(rect.X , rect.Y - rect.Height-d,  d, d, 90, 90);
            path.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);
            g.FillPath(brush, path);

        }

       
    }

}