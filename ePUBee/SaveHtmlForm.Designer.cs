namespace ePUBee
{
    partial class SaveHtmlForm
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
            this.btnOtherFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.openFileDialog_browseCover = new System.Windows.Forms.OpenFileDialog();
            this.listBox_Menu = new System.Windows.Forms.ListBox();
            this.lblselect = new System.Windows.Forms.Label();
            this.listView_Sources = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOtherFile
            // 
            this.btnOtherFile.Location = new System.Drawing.Point(586, 12);
            this.btnOtherFile.Name = "btnOtherFile";
            this.btnOtherFile.Size = new System.Drawing.Size(85, 21);
            this.btnOtherFile.TabIndex = 7;
            this.btnOtherFile.Text = "Other file";
            this.btnOtherFile.UseVisualStyleBackColor = true;
            this.btnOtherFile.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(195, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 21);
            this.textBox1.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(556, 624);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(445, 624);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Confirm";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog_browseCover
            // 
            this.openFileDialog_browseCover.Filter = "All|*.*|GIF file|*.gif|JPEG file|*.jpg|PNG file|*.png";
            // 
            // listBox_Menu
            // 
            this.listBox_Menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Menu.FormattingEnabled = true;
            this.listBox_Menu.ItemHeight = 12;
            this.listBox_Menu.Items.AddRange(new object[] {
            "All",
            "Image",
            "Video",
            "Audio"});
            this.listBox_Menu.Location = new System.Drawing.Point(13, 12);
            this.listBox_Menu.Name = "listBox_Menu";
            this.listBox_Menu.Size = new System.Drawing.Size(120, 566);
            this.listBox_Menu.TabIndex = 8;
            this.listBox_Menu.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblselect
            // 
            this.lblselect.AutoSize = true;
            this.lblselect.Location = new System.Drawing.Point(148, 18);
            this.lblselect.Name = "lblselect";
            this.lblselect.Size = new System.Drawing.Size(47, 12);
            this.lblselect.TabIndex = 10;
            this.lblselect.Text = "Select:";
            // 
            // listView_Sources
            // 
            this.listView_Sources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_Sources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView_Sources.Location = new System.Drawing.Point(139, 52);
            this.listView_Sources.Name = "listView_Sources";
            this.listView_Sources.Size = new System.Drawing.Size(121, 528);
            this.listView_Sources.TabIndex = 11;
            this.listView_Sources.UseCompatibleStateImageBehavior = false;
            this.listView_Sources.View = System.Windows.Forms.View.Details;
            this.listView_Sources.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "files in the book";
            this.columnHeader1.Width = 117;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(272, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 528);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // SaveHtmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 659);
            this.Controls.Add(this.listView_Sources);
            this.Controls.Add(this.lblselect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox_Menu);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnOtherFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveHtmlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Cover";
            this.Load += new System.EventHandler(this.SaveHtmlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private void _translate() {
            this.Text = Resources.Resource.selectcover;
            this.lblselect.Text = Resources.Resource.select;
            this.btnOtherFile.Text = Resources.Resource.otherfile;
            this.btnOK.Text = Resources.Resource.confirm;
            this.btnCancel.Text = Resources.Resource.cancel;
            this.columnHeader1.Text = Resources.Resource.filesinthebook;
            
            this.listBox_Menu.Items.Clear();
            this.listBox_Menu.Items.AddRange(new object[] {
            Resources.Resource.all, Resources.Resource.image, Resources.Resource.video, Resources.Resource.audio});





        }
        private System.Windows.Forms.Button btnOtherFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_browseCover;
        public System.Windows.Forms.ListBox listBox_Menu;
        private System.Windows.Forms.Label lblselect;
        private System.Windows.Forms.ListView listView_Sources;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}