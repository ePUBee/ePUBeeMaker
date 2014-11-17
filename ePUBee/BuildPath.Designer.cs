
namespace ePUBee
{

    partial class BuildPath
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SynapticEffect.Forms.ToggleColumnHeader toggleColumnHeader1 = new SynapticEffect.Forms.ToggleColumnHeader();
            SynapticEffect.Forms.ToggleColumnHeader toggleColumnHeader2 = new SynapticEffect.Forms.ToggleColumnHeader();
            SynapticEffect.Forms.ToggleColumnHeader toggleColumnHeader3 = new SynapticEffect.Forms.ToggleColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.treeListView1 = new SynapticEffect.Forms.TreeListView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "rename";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(394, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(499, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(28, 378);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Show menus only";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "<Choose the menu contains>",
            "None",
            "h1",
            "h2",
            "All"});
            this.comboBox1.Location = new System.Drawing.Point(28, 400);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "<Choose the menu contains>";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(400, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Save as";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(13, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 55);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 21);
            this.textBox1.TabIndex = 8;
            // 
            // treeListView1
            // 
            this.treeListView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeListView1.CaptureFocusClick = true;
            toggleColumnHeader1.Hovered = false;
            toggleColumnHeader1.Image = null;
            toggleColumnHeader1.Index = 0;
            toggleColumnHeader1.Pressed = false;
            toggleColumnHeader1.ScaleStyle = SynapticEffect.Forms.ColumnScaleStyle.Slide;
            toggleColumnHeader1.Selected = false;
            toggleColumnHeader1.Text = "title";
            toggleColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toggleColumnHeader1.Visible = true;
            toggleColumnHeader1.Width = 300;
            toggleColumnHeader2.Hovered = false;
            toggleColumnHeader2.Image = null;
            toggleColumnHeader2.Index = 0;
            toggleColumnHeader2.Pressed = false;
            toggleColumnHeader2.ScaleStyle = SynapticEffect.Forms.ColumnScaleStyle.Spring;
            toggleColumnHeader2.Selected = false;
            toggleColumnHeader2.Text = "contains";
            toggleColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toggleColumnHeader2.Visible = true;
            toggleColumnHeader3.Hovered = false;
            toggleColumnHeader3.Image = null;
            toggleColumnHeader3.Index = 0;
            toggleColumnHeader3.Pressed = false;
            toggleColumnHeader3.ScaleStyle = SynapticEffect.Forms.ColumnScaleStyle.Slide;
            toggleColumnHeader3.Selected = false;
            toggleColumnHeader3.Text = "lever";
            toggleColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toggleColumnHeader3.Visible = true;
            this.treeListView1.Columns.AddRange(new SynapticEffect.Forms.ToggleColumnHeader[] {
            toggleColumnHeader1,
            toggleColumnHeader2,
            toggleColumnHeader3});
            this.treeListView1.ColumnSortColor = System.Drawing.Color.Gainsboro;
            this.treeListView1.ColumnTrackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView1.FullRowSelect = false;
            this.treeListView1.GridLineColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView1.HeaderMenu = null;
            this.treeListView1.HideSelection = false;
            this.treeListView1.ItemHeight = 20;
            this.treeListView1.ItemMenu = null;
            this.treeListView1.LabelEdit = true;
            this.treeListView1.Location = new System.Drawing.Point(13, 12);
            this.treeListView1.MouseActivte = true;
            this.treeListView1.MultiSelect = true;
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.RowSelectColor = System.Drawing.SystemColors.Highlight;
            this.treeListView1.RowTrackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView1.Size = new System.Drawing.Size(481, 280);
            this.treeListView1.SmallImageList = null;
            this.treeListView1.StateImageList = null;
            this.treeListView1.TabIndex = 9;
            this.treeListView1.Text = "treeListView1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "EPUB 文件|*.epub";
            // 
            // BuildPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 435);
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildPath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Menus";
            this.Load += new System.EventHandler(this.BuildPath_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private SynapticEffect.Forms.TreeListView treeListView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}