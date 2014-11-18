namespace ePUBee
{
    partial class MetaEdit
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
            this.title = new System.Windows.Forms.TextBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.TextBox();
            this.lblauthor = new System.Windows.Forms.Label();
            this.lblsaveas = new System.Windows.Forms.Label();
            this.fileas = new System.Windows.Forms.TextBox();
            this.lbllanguage = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnaddbasic = new System.Windows.Forms.Button();
            this.btnaddroles = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btncopy = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(69, 30);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(595, 21);
            this.title.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Location = new System.Drawing.Point(-3, 30);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(72, 14);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "Title:";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Author
            // 
            this.Author.Location = new System.Drawing.Point(69, 57);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(279, 21);
            this.Author.TabIndex = 2;
            // 
            // lblauthor
            // 
            this.lblauthor.Location = new System.Drawing.Point(-3, 57);
            this.lblauthor.Name = "lblauthor";
            this.lblauthor.Size = new System.Drawing.Size(72, 14);
            this.lblauthor.TabIndex = 3;
            this.lblauthor.Text = "Author:";
            this.lblauthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblsaveas
            // 
            this.lblsaveas.AutoSize = true;
            this.lblsaveas.Location = new System.Drawing.Point(366, 60);
            this.lblsaveas.Name = "lblsaveas";
            this.lblsaveas.Size = new System.Drawing.Size(53, 12);
            this.lblsaveas.TabIndex = 5;
            this.lblsaveas.Text = "Save as:";
            this.lblsaveas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fileas
            // 
            this.fileas.Location = new System.Drawing.Point(425, 57);
            this.fileas.Name = "fileas";
            this.fileas.Size = new System.Drawing.Size(239, 21);
            this.fileas.TabIndex = 4;
            // 
            // lbllanguage
            // 
            this.lbllanguage.Location = new System.Drawing.Point(-3, 84);
            this.lbllanguage.Name = "lbllanguage";
            this.lbllanguage.Size = new System.Drawing.Size(72, 14);
            this.lbllanguage.TabIndex = 6;
            this.lbllanguage.Text = "Language:";
            this.lbllanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Language
            // 
            this.Language.FormattingEnabled = true;
            this.Language.Location = new System.Drawing.Point(69, 84);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(595, 20);
            this.Language.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(24, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(551, 287);
            this.dataGridView1.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Key";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "File As";
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Roles";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // btnaddbasic
            // 
            this.btnaddbasic.Location = new System.Drawing.Point(589, 110);
            this.btnaddbasic.Name = "btnaddbasic";
            this.btnaddbasic.Size = new System.Drawing.Size(75, 23);
            this.btnaddbasic.TabIndex = 9;
            this.btnaddbasic.Text = "Add basic";
            this.btnaddbasic.UseVisualStyleBackColor = true;
            this.btnaddbasic.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnaddroles
            // 
            this.btnaddroles.Location = new System.Drawing.Point(589, 139);
            this.btnaddroles.Name = "btnaddroles";
            this.btnaddroles.Size = new System.Drawing.Size(75, 23);
            this.btnaddroles.TabIndex = 10;
            this.btnaddroles.Text = "Add roles";
            this.btnaddroles.UseVisualStyleBackColor = true;
            this.btnaddroles.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(589, 224);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // btncopy
            // 
            this.btncopy.Location = new System.Drawing.Point(589, 195);
            this.btncopy.Name = "btncopy";
            this.btncopy.Size = new System.Drawing.Size(75, 23);
            this.btncopy.TabIndex = 11;
            this.btncopy.Text = "Copy";
            this.btncopy.UseVisualStyleBackColor = true;
            this.btncopy.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button5.Location = new System.Drawing.Point(589, 278);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "t";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button6.Location = new System.Drawing.Point(631, 278);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(33, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "u";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(490, 406);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(589, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button8_Click);
            // 
            // MetaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 441);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btncopy);
            this.Controls.Add(this.btnaddroles);
            this.Controls.Add(this.btnaddbasic);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.lbllanguage);
            this.Controls.Add(this.lblsaveas);
            this.Controls.Add(this.fileas);
            this.Controls.Add(this.lblauthor);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.title);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MetaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Metas";
            this.Load += new System.EventHandler(this.MetaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void _translate() {
            this.Text = Resources.Resource.editmetas;
            this.lbltitle.Text = Resources.Resource.title + ":";
            this.lblsaveas.Text = Resources.Resource.saveas + ":";
            this.lbllanguage.Text = Resources.Resource.language + ":";
            this.lblauthor.Text = Resources.Resource.author + ":";
            this.btnaddbasic.Text = Resources.Resource.addbasic;
            this.btnaddroles.Text = Resources.Resource.addroles;
            this.btncopy.Text = Resources.Resource.copy;
            this.btnDelete.Text = Resources.Resource.delete;
            this.btnConfirm.Text = Resources.Resource.confirm;
            this.btnCancel.Text = Resources.Resource.cancel;

            this.Column1.HeaderText = Resources.Resource.key;
            this.Column2.HeaderText = Resources.Resource.value;
            this.Column3.HeaderText = Resources.Resource.fileas;
            this.Column4.HeaderText = Resources.Resource.roles;

        }
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TextBox Author;
        private System.Windows.Forms.Label lblauthor;
        private System.Windows.Forms.Label lblsaveas;
        private System.Windows.Forms.TextBox fileas;
        private System.Windows.Forms.Label lbllanguage;
        private System.Windows.Forms.ComboBox Language;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnaddbasic;
        private System.Windows.Forms.Button btnaddroles;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btncopy;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}