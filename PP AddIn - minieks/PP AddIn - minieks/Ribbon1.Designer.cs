﻿namespace PP_AddIn___minieks
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon1));
            this.Spoergsmaalslaver = this.Factory.CreateRibbonTab();
            this.spoergsmaal_grp = this.Factory.CreateRibbonGroup();
            this.Administrer_btn = this.Factory.CreateRibbonButton();
            this.Opret_btn = this.Factory.CreateRibbonButton();
            this.Session_grp = this.Factory.CreateRibbonGroup();
            this.LavLink_menu = this.Factory.CreateRibbonMenu();
            this.StartStopSession_btn = this.Factory.CreateRibbonButton();
            this.menu1 = this.Factory.CreateRibbonMenu();
            this.menu2 = this.Factory.CreateRibbonMenu();
            this.Spoergsmaalslaver.SuspendLayout();
            this.spoergsmaal_grp.SuspendLayout();
            this.Session_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spoergsmaalslaver
            // 
            this.Spoergsmaalslaver.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Spoergsmaalslaver.Groups.Add(this.spoergsmaal_grp);
            this.Spoergsmaalslaver.Groups.Add(this.Session_grp);
            this.Spoergsmaalslaver.Label = "Spørgsmålslaver";
            this.Spoergsmaalslaver.Name = "Spoergsmaalslaver";
            // 
            // spoergsmaal_grp
            // 
            this.spoergsmaal_grp.Items.Add(this.Administrer_btn);
            this.spoergsmaal_grp.Items.Add(this.Opret_btn);
            this.spoergsmaal_grp.Label = "Spørgsmål";
            this.spoergsmaal_grp.Name = "spoergsmaal_grp";
            // 
            // Administrer_btn
            // 
            this.Administrer_btn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Administrer_btn.Image = ((System.Drawing.Image)(resources.GetObject("Administrer_btn.Image")));
            this.Administrer_btn.Label = "Administrer spørgsmål";
            this.Administrer_btn.Name = "Administrer_btn";
            this.Administrer_btn.ShowImage = true;
            this.Administrer_btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // Opret_btn
            // 
            this.Opret_btn.Image = ((System.Drawing.Image)(resources.GetObject("Opret_btn.Image")));
            this.Opret_btn.Label = "Nyt spørgsmål";
            this.Opret_btn.Name = "Opret_btn";
            this.Opret_btn.ShowImage = true;
            this.Opret_btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click_1);
            // 
            // Session_grp
            // 
            this.Session_grp.Items.Add(this.LavLink_menu);
            this.Session_grp.Items.Add(this.StartStopSession_btn);
            this.Session_grp.Label = "Session";
            this.Session_grp.Name = "Session_grp";
            // 
            // LavLink_menu
            // 
            this.LavLink_menu.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.LavLink_menu.Image = ((System.Drawing.Image)(resources.GetObject("LavLink_menu.Image")));
            this.LavLink_menu.Items.Add(this.menu1);
            this.LavLink_menu.Items.Add(this.menu2);
            this.LavLink_menu.ItemSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.LavLink_menu.Label = "Lav link";
            this.LavLink_menu.Name = "LavLink_menu";
            this.LavLink_menu.ShowImage = true;
            // 
            // StartStopSession_btn
            // 
            this.StartStopSession_btn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.StartStopSession_btn.Label = "Start session";
            this.StartStopSession_btn.Name = "StartStopSession_btn";
            this.StartStopSession_btn.ShowImage = true;
            // 
            // menu1
            // 
            this.menu1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menu1.Label = "Indsæt på alle slides";
            this.menu1.Name = "menu1";
            this.menu1.ShowImage = true;
            // 
            // menu2
            // 
            this.menu2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menu2.Label = "Indsæt på aktuel slide";
            this.menu2.Name = "menu2";
            this.menu2.ShowImage = true;
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.Spoergsmaalslaver);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.Spoergsmaalslaver.ResumeLayout(false);
            this.Spoergsmaalslaver.PerformLayout();
            this.spoergsmaal_grp.ResumeLayout(false);
            this.spoergsmaal_grp.PerformLayout();
            this.Session_grp.ResumeLayout(false);
            this.Session_grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Spoergsmaalslaver;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup spoergsmaal_grp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Administrer_btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Opret_btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Session_grp;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu LavLink_menu;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton StartStopSession_btn;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}