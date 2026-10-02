namespace TestApplication
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFileNumber;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnAttachImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picPatientImage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFileNumber = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnAttachImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picPatientImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPatientImage)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(730, 40);
            this.lblTitle.Text = "تشکیل پرونده بیمار";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFirstName.Location = new System.Drawing.Point(560, 85);
            this.lblFirstName.Size = new System.Drawing.Size(170, 25);
            this.lblFirstName.Text = "نام";

            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(330, 82);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(220, 28);
            this.txtFirstName.TabIndex = 0;

            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblLastName.Location = new System.Drawing.Point(560, 125);
            this.lblLastName.Size = new System.Drawing.Size(170, 25);
            this.lblLastName.Text = "نام خانوادگی";

            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLastName.Location = new System.Drawing.Point(330, 122);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(220, 28);
            this.txtLastName.TabIndex = 1;

            this.lblFileNumber.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileNumber.Location = new System.Drawing.Point(560, 165);
            this.lblFileNumber.Size = new System.Drawing.Size(170, 25);
            this.lblFileNumber.Text = "شماره پرونده";

            this.txtFileNumber.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFileNumber.Location = new System.Drawing.Point(330, 162);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Size = new System.Drawing.Size(220, 28);
            this.txtFileNumber.TabIndex = 2;

            this.lblMobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblMobile.Location = new System.Drawing.Point(560, 205);
            this.lblMobile.Size = new System.Drawing.Size(170, 25);
            this.lblMobile.Text = "شماره موبایل";

            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobile.Location = new System.Drawing.Point(330, 202);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(220, 28);
            this.txtMobile.TabIndex = 3;

            this.lblImage.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblImage.Location = new System.Drawing.Point(560, 248);
            this.lblImage.Size = new System.Drawing.Size(170, 25);
            this.lblImage.Text = "تصویر ضمیمه";

            this.txtImagePath.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtImagePath.Location = new System.Drawing.Point(330, 245);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(220, 26);
            this.txtImagePath.TabStop = false;

            this.btnAttachImage.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAttachImage.Location = new System.Drawing.Point(330, 282);
            this.btnAttachImage.Name = "btnAttachImage";
            this.btnAttachImage.Size = new System.Drawing.Size(220, 36);
            this.btnAttachImage.TabIndex = 4;
            this.btnAttachImage.Text = "Attach / انتخاب تصویر";
            this.btnAttachImage.UseVisualStyleBackColor = true;
            this.btnAttachImage.Click += new System.EventHandler(this.btnAttachImage_Click);

            this.picPatientImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPatientImage.Location = new System.Drawing.Point(35, 82);
            this.picPatientImage.Name = "picPatientImage";
            this.picPatientImage.Size = new System.Drawing.Size(250, 236);
            this.picPatientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPatientImage.TabStop = false;

            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(330, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(220, 50);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "ذخیره پرونده";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 430);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picPatientImage);
            this.Controls.Add(this.btnAttachImage);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtFileNumber);
            this.Controls.Add(this.lblFileNumber);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پرونده بیمار";

            ((System.ComponentModel.ISupportInitialize)(this.picPatientImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
