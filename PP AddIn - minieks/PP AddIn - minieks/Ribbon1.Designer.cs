namespace PP_AddIn___minieks
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
            this.Spørgsmålslaver = this.Factory.CreateRibbonTab();
            this.spoergsmaal_grp = this.Factory.CreateRibbonGroup();
            this.Administrer_btn = this.Factory.CreateRibbonButton();
            this.Opret_btn = this.Factory.CreateRibbonButton();
            this.Session_grp = this.Factory.CreateRibbonGroup();
            this.LavLink_menu = this.Factory.CreateRibbonMenu();
            this.menu1 = this.Factory.CreateRibbonMenu();
            this.BRbutton = this.Factory.CreateRibbonButton();
            this.TLbutton = this.Factory.CreateRibbonButton();
            this.TRbutton = this.Factory.CreateRibbonButton();
            this.BLbutton = this.Factory.CreateRibbonButton();
            this.menu2 = this.Factory.CreateRibbonMenu();
            this.StartStopSession_btn = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.ChemSketch_btn = this.Factory.CreateRibbonButton();
            this.Download = this.Factory.CreateRibbonGroup();
            this.Download_btn = this.Factory.CreateRibbonButton();
            this.Spørgsmålslaver.SuspendLayout();
            this.spoergsmaal_grp.SuspendLayout();
            this.Session_grp.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.Download.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spørgsmålslaver
            // 
            this.Spørgsmålslaver.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Spørgsmålslaver.Groups.Add(this.spoergsmaal_grp);
            this.Spørgsmålslaver.Groups.Add(this.Session_grp);
            this.Spørgsmålslaver.Groups.Add(this.group1);
            this.Spørgsmålslaver.Groups.Add(this.group2);
            this.Spørgsmålslaver.Groups.Add(this.Download);
            this.Spørgsmålslaver.Label = "PPQuiz";
            this.Spørgsmålslaver.Name = "Spørgsmålslaver";
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
            // menu1
            // 
            this.menu1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menu1.Items.Add(this.BRbutton);
            this.menu1.Items.Add(this.TLbutton);
            this.menu1.Items.Add(this.TRbutton);
            this.menu1.Items.Add(this.BLbutton);
            this.menu1.Label = "Indsæt på alle slides";
            this.menu1.Name = "menu1";
            this.menu1.ShowImage = true;
            // 
            // BRbutton
            // 
            this.BRbutton.Label = " BR";
            this.BRbutton.Name = "BRbutton";
            this.BRbutton.ShowImage = true;
            this.BRbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BRbutton_Click);
            // 
            // TLbutton
            // 
            this.TLbutton.Label = "TL";
            this.TLbutton.Name = "TLbutton";
            this.TLbutton.ShowImage = true;
            this.TLbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TLbutton_Click);
            // 
            // TRbutton
            // 
            this.TRbutton.Label = " TR";
            this.TRbutton.Name = "TRbutton";
            this.TRbutton.ShowImage = true;
            this.TRbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TRbutton_Click);
            // 
            // BLbutton
            // 
            this.BLbutton.Label = " BL";
            this.BLbutton.Name = "BLbutton";
            this.BLbutton.ShowImage = true;
            this.BLbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BLbutton_Click);
            // 
            // menu2
            // 
            this.menu2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menu2.Label = "Indsæt på aktuel slide";
            this.menu2.Name = "menu2";
            this.menu2.ShowImage = true;
            // 
            // StartStopSession_btn
            // 
            this.StartStopSession_btn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.StartStopSession_btn.Image = ((System.Drawing.Image)(resources.GetObject("StartStopSession_btn.Image")));
            this.StartStopSession_btn.Label = "Start session";
            this.StartStopSession_btn.Name = "StartStopSession_btn";
            this.StartStopSession_btn.ShowImage = true;
            this.StartStopSession_btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.StartStopSession_btn_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            this.group1.Label = "Excel";
            this.group1.Name = "group1";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "Upload liste";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            // 
            // group2
            // 
            this.group2.Items.Add(this.ChemSketch_btn);
            this.group2.Label = "ChemSketch";
            this.group2.Name = "group2";
            // 
            // ChemSketch_btn
            // 
            this.ChemSketch_btn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ChemSketch_btn.Image = ((System.Drawing.Image)(resources.GetObject("ChemSketch_btn.Image")));
            this.ChemSketch_btn.Label = "Åben ChemSketch";
            this.ChemSketch_btn.Name = "ChemSketch_btn";
            this.ChemSketch_btn.ShowImage = true;
            this.ChemSketch_btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click_2);
            // 
            // Download
            // 
            this.Download.Items.Add(this.Download_btn);
            this.Download.Label = "Download";
            this.Download.Name = "Download";
            // 
            // Download_btn
            // 
            this.Download_btn.Label = "Download til Excel";
            this.Download_btn.Name = "Download_btn";
            this.Download_btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.Spørgsmålslaver);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.Spørgsmålslaver.ResumeLayout(false);
            this.Spørgsmålslaver.PerformLayout();
            this.spoergsmaal_grp.ResumeLayout(false);
            this.spoergsmaal_grp.PerformLayout();
            this.Session_grp.ResumeLayout(false);
            this.Session_grp.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.Download.ResumeLayout(false);
            this.Download.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Spørgsmålslaver;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup spoergsmaal_grp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Administrer_btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Opret_btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Session_grp;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu LavLink_menu;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton StartStopSession_btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ChemSketch_btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BRbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TRbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BLbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TLbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Download;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Download_btn;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
