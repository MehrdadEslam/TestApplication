namespace TestApplication
{
    partial class PatientEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHeaderAccent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFatherName;
        private System.Windows.Forms.Label lblFileNumber;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblRequired1;
        private System.Windows.Forms.Label lblRequired2;
        private System.Windows.Forms.Label lblRequired3;
        private System.Windows.Forms.Label lblRequired4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.PictureBox picPatient;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnAttachImage;
        private System.Windows.Forms.Button btnCropCurrent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblImageTitle;
        private System.Windows.Forms.Label lblImageHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderAccent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFatherName = new System.Windows.Forms.Label();
            this.lblFileNumber = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblRequired1 = new System.Windows.Forms.Label();
            this.lblRequired2 = new System.Windows.Forms.Label();
            this.lblRequired3 = new System.Windows.Forms.Label();
            this.lblRequired4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.picPatient = new System.Windows.Forms.PictureBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnAttachImage = new System.Windows.Forms.Button();
            this.btnCropCurrent = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblImageTitle = new System.Windows.Forms.Label();
            this.lblImageHint = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatient)).BeginInit();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlHeader.Controls.Add(this.pnlHeaderAccent);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 78;

            this.pnlHeaderAccent.BackColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.pnlHeaderAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderAccent.Height = 4;

            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 8);
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitle.Size = new System.Drawing.Size(876, 32);
            this.lblTitle.Text = "ایجاد پرونده بیمار";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.lblSubtitle.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSubtitle.Size = new System.Drawing.Size(876, 22);
            this.lblSubtitle.Text = "اطلاعات پرونده را تکمیل کنید؛ نام پدر اختیاری است.";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblImageHint);
            this.pnlForm.Controls.Add(this.lblImageTitle);
            this.pnlForm.Controls.Add(this.btnCropCurrent);
            this.pnlForm.Controls.Add(this.btnAttachImage);
            this.pnlForm.Controls.Add(this.txtImagePath);
            this.pnlForm.Controls.Add(this.picPatient);
            this.pnlForm.Controls.Add(this.lblRequired4);
            this.pnlForm.Controls.Add(this.lblRequired3);
            this.pnlForm.Controls.Add(this.lblRequired2);
            this.pnlForm.Controls.Add(this.lblRequired1);
            this.pnlForm.Controls.Add(this.txtMobile);
            this.pnlForm.Controls.Add(this.txtFileNumber);
            this.pnlForm.Controls.Add(this.txtFatherName);
            this.pnlForm.Controls.Add(this.txtLastName);
            this.pnlForm.Controls.Add(this.txtFirstName);
            this.pnlForm.Controls.Add(this.lblMobile);
            this.pnlForm.Controls.Add(this.lblFileNumber);
            this.pnlForm.Controls.Add(this.lblFatherName);
            this.pnlForm.Controls.Add(this.lblLastName);
            this.pnlForm.Controls.Add(this.lblFirstName);
            this.pnlForm.Location = new System.Drawing.Point(24, 100);
            this.pnlForm.Size = new System.Drawing.Size(876, 414);

            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblFirstName.Location = new System.Drawing.Point(720, 92);
            this.lblFirstName.Size = new System.Drawing.Size(115, 28);
            this.lblFirstName.Text = "نام :";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblLastName.Font = this.lblFirstName.Font;
            this.lblLastName.ForeColor = this.lblFirstName.ForeColor;
            this.lblLastName.Location = new System.Drawing.Point(690, 148);
            this.lblLastName.Size = new System.Drawing.Size(145, 28);
            this.lblLastName.Text = "نام خانوادگی :";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblFatherName.Font = this.lblFirstName.Font;
            this.lblFatherName.ForeColor = this.lblFirstName.ForeColor;
            this.lblFatherName.Location = new System.Drawing.Point(690, 260);
            this.lblFatherName.Size = new System.Drawing.Size(145, 28);
            this.lblFatherName.Text = "نام پدر :";
            this.lblFatherName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblFileNumber.Font = this.lblFirstName.Font;
            this.lblFileNumber.ForeColor = this.lblFirstName.ForeColor;
            this.lblFileNumber.Location = new System.Drawing.Point(690, 36);
            this.lblFileNumber.Size = new System.Drawing.Size(145, 28);
            this.lblFileNumber.Text = "شماره پرونده :";
            this.lblFileNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblMobile.Font = this.lblFirstName.Font;
            this.lblMobile.ForeColor = this.lblFirstName.ForeColor;
            this.lblMobile.Location = new System.Drawing.Point(690, 204);
            this.lblMobile.Size = new System.Drawing.Size(145, 28);
            this.lblMobile.Text = "شماره موبایل :";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblRequired1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblRequired1.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblRequired1.Location = new System.Drawing.Point(840, 92);
            this.lblRequired1.Size = new System.Drawing.Size(20, 28);
            this.lblRequired1.Text = "*";
            this.lblRequired1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblRequired2.Font = this.lblRequired1.Font;
            this.lblRequired2.ForeColor = this.lblRequired1.ForeColor;
            this.lblRequired2.Location = new System.Drawing.Point(840, 148);
            this.lblRequired2.Size = new System.Drawing.Size(20, 28);
            this.lblRequired2.Text = "*";
            this.lblRequired2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblRequired3.Font = this.lblRequired1.Font;
            this.lblRequired3.ForeColor = this.lblRequired1.ForeColor;
            this.lblRequired3.Location = new System.Drawing.Point(840, 36);
            this.lblRequired3.Size = new System.Drawing.Size(20, 28);
            this.lblRequired3.Text = "*";
            this.lblRequired3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblRequired4.Font = this.lblRequired1.Font;
            this.lblRequired4.ForeColor = this.lblRequired1.ForeColor;
            this.lblRequired4.Location = new System.Drawing.Point(840, 204);
            this.lblRequired4.Size = new System.Drawing.Size(20, 28);
            this.lblRequired4.Text = "*";
            this.lblRequired4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Location = new System.Drawing.Point(398, 92);
            this.txtFirstName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFirstName.Size = new System.Drawing.Size(286, 29);
            this.txtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Location = new System.Drawing.Point(398, 148);
            this.txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLastName.Size = new System.Drawing.Size(286, 29);
            this.txtLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.txtFatherName.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherName.TabIndex = 4;
            this.txtFatherName.Location = new System.Drawing.Point(398, 260);
            this.txtFatherName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFatherName.Size = new System.Drawing.Size(286, 29);
            this.txtFatherName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.txtFileNumber.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.txtFileNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileNumber.TabIndex = 0;
            this.txtFileNumber.Location = new System.Drawing.Point(398, 36);
            this.txtFileNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFileNumber.Size = new System.Drawing.Size(286, 29);
            this.txtFileNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.TabIndex = 3;
            this.txtMobile.Location = new System.Drawing.Point(398, 204);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMobile.Size = new System.Drawing.Size(286, 29);
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.lblImageTitle.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblImageTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblImageTitle.Location = new System.Drawing.Point(42, 18);
            this.lblImageTitle.Size = new System.Drawing.Size(300, 28);
            this.lblImageTitle.Text = "تصویر بیمار";
            this.lblImageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblImageHint.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblImageHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblImageHint.Location = new System.Drawing.Point(42, 46);
            this.lblImageHint.Size = new System.Drawing.Size(300, 22);
            this.lblImageHint.Text = "تصویر جدید انتخاب کنید یا تصویر فعلی را دوباره Crop کنید";
            this.lblImageHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.picPatient.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.picPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPatient.Location = new System.Drawing.Point(72, 74);
            this.picPatient.Size = new System.Drawing.Size(240, 190);
            this.picPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.txtImagePath.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtImagePath.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtImagePath.Location = new System.Drawing.Point(72, 274);
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImagePath.Size = new System.Drawing.Size(240, 24);
            this.txtImagePath.Text = "تصویری انتخاب نشده است";
            this.txtImagePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.btnAttachImage.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.btnAttachImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(199, 210, 254);
            this.btnAttachImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachImage.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAttachImage.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnAttachImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttachImage.Location = new System.Drawing.Point(194, 312);
            this.btnAttachImage.Size = new System.Drawing.Size(118, 48);
            this.btnAttachImage.Text = "انتخاب جدید";
            this.btnAttachImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttachImage.UseVisualStyleBackColor = false;
            this.btnAttachImage.Click += new System.EventHandler(this.btnAttachImage_Click);

            this.btnCropCurrent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.btnCropCurrent.Enabled = false;
            this.btnCropCurrent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(147, 197, 253);
            this.btnCropCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCropCurrent.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCropCurrent.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnCropCurrent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCropCurrent.Location = new System.Drawing.Point(72, 312);
            this.btnCropCurrent.Size = new System.Drawing.Size(116, 48);
            this.btnCropCurrent.Text = "Crop فعلی";
            this.btnCropCurrent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCropCurrent.UseVisualStyleBackColor = false;
            this.btnCropCurrent.Click += new System.EventHandler(this.btnCropCurrent_Click);

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(690, 540);
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
            this.btnCancel.Location = new System.Drawing.Point(535, 540);
            this.btnCancel.Size = new System.Drawing.Size(140, 52);
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = false;

            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(924, 616);
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
            this.RightToLeftLayout = false;
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
