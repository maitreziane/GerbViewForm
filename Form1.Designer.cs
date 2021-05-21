namespace GerbViewForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// 
        
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Gerber");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Main_Panel = new System.Windows.Forms.Panel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panelmain2 = new System.Windows.Forms.Panel();
            this.panelDraw = new Panel_Design.CustomPanel();
            this.panelF = new Panel_Design.CustomPanel();
            this.PanelViewGCODE = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitter_pangcd_treev = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.statut_panel = new System.Windows.Forms.Panel();
            this.panel_container_menu = new Panel_Design.CustomPanel();
            this.AffichageBtn = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.FichierBtn = new System.Windows.Forms.Button();
            this.panel_Home = new System.Windows.Forms.Panel();
            this.panel_Affichage = new System.Windows.Forms.Panel();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MaxMinBtn = new System.Windows.Forms.Button();
            this.RestorBtn = new System.Windows.Forms.Button();
            this.Main_Panel.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panelmain2.SuspendLayout();
            this.panelF.SuspendLayout();
            this.PanelViewGCODE.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel_container_menu.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Panel
            // 
            this.Main_Panel.AutoSize = true;
            this.Main_Panel.BackColor = System.Drawing.Color.White;
            this.Main_Panel.Controls.Add(this.panel_main);
            this.Main_Panel.Controls.Add(this.statut_panel);
            this.Main_Panel.Controls.Add(this.panel_container_menu);
            this.Main_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Panel.Location = new System.Drawing.Point(1, 1);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Size = new System.Drawing.Size(1198, 698);
            this.Main_Panel.TabIndex = 0;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.Black;
            this.panel_main.Controls.Add(this.panelmain2);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 120);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1198, 554);
            this.panel_main.TabIndex = 2;
            // 
            // panelmain2
            // 
            this.panelmain2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelmain2.Controls.Add(this.panelDraw);
            this.panelmain2.Controls.Add(this.panelF);
            this.panelmain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelmain2.Location = new System.Drawing.Point(0, 0);
            this.panelmain2.Name = "panelmain2";
            this.panelmain2.Padding = new System.Windows.Forms.Padding(3);
            this.panelmain2.Size = new System.Drawing.Size(1198, 554);
            this.panelmain2.TabIndex = 0;
            // 
            // panelDraw
            // 
            this.panelDraw.AllowDrop = true;
            this.panelDraw.AutoScroll = true;
            this.panelDraw.BackColor = System.Drawing.Color.Transparent;
            this.panelDraw.BackColor2 = System.Drawing.Color.DodgerBlue;
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDraw.BorderWidth = 2;
            this.panelDraw.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelDraw.Curvature = 2;
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.GradientMode = Panel_Design.LinearGradientMode.BackwardDiagonal;
            this.panelDraw.Location = new System.Drawing.Point(300, 3);
            this.panelDraw.Margin = new System.Windows.Forms.Padding(0);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(895, 548);
            this.panelDraw.TabIndex = 1;
            this.panelDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGerber);
            this.panelDraw.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel_Draw_MouseWheel);
            this.panelDraw.Resize += new System.EventHandler(this.OnResizerDrawGerber);
            // 
            // panelF
            // 
            this.panelF.BackColor = System.Drawing.Color.LightGray;
            this.panelF.BackColor2 = System.Drawing.Color.DodgerBlue;
            this.panelF.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelF.BorderWidth = 6;
            this.panelF.Controls.Add(this.PanelViewGCODE);
            this.panelF.Controls.Add(this.splitter_pangcd_treev);
            this.panelF.Controls.Add(this.treeView1);
            this.panelF.Curvature = 8;
            this.panelF.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelF.GradientMode = Panel_Design.LinearGradientMode.BackwardDiagonal;
            this.panelF.Location = new System.Drawing.Point(3, 3);
            this.panelF.Name = "panelF";
            this.panelF.Size = new System.Drawing.Size(297, 548);
            this.panelF.TabIndex = 0;
            // 
            // PanelViewGCODE
            // 
            this.PanelViewGCODE.BackColor = System.Drawing.Color.Silver;
            this.PanelViewGCODE.Controls.Add(this.tabControl1);
            this.PanelViewGCODE.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelViewGCODE.Location = new System.Drawing.Point(0, 293);
            this.PanelViewGCODE.Name = "PanelViewGCODE";
            this.PanelViewGCODE.Size = new System.Drawing.Size(297, 251);
            this.PanelViewGCODE.TabIndex = 2;
            this.PanelViewGCODE.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelViewGCODE_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(297, 251);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(289, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(289, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitter_pangcd_treev
            // 
            this.splitter_pangcd_treev.BackColor = System.Drawing.Color.Black;
            this.splitter_pangcd_treev.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter_pangcd_treev.Location = new System.Drawing.Point(0, 544);
            this.splitter_pangcd_treev.Name = "splitter_pangcd_treev";
            this.splitter_pangcd_treev.Size = new System.Drawing.Size(297, 4);
            this.splitter_pangcd_treev.TabIndex = 1;
            this.splitter_pangcd_treev.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.treeView1.BackColor = System.Drawing.Color.LightGray;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.treeView1.HideSelection = false;
            this.treeView1.LineColor = System.Drawing.Color.DodgerBlue;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Nœud0";
            treeNode1.NodeFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "Gerber";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(297, 548);
            this.treeView1.TabIndex = 0;
            this.treeView1.TabStop = false;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // statut_panel
            // 
            this.statut_panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.statut_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statut_panel.Location = new System.Drawing.Point(0, 674);
            this.statut_panel.Name = "statut_panel";
            this.statut_panel.Size = new System.Drawing.Size(1198, 24);
            this.statut_panel.TabIndex = 1;
            // 
            // panel_container_menu
            // 
            this.panel_container_menu.BackColor = System.Drawing.Color.Black;
            this.panel_container_menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_container_menu.Controls.Add(this.AffichageBtn);
            this.panel_container_menu.Controls.Add(this.Home);
            this.panel_container_menu.Controls.Add(this.FichierBtn);
            this.panel_container_menu.Controls.Add(this.panel_Home);
            this.panel_container_menu.Controls.Add(this.panel_Affichage);
            this.panel_container_menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_container_menu.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_container_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_container_menu.MinimumSize = new System.Drawing.Size(2, 120);
            this.panel_container_menu.Name = "panel_container_menu";
            this.panel_container_menu.Padding = new System.Windows.Forms.Padding(1);
            this.panel_container_menu.Size = new System.Drawing.Size(1198, 120);
            this.panel_container_menu.TabIndex = 0;
            // 
            // AffichageBtn
            // 
            this.AffichageBtn.BackColor = System.Drawing.Color.Black;
            this.AffichageBtn.FlatAppearance.BorderSize = 0;
            this.AffichageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.AffichageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AffichageBtn.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AffichageBtn.ForeColor = System.Drawing.Color.White;
            this.AffichageBtn.Location = new System.Drawing.Point(146, 19);
            this.AffichageBtn.Name = "AffichageBtn";
            this.AffichageBtn.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.AffichageBtn.Size = new System.Drawing.Size(76, 23);
            this.AffichageBtn.TabIndex = 2;
            this.AffichageBtn.Text = "Affichage";
            this.AffichageBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AffichageBtn.UseVisualStyleBackColor = false;
            this.AffichageBtn.Click += new System.EventHandler(this.AffichageBtn_Click);
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.DimGray;
            this.Home.FlatAppearance.BorderSize = 0;
            this.Home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.Home.ForeColor = System.Drawing.Color.White;
            this.Home.Location = new System.Drawing.Point(71, 19);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.Home.Size = new System.Drawing.Size(75, 23);
            this.Home.TabIndex = 1;
            this.Home.Text = "Accueil";
            this.Home.UseVisualStyleBackColor = false;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // FichierBtn
            // 
            this.FichierBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.FichierBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.FichierBtn.FlatAppearance.BorderSize = 0;
            this.FichierBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FichierBtn.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.FichierBtn.ForeColor = System.Drawing.Color.White;
            this.FichierBtn.Location = new System.Drawing.Point(0, 19);
            this.FichierBtn.Name = "FichierBtn";
            this.FichierBtn.Size = new System.Drawing.Size(75, 23);
            this.FichierBtn.TabIndex = 0;
            this.FichierBtn.Text = "Fichier";
            this.FichierBtn.UseVisualStyleBackColor = false;
            this.FichierBtn.Click += new System.EventHandler(this.FichierBtn_Click);
            // 
            // panel_Home
            // 
            this.panel_Home.BackColor = System.Drawing.Color.DimGray;
            this.panel_Home.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Home.Location = new System.Drawing.Point(1, 44);
            this.panel_Home.Name = "panel_Home";
            this.panel_Home.Size = new System.Drawing.Size(1196, 75);
            this.panel_Home.TabIndex = 4;
            // 
            // panel_Affichage
            // 
            this.panel_Affichage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Affichage.BackColor = System.Drawing.Color.Olive;
            this.panel_Affichage.Location = new System.Drawing.Point(1, 42);
            this.panel_Affichage.Name = "panel_Affichage";
            this.panel_Affichage.Size = new System.Drawing.Size(1194, 75);
            this.panel_Affichage.TabIndex = 5;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Black;
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Controls.Add(this.CloseBtn);
            this.HeaderPanel.Controls.Add(this.MaxMinBtn);
            this.HeaderPanel.Controls.Add(this.RestorBtn);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(1, 1);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1198, 23);
            this.HeaderPanel.TabIndex = 0;
            this.HeaderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseDown);
            this.HeaderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseMove);
            this.HeaderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(630, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gerb For CNC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CloseBtn.Location = new System.Drawing.Point(1161, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(37, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MaxMinBtn
            // 
            this.MaxMinBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxMinBtn.BackColor = System.Drawing.Color.Transparent;
            this.MaxMinBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.MaxMinBtn.FlatAppearance.BorderSize = 0;
            this.MaxMinBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AliceBlue;
            this.MaxMinBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.MaxMinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaxMinBtn.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MaxMinBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MaxMinBtn.Location = new System.Drawing.Point(1127, 0);
            this.MaxMinBtn.Name = "MaxMinBtn";
            this.MaxMinBtn.Size = new System.Drawing.Size(37, 23);
            this.MaxMinBtn.TabIndex = 2;
            this.MaxMinBtn.Text = "1";
            this.MaxMinBtn.UseVisualStyleBackColor = false;
            this.MaxMinBtn.Click += new System.EventHandler(this.MaxMinBtn_Click);
            // 
            // RestorBtn
            // 
            this.RestorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RestorBtn.BackColor = System.Drawing.Color.Transparent;
            this.RestorBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.RestorBtn.FlatAppearance.BorderSize = 0;
            this.RestorBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AliceBlue;
            this.RestorBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.RestorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestorBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RestorBtn.Location = new System.Drawing.Point(1090, 0);
            this.RestorBtn.Name = "RestorBtn";
            this.RestorBtn.Size = new System.Drawing.Size(37, 23);
            this.RestorBtn.TabIndex = 1;
            this.RestorBtn.Text = "_";
            this.RestorBtn.UseMnemonic = false;
            this.RestorBtn.UseVisualStyleBackColor = false;
            this.RestorBtn.Click += new System.EventHandler(this.RestorBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.Main_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "Form1";
            this.Opacity = 0.99D;
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerb For CNC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Main_Panel.ResumeLayout(false);
            this.panel_main.ResumeLayout(false);
            this.panelmain2.ResumeLayout(false);
            this.panelF.ResumeLayout(false);
            this.PanelViewGCODE.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel_container_menu.ResumeLayout(false);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Main_Panel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button MaxMinBtn;
        private System.Windows.Forms.Button RestorBtn;
        private Panel_Design.CustomPanel panel_container_menu;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button FichierBtn;
        private System.Windows.Forms.Button AffichageBtn;
        public  System.Windows.Forms.Panel panel_Affichage;
        private System.Windows.Forms.Panel statut_panel;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panelmain2;
        private Panel_Design.CustomPanel panelF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelViewGCODE;
        private System.Windows.Forms.Splitter splitter_pangcd_treev;
        private Panel_Design.CustomPanel panelDraw;
        public System.Windows.Forms.Panel panel_Home;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

