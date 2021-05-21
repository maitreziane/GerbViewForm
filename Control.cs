using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaxMinForm
{
   public static class ControlForm
    {

        static bool isMax=false, isFull=false;
        static Point old_loc , default_loc;
        static Size old_size, default_size;

        public static void SetInit(Form form){
                old_loc=form.Location;
                default_loc=form.Location;
                old_size=form.Size;
                default_size= form.Size;

        }
        
        public static void DoMaximize(Form form, Button maxBtn){
            if(isMax==false){
                old_loc= new Point(form.Location.X, form.Location.Y);
                old_size=new Size(form.Size.Width, form.Size.Height);
                Maximize(form);
                isMax=true;
                isFull=false;
                maxBtn.Text="2";
                form.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);

            }
            else
            {
                if(old_size.Width >=SystemInformation.WorkingArea.Width || old_size.Height >=SystemInformation.WorkingArea.Height ){
                    form.Location=default_loc;
                    form.Size=default_size; 
                }else{

                        form.Location=old_loc;
                        form.Size=old_size;
                }

                maxBtn.Text="1";
                isMax=false;
                isFull=false;
                form.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            }

            
        }

        public static void Minimize(Form form){
            if (form.WindowState==FormWindowState.Minimized)
                form.WindowState=FormWindowState.Normal;
            else if (form.WindowState==FormWindowState.Normal)
                form.WindowState=FormWindowState.Minimized; 

        }

        public static void DoFullScreen(Form form)
        { // Button FullBtn

            if (isFull==false){
                old_loc= new Point(form.Location.X, form.Location.Y);
                old_size=new Size(form.Size.Width, form.Size.Height);
                FullScreen(form);
                isMax=false;
                isFull=true;
                
                
            }else
            {
                if(old_size.Width >=SystemInformation.WorkingArea.Width || old_size.Height >=SystemInformation.WorkingArea.Height ){
                    form.Location=default_loc;
                    form.Size=default_size; 
                }else{

                        form.Location=old_loc;
                        form.Size=old_size;
                }
                FullScreen(form);
                isMax=false;
                isFull=false;
            }

        }


        static void FullScreen(Form form){
            if (form.WindowState==FormWindowState.Maximized)
                form.WindowState=FormWindowState.Normal;
            else if (form.WindowState==FormWindowState.Normal)
                form.WindowState=FormWindowState.Maximized; 
        }

        static void Maximize(Form form){
            int x=SystemInformation.WorkingArea.Width;
            int y=SystemInformation.WorkingArea.Height;
            form.WindowState=FormWindowState.Normal;
            form.Location=new Point(0,0);
            form.Size=new Size(x,y);

        }

       public  static void Exit(){Application.Exit();}

    }
}
