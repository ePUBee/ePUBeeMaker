namespace ePUBee
{
    partial class About
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
            this.btnOk = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblsoft = new System.Windows.Forms.Label();
            this.lbllicense = new System.Windows.Forms.Label();
            this.lblauthor = new System.Windows.Forms.Label();
            this.lblwebsite = new System.Windows.Forms.Label();
            this.lblcontact = new System.Windows.Forms.Label();
            this.linkLabelwebsite_value = new System.Windows.Forms.LinkLabel();
            this.lbllicense_value = new System.Windows.Forms.Label();
            this.lblcontact_value = new System.Windows.Forms.Label();
            this.lblauthor_value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(257, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ePUBee.Properties.Resources.about_we1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblsoft
            // 
            this.lblsoft.AutoSize = true;
            this.lblsoft.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsoft.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblsoft.Location = new System.Drawing.Point(92, 28);
            this.lblsoft.Name = "lblsoft";
            this.lblsoft.Size = new System.Drawing.Size(116, 16);
            this.lblsoft.TabIndex = 1;
            this.lblsoft.Text = "ePUBee Maker";
            // 
            // lbllicense
            // 
            this.lbllicense.Location = new System.Drawing.Point(80, 71);
            this.lbllicense.Name = "lbllicense";
            this.lbllicense.Size = new System.Drawing.Size(72, 14);
            this.lbllicense.TabIndex = 2;
            this.lbllicense.Text = "License:";
            this.lbllicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblauthor
            // 
            //this.lblauthor.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblauthor.Location = new System.Drawing.Point(80, 93);
            this.lblauthor.Name = "lblauthor";
            this.lblauthor.Size = new System.Drawing.Size(72, 14);
            this.lblauthor.TabIndex = 3;
            this.lblauthor.Text = "Author:";
            this.lblauthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblwebsite
            // 
            this.lblwebsite.Location = new System.Drawing.Point(80, 114);
            this.lblwebsite.Name = "lblwebsite";
            this.lblwebsite.Size = new System.Drawing.Size(72, 14);
            this.lblwebsite.TabIndex = 4;
            this.lblwebsite.Text = "Website:";
            this.lblwebsite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblcontact
            // 
            this.lblcontact.Location = new System.Drawing.Point(80, 137);
            this.lblcontact.Name = "lblcontact";
            this.lblcontact.Size = new System.Drawing.Size(72, 14);
            this.lblcontact.TabIndex = 5;
            this.lblcontact.Text = "Contact: ";
            this.lblcontact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabelwebsite_value
            // 
            this.linkLabelwebsite_value.AutoSize = true;
            this.linkLabelwebsite_value.Location = new System.Drawing.Point(158, 114);
            this.linkLabelwebsite_value.Name = "linkLabelwebsite_value";
            this.linkLabelwebsite_value.Size = new System.Drawing.Size(107, 12);
            this.linkLabelwebsite_value.TabIndex = 11;
            this.linkLabelwebsite_value.TabStop = true;
            this.linkLabelwebsite_value.Text = "http://epubee.com";
            this.linkLabelwebsite_value.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbllicense_value
            // 
            this.lbllicense_value.AutoSize = true;
            this.lbllicense_value.Location = new System.Drawing.Point(158, 71);
            this.lbllicense_value.Name = "lbllicense_value";
            this.lbllicense_value.Size = new System.Drawing.Size(179, 12);
            this.lbllicense_value.TabIndex = 12;
            this.lbllicense_value.Text = "GNU General Public License v3";
            // 
            // lblcontact_value
            // 
            this.lblcontact_value.AutoSize = true;
            this.lblcontact_value.Location = new System.Drawing.Point(158, 137);
            this.lblcontact_value.Name = "lblcontact_value";
            this.lblcontact_value.Size = new System.Drawing.Size(113, 12);
            this.lblcontact_value.TabIndex = 13;
            this.lblcontact_value.Text = "support@epubee.com";
            // 
            // lblauthor_value
            // 
            this.lblauthor_value.AutoSize = true;
            this.lblauthor_value.Location = new System.Drawing.Point(158, 93);
            this.lblauthor_value.Name = "lblauthor_value";
            this.lblauthor_value.Size = new System.Drawing.Size(41, 12);
            this.lblauthor_value.TabIndex = 14;
            this.lblauthor_value.Text = "ePUBee";
            // 
            // AboutWe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 211);
            this.Controls.Add(this.lblauthor_value);
            this.Controls.Add(this.lblcontact_value);
            this.Controls.Add(this.lbllicense_value);
            this.Controls.Add(this.linkLabelwebsite_value);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblcontact);
            this.Controls.Add(this.lblwebsite);
            this.Controls.Add(this.lblauthor);
            this.Controls.Add(this.lbllicense);
            this.Controls.Add(this.lblsoft);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutWe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About us";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private void _translate()
        {
            this.Text = Resources.Resource.aboutus;
            this.lblwebsite.Text = Resources.Resource.website + ":";
            this.lbllicense.Text = Resources.Resource.license + ":";
            this.lblauthor.Text = Resources.Resource.author + ":";
            this.lblcontact.Text = Resources.Resource.contact + ":";
            this.btnOk.Text = Resources.Resource.ok;
            this.lblsoft.Text = "ePUBee " + Resources.Resource.maker + " v" + System.Configuration.ConfigurationSettings.AppSettings["version"].ToString();
            //this.lblHtml.Text = "<a href='http://epubee.com'>http://epubee.com</a>";
        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblsoft;
        private System.Windows.Forms.Label lbllicense;
        private System.Windows.Forms.Label lblauthor;
        private System.Windows.Forms.Label lblwebsite;
        private System.Windows.Forms.Label lblcontact;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.LinkLabel linkLabelwebsite_value;
        private System.Windows.Forms.Label lbllicense_value;
        private System.Windows.Forms.Label lblcontact_value;
        private System.Windows.Forms.Label lblauthor_value;
    }
}