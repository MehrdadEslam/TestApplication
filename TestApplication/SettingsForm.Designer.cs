namespace TestApplication
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlDatabase;
        private System.Windows.Forms.Label lblDatabaseTitle;
        private System.Windows.Forms.Label lblDatabaseDescription;
        private System.Windows.Forms.Label lblDatabasePathTitle;
        private System.Windows.Forms.TextBox txtDatabasePath;
        private System.Windows.Forms.Label lblDatabaseStatus;
        private System.Windows.Forms.Label lblFuture;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlDatabase = new System.Windows.Forms.Panel();
            this.lblDatabaseTitle = new System.Windows.Forms.Label();
            this.lblDatabaseDescription = new System.Windows.Forms.Label();
            this.lblDatabasePathTitle = new System.Windows.Forms.Label();
            this.txtDatabasePath = new System.Windows.Forms.TextBox();
            this.lblDatabaseStatus = new System.Windows.Forms.Label();
            this.lblFuture = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlDatabase.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 92;

            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(310, 16);
            this.lblTitle.Size = new System.Drawing.Size(430, 38);
            this.lblTitle.Text = "تنظیمات نرم افزار";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(310, 56);
            this.lblSubtitle.Size = new System.Drawing.Size(430, 22);
            this.lblSubtitle.Text = "Software Settings";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlDatabase.BackColor = System.Drawing.Color.White;
            this.pnlDatabase.Controls.Add(this.lblDatabaseTitle);
            this.pnlDatabase.Controls.Add(this.lblDatabaseDescription);
            this.pnlDatabase.Controls.Add(this.lblDatabasePathTitle);
            this.pnlDatabase.Controls.Add(this.txtDatabasePath);
            this.pnlDatabase.Controls.Add(this.lblDatabaseStatus);
            this.pnlDatabase.Location = new System.Drawing.Point(24, 120);
            this.pnlDatabase.Size = new System.Drawing.Size(716, 230);

            this.lblDatabaseTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDatabaseTitle.Location = new System.Drawing.Point(24, 22);
            this.lblDatabaseTitle.Size = new System.Drawing.Size(668, 32);
            this.lblDatabaseTitle.Text = "دیتابیس برنامه";
            this.lblDatabaseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblDatabaseDescription.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDatabaseDescription.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDatabaseDescription.Location = new System.Drawing.Point(24, 59);
            this.lblDatabaseDescription.Size = new System.Drawing.Size(668, 25);
            this.lblDatabaseDescription.Text = "اطلاعات بیماران و تصاویر در دیتابیس SQLite ذخیره می‌شوند.";
            this.lblDatabaseDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblDatabasePathTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDatabasePathTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDatabasePathTitle.Location = new System.Drawing.Point(24, 100);
            this.lblDatabasePathTitle.Size = new System.Drawing.Size(668, 23);
            this.lblDatabasePathTitle.Text = "مسیر فایل دیتابیس";
            this.lblDatabasePathTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtDatabasePath.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtDatabasePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabasePath.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDatabasePath.Location = new System.Drawing.Point(24, 128);
            this.txtDatabasePath.ReadOnly = true;
            this.txtDatabasePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDatabasePath.Size = new System.Drawing.Size(668, 26);

            this.lblDatabaseStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseStatus.Location = new System.Drawing.Point(24, 174);
            this.lblDatabaseStatus.Size = new System.Drawing.Size(668, 30);
            this.lblDatabaseStatus.Text = "در حال بررسی دیتابیس...";
            this.lblDatabaseStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblFuture.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFuture.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblFuture.Location = new System.Drawing.Point(24, 373);
            this.lblFuture.Size = new System.Drawing.Size(716, 50);
            this.lblFuture.Text = "این صفحه برای تنظیمات بعدی برنامه آماده شده است؛ تنظیمات مطب، پشتیبان‌گیری، چاپ و سایر گزینه‌ها در این بخش اضافه خواهند شد.";
            this.lblFuture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.btnClose.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(24, 449);
            this.btnClose.Size = new System.Drawing.Size(160, 44);
            this.btnClose.Text = "بازگشت";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(764, 521);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFuture);
            this.Controls.Add(this.pnlDatabase);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تنظیمات نرم افزار";
            this.pnlHeader.ResumeLayout(false);
            this.pnlDatabase.ResumeLayout(false);
            this.pnlDatabase.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
