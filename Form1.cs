using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxMinForm;
using MyLibGerber;



namespace GerbViewForm
{
    public partial class Form1 : Form
    {
        readonly int grip = 16;
        readonly int caption = 40;
        private bool drag = false;
        private float scale;
      
        private float transFormX = 500, transFormY = 300.0F;
        private GerberRenderMode renderMode;

        


        System.Drawing.Point start_point = new System.Drawing.Point(0, 0);
        private float userScale;
        private readonly GerberRender gerberRender=null;
        private GerberInformation gerberInformation;
        private BufferedGraphics grafx;
        private List<List<GerberPrimitive>> listObjects=new List<List<GerberPrimitive>>();
        

        
        public Form1()
        {
            

            InitializeComponent();
            SendToBack();
            gerberRender = new GerberRender();
            gerberInformation = new GerberInformation(this.panelDraw.Size);
            
            renderMode = GerberRenderMode.TranslateToCentre;
            //this.treeView1.Visible = false;
            //this.tabControl1.Visible = this.treeView1.Visible;

            //this.panel_container_menu.Curvature = 20;
            InitPanel();

        }

        private void InitPanel()
        {
            grafx = gerberInformation.Context.Allocate(this.CreateGraphics(), new System.Drawing.Rectangle(0, 0, this.panelDraw.Width, this.panelDraw.Height));
            this.panelDraw.Curvature = 8;
            this.panelF.Curvature = 8;
            //this.panelDraw.GradientMode = Panel_Design.LinearGradientMode.BackwardDiagonal;
            //this.panelDraw.BorderColor = System.Drawing.Color.DodgerBlue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {       
            // gestion des pour empêcher que la fenêtre charger à chage évenement pour redessiner
           

            panelDraw.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(panelDraw,
            new Object[] {System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint
            | System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer , true });

           //panelDraw.BackColor = Color.Black;

            ControlForm.SetInit(this); // initialisation pour le control de l'application Max Min Restore and Full
            Splitter splitter = new Splitter();
            splitter.Dock = DockStyle.Left;
            splitter.Size = new Size(3, 554);
            splitter.Padding = new System.Windows.Forms.Padding(3);
            // splitter.BackColor= System.Drawing.SystemColors.ControlDark;
            // splitter.Cursor= Cursor = System.Windows.Forms.Cursors.SizeWE;

            this.panelmain2.Controls.AddRange(new Control[] { panelDraw, splitter, this.panelF, });
            this.panelF.Controls.AddRange(new Control[] { this.treeView1, splitter_pangcd_treev,  PanelViewGCODE });

            userScale = 1.0f;
            scale = 8.0f;
            
        }


