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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.box2 = this.Factory.CreateRibbonBox();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button5 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.box3 = this.Factory.CreateRibbonBox();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button7 = this.Factory.CreateRibbonButton();
            this.button8 = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.box4 = this.Factory.CreateRibbonBox();
            this.button9 = this.Factory.CreateRibbonButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.button10 = this.Factory.CreateRibbonButton();
            this.button12 = this.Factory.CreateRibbonButton();
            this.button11 = this.Factory.CreateRibbonButton();
            this.group6 = this.Factory.CreateRibbonGroup();
            this.box5 = this.Factory.CreateRibbonBox();
            this.button13 = this.Factory.CreateRibbonButton();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.box1.SuspendLayout();
            this.group2.SuspendLayout();
            this.box2.SuspendLayout();
            this.group3.SuspendLayout();
            this.box3.SuspendLayout();
            this.group4.SuspendLayout();
            this.box4.SuspendLayout();
            this.group5.SuspendLayout();
            this.group6.SuspendLayout();
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
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Groups.Add(this.group5);
            this.tab1.Groups.Add(this.group6);
            this.tab1.Label = "ePUBee Maker";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.box1);
            this.group1.Label = "发布";
            this.group1.Name = "group1";
            // 
            // box1
            // 
            this.box1.Items.Add(this.button1);
            this.box1.Items.Add(this.button2);
            this.box1.Name = "box1";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = global::ePUBee.Properties.Resources.qpost;
            this.button1.Label = "快速发布";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button2.Image = global::ePUBee.Properties.Resources.post;
            this.button2.Label = "发布";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.box2);
            this.group2.Label = "插入";
            this.group2.Name = "group2";
            this.group2.Visible = false;
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
            this.button3.Label = "测试";
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
            // group3
            // 
            this.group3.Items.Add(this.box3);
            this.group3.Label = "关于";
            this.group3.Name = "group3";
            this.group3.Visible = false;
            // 
            // box3
            // 
            this.box3.Items.Add(this.button6);
            this.box3.Items.Add(this.button7);
            this.box3.Items.Add(this.button8);
            this.box3.Name = "box3";
            // 
            // button6
            // 
            this.button6.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button6.Image = global::ePUBee.Properties.Resources.Download1;
            this.button6.Label = "更新";
            this.button6.Name = "button6";
            this.button6.ShowImage = true;
            this.button6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button7.Image = global::ePUBee.Properties.Resources.about;
            this.button7.Label = "关于";
            this.button7.Name = "button7";
            this.button7.ShowImage = true;
            this.button7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button8.Image = global::ePUBee.Properties.Resources.pro;
            this.button8.Label = "升级为专业版";
            this.button8.Name = "button8";
            this.button8.ShowImage = true;
            this.button8.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button8_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.box4);
            this.group4.Label = "关注我们";
            this.group4.Name = "group4";
            this.group4.Visible = false;
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
            // group5
            // 
            this.group5.Items.Add(this.button10);
            this.group5.Items.Add(this.button12);
            this.group5.Items.Add(this.button11);
            this.group5.Label = "其他";
            this.group5.Name = "group5";
            // 
            // button10
            // 
            this.button10.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button10.Image = global::ePUBee.Properties.Resources.savepdf;
            this.button10.Label = "另存为PDF";
            this.button10.Name = "button10";
            this.button10.ShowImage = true;
            this.button10.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button10_Click);
            // 
            // button12
            // 
            this.button12.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button12.Image = global::ePUBee.Properties.Resources.about_we;
            this.button12.Label = "关于我们";
            this.button12.Name = "button12";
            this.button12.ShowImage = true;
            this.button12.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button11.Image = global::ePUBee.Properties.Resources.juankuan;
            this.button11.Label = "捐款";
            this.button11.Name = "button11";
            this.button11.ShowImage = true;
            this.button11.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button11_Click);
            // 
            // group6
            // 
            this.group6.Items.Add(this.box5);
            this.group6.Label = "生成EPUB文件";
            this.group6.Name = "group6";
            this.group6.Visible = false;
            // 
            // box5
            // 
            this.box5.Items.Add(this.button13);
            this.box5.Name = "box5";
            // 
            // button13
            // 
            this.button13.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button13.Image = global::ePUBee.Properties.Resources._0504317;
            this.button13.Label = "正在生成...";
            this.button13.Name = "button13";
            this.button13.ShowImage = true;
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "EPUB电子书文件|*.epub";
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.group6.ResumeLayout(false);
            this.group6.PerformLayout();
            this.box5.ResumeLayout(false);
            this.box5.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button8;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button9;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group6;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box5;
        private System.Windows.Forms.Timer timer1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button13;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button10;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button12;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button11;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
