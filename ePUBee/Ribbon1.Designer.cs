namespace ePUBee
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon1));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.groupInsert = this.Factory.CreateRibbonGroup();
            this.box2 = this.Factory.CreateRibbonBox();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button5 = this.Factory.CreateRibbonButton();
            this.groupAbout = this.Factory.CreateRibbonGroup();
            this.box3 = this.Factory.CreateRibbonBox();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button7 = this.Factory.CreateRibbonButton();
            this.groupAboutus = this.Factory.CreateRibbonGroup();
            this.box4 = this.Factory.CreateRibbonBox();
            this.button9 = this.Factory.CreateRibbonButton();
            this.groupPubhish = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.btnQuickPublish = this.Factory.CreateRibbonButton();
            this.btnPublish = this.Factory.CreateRibbonButton();
            this.groupOthers = this.Factory.CreateRibbonGroup();
            this.btnSaveAsPDF = this.Factory.CreateRibbonButton();
            this.btnAboutus = this.Factory.CreateRibbonButton();
            this.btnDonate = this.Factory.CreateRibbonButton();
            this.groupProcessing = this.Factory.CreateRibbonGroup();
            this.box5 = this.Factory.CreateRibbonBox();
            this.btnProcessing = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.groupInsert.SuspendLayout();
            this.box2.SuspendLayout();
            this.groupAbout.SuspendLayout();
            this.box3.SuspendLayout();
            this.groupAboutus.SuspendLayout();
            this.box4.SuspendLayout();
            this.groupPubhish.SuspendLayout();
            this.box1.SuspendLayout();
            this.groupOthers.SuspendLayout();
            this.groupProcessing.SuspendLayout();
            this.box5.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "PDF|*.pdf";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "EPUB files|*.epub";
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.groupInsert);
            this.tab1.Groups.Add(this.groupAbout);
            this.tab1.Groups.Add(this.groupAboutus);
            this.tab1.Groups.Add(this.groupPubhish);
            this.tab1.Groups.Add(this.groupOthers);
            this.tab1.Groups.Add(this.groupProcessing);
            this.tab1.Label = "ePUBee Maker";
            this.tab1.Name = "tab1";
            // 
            // groupInsert
            // 
            this.groupInsert.Items.Add(this.box2);
            this.groupInsert.Label = "Insert";
            this.groupInsert.Name = "groupInsert";
            this.groupInsert.Visible = false;
            // 
            // box2
            // 
            this.box2.Items.Add(this.button3);
            this.box2.Items.Add(this.button4);
            this.box2.Items.Add(this.button5);
            this.box2.Name = "box2";
            // 
            // button3
            // 
            this.button3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button3.Image = global::ePUBee.Properties.Resources.test;
            this.button3.Label = "Test";
            this.button3.Name = "button3";
            this.button3.ShowImage = true;
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button4.Image = global::ePUBee.Properties.Resources.flash;
            this.button4.Label = "Flash";
            this.button4.Name = "button4";
            this.button4.ShowImage = true;
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button5.Image = global::ePUBee.Properties.Resources.youtube;
            this.button5.Label = "You Tube";
            this.button5.Name = "button5";
            this.button5.ShowImage = true;
            this.button5.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button5_Click);
            // 
            // groupAbout
            // 
            this.groupAbout.Items.Add(this.box3);
            this.groupAbout.Label = "About";
            this.groupAbout.Name = "groupAbout";
            this.groupAbout.Visible = false;
            // 
            // box3
            // 
            this.box3.Items.Add(this.button6);
            this.box3.Items.Add(this.button7);
            this.box3.Name = "box3";
            // 
            // button6
            // 
            this.button6.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button6.Image = global::ePUBee.Properties.Resources.Download1;
            this.button6.Label = "Update";
            this.button6.Name = "button6";
            this.button6.ShowImage = true;
            this.button6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button7.Image = global::ePUBee.Properties.Resources.about;
            this.button7.Label = "About";
            this.button7.Name = "button7";
            this.button7.ShowImage = true;
            this.button7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button7_Click);
            // 
            // groupAboutus
            // 
            this.groupAboutus.Items.Add(this.box4);
            this.groupAboutus.Label = "About us";
            this.groupAboutus.Name = "groupAboutus";
            this.groupAboutus.Visible = false;
            // 
            // box4
            // 
            this.box4.Items.Add(this.button9);
            this.box4.Name = "box4";
            // 
            // button9
            // 
            this.button9.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button9.Image = global::ePUBee.Properties.Resources.facebook;
            this.button9.Label = "FaceBook";
            this.button9.Name = "button9";
            this.button9.ShowImage = true;
            this.button9.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button9_Click);
            // 
            // groupPubhish
            // 
            this.groupPubhish.Items.Add(this.box1);
            this.groupPubhish.Label = "Publish";
            this.groupPubhish.Name = "groupPubhish";
            // 
            // box1
            // 
            this.box1.Items.Add(this.btnQuickPublish);
            this.box1.Items.Add(this.btnPublish);
            this.box1.Name = "box1";
            // 
            // btnQuickPublish
            // 
            this.btnQuickPublish.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnQuickPublish.Image = global::ePUBee.Properties.Resources.qpost;
            this.btnQuickPublish.Label = "Quick publish";
            this.btnQuickPublish.Name = "btnQuickPublish";
            this.btnQuickPublish.ShowImage = true;
            this.btnQuickPublish.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnPublish.Image = global::ePUBee.Properties.Resources.post;
            this.btnPublish.Label = "Publish";
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.ShowImage = true;
            this.btnPublish.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // groupOthers
            // 
            this.groupOthers.Items.Add(this.btnSaveAsPDF);
            this.groupOthers.Items.Add(this.btnAboutus);
            this.groupOthers.Items.Add(this.btnDonate);
            this.groupOthers.Label = "Others";
            this.groupOthers.Name = "groupOthers";
            // 
            // btnSaveAsPDF
            // 
            this.btnSaveAsPDF.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSaveAsPDF.Image = global::ePUBee.Properties.Resources.savepdf;
            this.btnSaveAsPDF.Label = "SaveAs PDF";
            this.btnSaveAsPDF.Name = "btnSaveAsPDF";
            this.btnSaveAsPDF.ShowImage = true;
            this.btnSaveAsPDF.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button10_Click);
            // 
            // btnAboutus
            // 
            this.btnAboutus.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAboutus.Image = global::ePUBee.Properties.Resources.about_we1;
            this.btnAboutus.Label = "About us";
            this.btnAboutus.Name = "btnAboutus";
            this.btnAboutus.ShowImage = true;
            this.btnAboutus.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button12_Click);
            // 
            // btnDonate
            // 
            this.btnDonate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDonate.Image = global::ePUBee.Properties.Resources.juankuan;
            this.btnDonate.Label = "Donate";
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.ShowImage = true;
            this.btnDonate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button11_Click);
            // 
            // groupProcessing
            // 
            this.groupProcessing.Items.Add(this.box5);
            this.groupProcessing.Label = "Publishing";
            this.groupProcessing.Name = "groupProcessing";
            this.groupProcessing.Visible = false;
            // 
            // box5
            // 
            this.box5.Items.Add(this.btnProcessing);
            this.box5.Name = "box5";
            // 
            // btnProcessing
            // 
            this.btnProcessing.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            //this.btnProcessing.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessing.Image")));
            this.btnProcessing.Image = global::ePUBee.Properties.Resources._0504317;
            this.btnProcessing.Label = "Processing...";
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.ShowImage = true;
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.groupInsert.ResumeLayout(false);
            this.groupInsert.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.groupAbout.ResumeLayout(false);
            this.groupAbout.PerformLayout();
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.groupAboutus.ResumeLayout(false);
            this.groupAboutus.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.groupPubhish.ResumeLayout(false);
            this.groupPubhish.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.groupOthers.ResumeLayout(false);
            this.groupOthers.PerformLayout();
            this.groupProcessing.ResumeLayout(false);
            this.groupProcessing.PerformLayout();
            this.box5.ResumeLayout(false);
            this.box5.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupPubhish;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupInsert;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupAbout;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupAboutus;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button9;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupProcessing;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box5;
        private System.Windows.Forms.Timer timer1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnProcessing;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupOthers;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveAsPDF;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAboutus;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDonate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnQuickPublish;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPublish;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