        //#########################################################################################
        //################ cette methode permet de redimensionner  ################################
        //#########################################################################################
        protected override void WndProc(ref Message m) //  
        {

            if (m.Msg == 0x84)
            {
                System.Drawing.Point p = new System.Drawing.Point(m.LParam.ToInt32());
                p = this.PointToClient(p);

                if (p.Y <= caption && p.Y >= grip)
                {
                    m.Result = (IntPtr)2;
                    return;

                }
                if (p.X >= this.ClientSize.Width && p.Y >= this.ClientSize.Height)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
                if (p.X <= grip && p.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)16;
                    return;
                }


                if (p.X <= grip)
                {
                    m.Result = (IntPtr)10;
                    return;
                }
                if (p.X >= this.ClientSize.Width - grip)
                {
                    m.Result = (IntPtr)11;
                    return;
                }
                if (p.Y <= grip)
                {
                    m.Result = (IntPtr)12;
                    return;
                }

                if (p.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)15;
                    return;
                }
            }
            base.WndProc(ref m);
        }



        //#########################################################################################
        //################  trois methodes pour deplacement de la fenêtre  ########################
        //#########################################################################################
        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new System.Drawing.Point(e.X, e.Y);
        }

        private void HeaderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                System.Drawing.Point p = PointToScreen(e.Location);
                this.Location = new System.Drawing.Point(p.X - start_point.X, p.Y - start_point.Y);
                this.Padding = new Padding(1, 1, 1, 1);
                //Screen.PrimaryScreen.WorkingArea

                

            }
        }

        // fin 

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            ControlForm.Exit();
        }

        private void MaxMinBtn_Click(object sender, EventArgs e)
        {
            this.panelDraw.Invalidate();
            ControlForm.DoMaximize(this, (Button)sender);
            
        }

        private void RestorBtn_Click(object sender, EventArgs e)
        {
            ControlForm.Minimize(this);
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.panel_Home.Visible = true;
            this.panel_Affichage.Visible = false;
         
            this.Home.BackColor= System.Drawing.Color.DimGray;
            this.AffichageBtn.BackColor = System.Drawing.Color.Black;
            this.Home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;

            this.AffichageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

           
        }

        private void AffichageBtn_Click(object sender, EventArgs e)
        {
            this.panel_Home.Visible = false;
            this.panel_Affichage.Visible = true;

            this.Home.BackColor = System.Drawing.Color.Black;
            this.AffichageBtn.BackColor= System.Drawing.Color.DimGray;
            this.AffichageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));


            

        }

        private void panel_Draw_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                userScale -= 0.25f;
                if (userScale < 0.25f)
                    userScale = 0.25f;
                scale -= userScale/2;
                transFormX += 30 / 8;
               transFormY -= 20 / 5;
            }

            if (e.Delta > 0)
            {
                userScale += 0.25f;
                if (userScale > 10.0f)
                    userScale = 10.0f;
                scale += userScale/2;
                transFormX -= 30/8;
                transFormY -= 20/5;
            }


           panelDraw.Refresh();
        }

   
        private void FichierBtn_Click(object sender, EventArgs e)
        {
           this.OPen_Gerber_file();
           Thread.Sleep(5000);
         
           panelDraw.Refresh();
            

        }


        private void OPen_Gerber_file()
        {

            

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Ouvrir Fichier(s) Gerber";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
               

                if (openFileDialog.ShowDialog() == DialogResult.OK )
                {

                    
                    foreach (string file in openFileDialog.FileNames)
                    {
                      string[] f= file.Split('\\');
                      this.treeView1.Nodes[0].Nodes.Add(f[f.Length-1]);
                      listObjects.Add(gerberRender.RenderFile(file));
                      this.treeView1.Refresh();

                    
                    }
                   

                }
                
               
            }

          
        }


        private void DrawGrid(Graphics g, float theScale)
        {
            float yOffset = g.VisibleClipBounds.Height;
            float TextHeight = theScale / 25;
            using (Font f = new Font("Arial", TextHeight/4))
            {
                Pen p = new Pen(Color.SkyBlue, theScale / 500);
                Brush br = new SolidBrush(Color.BlueViolet);
                float y1 = (float)(yOffset - (1.5 * TextHeight));
                float y2;
                int sca = 0;
                for (int x = 0; x < theScale+800; x += 30)
                {
                    
                    if (x == 30)
                    {
                        Pen pp = new Pen(Color.SkyBlue, theScale / 300);
                       g.DrawString(sca.ToString(), f, br, x, y1 + 30);
                        g.DrawLine(pp, x, yOffset, x, yOffset - theScale);
                        y2 = (float)(yOffset - (1.5 * TextHeight + x));
                       g.DrawString(sca.ToString(), f, br, 0, y2);


                        g.DrawLine(pp, 0, yOffset - x, theScale + 800, yOffset - x);

                        
                    }
                    else
                    {
                        g.DrawLine(p, x, yOffset, x, yOffset - theScale);
                        g.DrawString(sca.ToString(), f, br, x, y1+30);

                        y2 = (float)(yOffset - (1.5 * TextHeight + x));
                        g.DrawString(sca.ToString(), f, br, 0, y2);
                        g.DrawLine(p, 0, yOffset - x, theScale + 800, yOffset - x);

                        
                    }
                    sca += 5;
                   
                }
            }
        }

        private void DrawGerber(object sender, PaintEventArgs e)
        {
            grafx.Render(e.Graphics); // buffer
            Graphics g = e.Graphics;

            float panelWidth = panelDraw.Width / g.DpiX;
            float panelHeight = panelDraw.Height / g.DpiY;

            if (renderMode == GerberRenderMode.TranslateToCentre)
            {
            
            /// pas encore            
            }
            
            g.TranslateTransform(0.0F,5.0F, MatrixOrder.Append);
           // this.DrawGrid(g, 900);
            g.TranslateTransform(transFormX, transFormY, MatrixOrder.Append);
            g.ScaleTransform(scale, scale);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            
           
            gerberRender.ImageObject(g, listObjects);
            gerberRender.setFlash(false);
           
            
            panelDraw.Focus();
                
               
                        
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ContextMenu m = new ContextMenu();
            
            m.MenuItems.Add("Color");
            m.MenuItems.Add("Hide");
            m.MenuItems.Add("Generate gcode");

            
            m.Show(this.treeView1, treeView1.SelectedNode.Bounds.Location);
          
        }

        private void PanelViewGCODE_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void OnResizerDrawGerber(object sender, EventArgs e)
        {

           gerberInformation.Context.MaximumBuffer = new Size(this.panelDraw.Width + 1, this.panelDraw.Height + 1);
           if(grafx != null)
            {
                grafx.Dispose();
                grafx = null;
            }
            grafx = gerberInformation.Context.Allocate(this.CreateGraphics(), new System.Drawing.Rectangle(0, 0, this.panelDraw.Width, this.panelDraw.Height));
            

            panelDraw.Refresh();

        }

        


        //



    }
}
