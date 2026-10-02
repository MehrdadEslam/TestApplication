namespace TestApplication
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlPatientsCard;
        private System.Windows.Forms.PictureBox picPatients;
        private System.Windows.Forms.Label lblPatientsTitle;
        private System.Windows.Forms.Label lblPatientsDescription;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Panel pnlSettingsCard;
        private System.Windows.Forms.PictureBox picSettings;
        private System.Windows.Forms.Label lblSettingsTitle;
        private System.Windows.Forms.Label lblSettingsDescription;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblFooter;

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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.pnlPatientsCard = new System.Windows.Forms.Panel();
            this.picPatients = new System.Windows.Forms.PictureBox();
            this.lblPatientsTitle = new System.Windows.Forms.Label();
            this.lblPatientsDescription = new System.Windows.Forms.Label();
            this.btnPatients = new System.Windows.Forms.Button();
            this.pnlSettingsCard = new System.Windows.Forms.Panel();
            this.picSettings = new System.Windows.Forms.PictureBox();
            this.lblSettingsTitle = new System.Windows.Forms.Label();
            this.lblSettingsDescription = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlPatientsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatients)).BeginInit();
            this.pnlSettingsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).BeginInit();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 112;

            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(510, 22);
            this.lblTitle.Size = new System.Drawing.Size(430, 42);
            this.lblTitle.Text = "سامانه مدیریت مطب";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(510, 67);
            this.lblSubtitle.Size = new System.Drawing.Size(430, 24);
            this.lblSubtitle.Text = "Dental Practice Management";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblWelcome.Location = new System.Drawing.Point(260, 145);
            this.lblWelcome.Size = new System.Drawing.Size(440, 38);
            this.lblWelcome.Text = "صفحه اصلی";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblHint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHint.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location = new System.Drawing.Point(210, 186);
            this.lblHint.Size = new System.Drawing.Size(540, 28);
            this.lblHint.Text = "بخش موردنظر را برای ادامه کار انتخاب کنید";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlPatientsCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlPatientsCard.BackColor = System.Drawing.Color.White;
            this.pnlPatientsCard.Controls.Add(this.picPatients);
            this.pnlPatientsCard.Controls.Add(this.lblPatientsTitle);
            this.pnlPatientsCard.Controls.Add(this.lblPatientsDescription);
            this.pnlPatientsCard.Controls.Add(this.btnPatients);
            this.pnlPatientsCard.Location = new System.Drawing.Point(493, 235);
            this.pnlPatientsCard.Size = new System.Drawing.Size(360, 320);

            this.picPatients.Location = new System.Drawing.Point(104, 18);
            this.picPatients.Size = new System.Drawing.Size(152, 132);
            this.picPatients.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPatients.TabStop = false;

            this.lblPatientsTitle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblPatientsTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPatientsTitle.Location = new System.Drawing.Point(24, 158);
            this.lblPatientsTitle.Size = new System.Drawing.Size(308, 34);
            this.lblPatientsTitle.Text = "لیست بیماران";
            this.lblPatientsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblPatientsDescription.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPatientsDescription.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPatientsDescription.Location = new System.Drawing.Point(24, 198);
            this.lblPatientsDescription.Size = new System.Drawing.Size(308, 42);
            this.lblPatientsDescription.Text = "مدیریت پرونده، ایجاد، اصلاح، حذف و جستجوی بیماران";
            this.lblPatientsDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            this.btnPatients.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnPatients.FlatAppearance.BorderSize = 0;
            this.btnPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatients.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnPatients.ForeColor = System.Drawing.Color.White;
            this.btnPatients.Location = new System.Drawing.Point(24, 256);
            this.btnPatients.Size = new System.Drawing.Size(308, 46);
            this.btnPatients.Text = "ورود به لیست بیماران";
            this.btnPatients.UseVisualStyleBackColor = false;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);

            this.pnlSettingsCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlSettingsCard.BackColor = System.Drawing.Color.White;
            this.pnlSettingsCard.Controls.Add(this.picSettings);
            this.pnlSettingsCard.Controls.Add(this.lblSettingsTitle);
            this.pnlSettingsCard.Controls.Add(this.lblSettingsDescription);
            this.pnlSettingsCard.Controls.Add(this.btnSettings);
            this.pnlSettingsCard.Location = new System.Drawing.Point(107, 235);
            this.pnlSettingsCard.Size = new System.Drawing.Size(360, 320);

            this.picSettings.Location = new System.Drawing.Point(104, 18);
            this.picSettings.Size = new System.Drawing.Size(152, 132);
            this.picSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSettings.TabStop = false;

            this.lblSettingsTitle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblSettingsTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSettingsTitle.Location = new System.Drawing.Point(24, 158);
            this.lblSettingsTitle.Size = new System.Drawing.Size(308, 34);
            this.lblSettingsTitle.Text = "تنظیمات نرم افزار";
            this.lblSettingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSettingsDescription.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSettingsDescription.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSettingsDescription.Location = new System.Drawing.Point(24, 198);
            this.lblSettingsDescription.Size = new System.Drawing.Size(308, 42);
            this.lblSettingsDescription.Text = "تنظیمات عمومی برنامه، اطلاعات سیستم و دیتابیس";
            this.lblSettingsDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(24, 256);
            this.btnSettings.Size = new System.Drawing.Size(308, 46);
            this.btnSettings.Text = "ورود به تنظیمات";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);

            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblFooter.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFooter.Location = new System.Drawing.Point(24, 592);
            this.lblFooter.Size = new System.Drawing.Size(912, 28);
            this.lblFooter.Text = "Patient Management System  •  SQLite";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(960, 640);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.pnlSettingsCard);
            this.Controls.Add(this.pnlPatientsCard);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سامانه مدیریت مطب";
            this.pnlHeader.ResumeLayout(false);
            this.pnlPatientsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPatients)).EndInit();
            this.pnlSettingsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
