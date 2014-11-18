
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
            this.btnRename = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBox_only = new System.Windows.Forms.CheckBox();
            this.comboBox_spliter = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSaveas = new System.Windows.Forms.Button();
            this.groupBox_output = new System.Windows.Forms.GroupBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.treeListView_Menu = new SynapticEffect.Forms.TreeListView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox_output.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(500, 12);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 0;
            this.btnRename.Text = "rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(394, 400);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(499, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox_only
            // 
            this.checkBox_only.AutoSize = true;
            this.checkBox_only.Checked = true;
            this.checkBox_only.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_only.Location = new System.Drawing.Point(28, 378);
            this.checkBox_only.Name = "checkBox_only";
            this.checkBox_only.Size = new System.Drawing.Size(114, 16);
            this.checkBox_only.TabIndex = 3;
            this.checkBox_only.Text = "Show menus only";
            this.checkBox_only.UseVisualStyleBackColor = true;
            // 
            // comboBox_spliter
            // 
            this.comboBox_spliter.FormattingEnabled = true;
            this.comboBox_spliter.Items.AddRange(new object[] {
            "<Choose the menu contains>",
            "None",
            "h1",
            "h2",
            "All"});
            this.comboBox_spliter.Location = new System.Drawing.Point(28, 400);
            this.comboBox_spliter.Name = "comboBox_spliter";
            this.comboBox_spliter.Size = new System.Drawing.Size(235, 20);
            this.comboBox_spliter.TabIndex = 5;
            this.comboBox_spliter.Text = "<Choose the menu contains>";
            // 
            // btnSaveas
            // 
            this.btnSaveas.Location = new System.Drawing.Point(400, 20);
            this.btnSaveas.Name = "btnSaveas";
            this.btnSaveas.Size = new System.Drawing.Size(75, 23);
            this.btnSaveas.TabIndex = 7;
            this.btnSaveas.Text = "Save as";
            this.btnSaveas.UseVisualStyleBackColor = true;
            this.btnSaveas.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox_output
            // 
            this.groupBox_output.Controls.Add(this.txtPath);
            this.groupBox_output.Controls.Add(this.btnSaveas);
            this.groupBox_output.Location = new System.Drawing.Point(13, 317);
            this.groupBox_output.Name = "groupBox_output";
            this.groupBox_output.Size = new System.Drawing.Size(481, 55);
            this.groupBox_output.TabIndex = 8;
            this.groupBox_output.TabStop = false;
            this.groupBox_output.Text = "Output";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(15, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(367, 21);
            this.txtPath.TabIndex = 8;
            // 
            // treeListView_Menu
            // 
            this.treeListView_Menu.BackColor = System.Drawing.SystemColors.Window;
            this.treeListView_Menu.CaptureFocusClick = true;
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
            this.treeListView_Menu.Columns.AddRange(new SynapticEffect.Forms.ToggleColumnHeader[] {
            toggleColumnHeader1,
            toggleColumnHeader2,
            toggleColumnHeader3});
            this.treeListView_Menu.ColumnSortColor = System.Drawing.Color.Gainsboro;
            this.treeListView_Menu.ColumnTrackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView_Menu.FullRowSelect = false;
            this.treeListView_Menu.GridLineColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView_Menu.HeaderMenu = null;
            this.treeListView_Menu.HideSelection = false;
            this.treeListView_Menu.ItemHeight = 20;
            this.treeListView_Menu.ItemMenu = null;
            this.treeListView_Menu.LabelEdit = true;
            this.treeListView_Menu.Location = new System.Drawing.Point(11, 12);
            this.treeListView_Menu.MouseActivte = true;
            this.treeListView_Menu.MultiSelect = true;
            this.treeListView_Menu.Name = "treeListView_Menu";
            this.treeListView_Menu.RowSelectColor = System.Drawing.SystemColors.Highlight;
            this.treeListView_Menu.RowTrackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView_Menu.Size = new System.Drawing.Size(484, 280);
            this.treeListView_Menu.SmallImageList = null;
            this.treeListView_Menu.StateImageList = null;
            this.treeListView_Menu.TabIndex = 9;
            this.treeListView_Menu.Text = "treeListView_Menu";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "EPUB file|*.epub";
            // 
            // BuildPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 435);
            this.Controls.Add(this.treeListView_Menu);
            this.Controls.Add(this.groupBox_output);
            this.Controls.Add(this.comboBox_spliter);
            this.Controls.Add(this.checkBox_only);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnRename);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildPath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Menus";
            this.Load += new System.EventHandler(this.BuildPath_Load);
            this.groupBox_output.ResumeLayout(false);
            this.groupBox_output.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void _translate() {
            this.Text = Resources.Resource.generatemenus;
            this.btnConfirm.Text = Resources.Resource.confirm;
            this.btnCancel.Text = Resources.Resource.cancel;
            this.btnRename.Text = Resources.Resource.rename;
            this.btnSaveas.Text = Resources.Resource.saveas;
            this.groupBox_output.Text = Resources.Resource.output;

            this.checkBox_only.Text = Resources.Resource.showmenusonly;

            //this.treeListView_Menu.Text = Resources.Resource.choosethemenucontains;
            this.treeListView_Menu.Columns[0].Text = Resources.Resource.title;
            this.treeListView_Menu.Columns[1].Text = Resources.Resource.contains;
            this.treeListView_Menu.Columns[2].Text = Resources.Resource.lever;

            this.comboBox_spliter.Items.Clear();
            this.comboBox_spliter.Text = "<" + Resources.Resource.choosethemenucontains + ">";
            this.comboBox_spliter.Items.AddRange(new object[] {
                 "<" + Resources.Resource.choosethemenucontains + ">", Resources.Resource.none, Resources.Resource.h1, Resources.Resource.h2,Resources.Resource.all});
            
        }
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBox_only;
        private System.Windows.Forms.ComboBox comboBox_spliter;
        private System.Windows.Forms.Button btnSaveas;
        private System.Windows.Forms.GroupBox groupBox_output;
        public System.Windows.Forms.TextBox txtPath;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private SynapticEffect.Forms.TreeListView treeListView_Menu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}