namespace TestApplication
{
    partial class PatientEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFileNumber;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.PictureBox picPatient;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnAttachImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblImageTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFileNumber = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.picPatient = new System.Windows.Forms.PictureBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnAttachImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblImageTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatient)).BeginInit();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100;

            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(390, 18);
            this.lblTitle.Size = new System.Drawing.Size(470, 38);
            this.lblTitle.Text = "پرونده بیمار";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(390, 60);
            this.lblSubtitle.Size = new System.Drawing.Size(470, 24);
            this.lblSubtitle.Text = "اطلاعات بیمار";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblImageTitle);
            this.pnlForm.Controls.Add(this.btnAttachImage);
            this.pnlForm.Controls.Add(this.txtImagePath);
            this.pnlForm.Controls.Add(this.picPatient);
            this.pnlForm.Controls.Add(this.txtMobile);
            this.pnlForm.Controls.Add(this.txtFileNumber);
            this.pnlForm.Controls.Add(this.txtLastName);
            this.pnlForm.Controls.Add(this.txtFirstName);
            this.pnlForm.Controls.Add(this.lblMobile);
            this.pnlForm.Controls.Add(this.lblFileNumber);
            this.pnlForm.Controls.Add(this.lblLastName);
            this.pnlForm.Controls.Add(this.lblFirstName);
            this.pnlForm.Location = new System.Drawing.Point(28, 128);
            this.pnlForm.Size = new System.Drawing.Size(832, 360);

            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFirstName.Location = new System.Drawing.Point(610, 36);
            this.lblFirstName.Size = new System.Drawing.Size(180, 24);
            this.lblFirstName.Text = "نام";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(425, 64);
            this.txtFirstName.Size = new System.Drawing.Size(365, 28);

            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblLastName.Location = new System.Drawing.Point(610, 108);
            this.lblLastName.Size = new System.Drawing.Size(180, 24);
            this.lblLastName.Text = "نام خانوادگی";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLastName.Location = new System.Drawing.Point(425, 136);
            this.txtLastName.Size = new System.Drawing.Size(365, 28);

            this.lblFileNumber.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFileNumber.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFileNumber.Location = new System.Drawing.Point(610, 180);
            this.lblFileNumber.Size = new System.Drawing.Size(180, 24);
            this.lblFileNumber.Text = "شماره پرونده";
            this.lblFileNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtFileNumber.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFileNumber.Location = new System.Drawing.Point(425, 208);
            this.txtFileNumber.Size = new System.Drawing.Size(365, 28);

            this.lblMobile.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMobile.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblMobile.Location = new System.Drawing.Point(610, 252);
            this.lblMobile.Size = new System.Drawing.Size(180, 24);
            this.lblMobile.Text = "شماره موبایل";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobile.Location = new System.Drawing.Point(425, 280);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.Size = new System.Drawing.Size(365, 28);

            this.lblImageTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblImageTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblImageTitle.Location = new System.Drawing.Point(32, 22);
            this.lblImageTitle.Size = new System.Drawing.Size(340, 30);
            this.lblImageTitle.Text = "تصویر بیمار";
            this.lblImageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.picPatient.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.picPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPatient.Location = new System.Drawing.Point(65, 60);
            this.picPatient.Size = new System.Drawing.Size(274, 196);
            this.picPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.txtImagePath.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtImagePath.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.txtImagePath.Location = new System.Drawing.Point(65, 268);
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(274, 25);
            this.txtImagePath.Text = "تصویری انتخاب نشده است";

            this.btnAttachImage.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.btnAttachImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(199, 210, 254);
            this.btnAttachImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachImage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnAttachImage.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnAttachImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttachImage.Location = new System.Drawing.Point(65, 304);
            this.btnAttachImage.Size = new System.Drawing.Size(274, 42);
            this.btnAttachImage.Text = "  انتخاب / تغییر تصویر";
            this.btnAttachImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttachImage.UseVisualStyleBackColor = false;
            this.btnAttachImage.Click += new System.EventHandler(this.btnAttachImage_Click);

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(650, 516);
            this.btnSave.Size = new System.Drawing.Size(210, 52);
            this.btnSave.Text = "  ذخیره اطلاعات";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnCancel.Location = new System.Drawing.Point(494, 516);
            this.btnCancel.Size = new System.Drawing.Size(140, 52);
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = false;

            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(888, 596);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientEditForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "پرونده بیمار";
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatient)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
