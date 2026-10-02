namespace TestApplication
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegisteredAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdatedAt;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.colRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegisteredAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 88;

            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(770, 14);
            this.lblTitle.Size = new System.Drawing.Size(430, 38);
            this.lblTitle.Text = "لیست بیماران";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(650, 54);
            this.lblSubtitle.Size = new System.Drawing.Size(550, 22);
            this.lblSubtitle.Text = "مدیریت پرونده‌ها، جستجو، ایجاد، اصلاح و حذف";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblSearch);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.btnSearch);
            this.pnlToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Controls.Add(this.btnEdit);
            this.pnlToolbar.Controls.Add(this.btnNew);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 102;
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16);

            this.btnNew.BackColor = System.Drawing.Color.FromArgb(236, 253, 245);
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(167, 243, 208);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(1090, 12);
            this.btnNew.Size = new System.Drawing.Size(96, 76);
            this.btnNew.Text = "ایجاد";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(191, 219, 254);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEdit.Location = new System.Drawing.Point(984, 12);
            this.btnEdit.Size = new System.Drawing.Size(96, 76);
            this.btnEdit.Text = "اصلاح";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(254, 202, 202);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(878, 12);
            this.btnDelete.Size = new System.Drawing.Size(96, 76);
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSearch.Location = new System.Drawing.Point(590, 19);
            this.lblSearch.Size = new System.Drawing.Size(100, 24);
            this.lblSearch.Text = "جستجو:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSearch.Location = new System.Drawing.Point(270, 48);
            this.txtSearch.Size = new System.Drawing.Size(420, 28);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(240, 249, 255);
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(186, 230, 253);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(150, 36);
            this.btnSearch.Size = new System.Drawing.Size(105, 48);
            this.btnSearch.Text = "  جستجو";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            headerStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            rowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Tahoma", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(14, 132, 216);
            rowStyle.SelectionForeColor = System.Drawing.Color.White;

            altStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.AlternatingRowsDefaultCellStyle = altStyle;
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPatients.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvPatients.ColumnHeadersHeight = 52;
            this.dgvPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colRow, this.colFileNumber, this.colPatientName, this.colMobile, this.colRegisteredAt, this.colUpdatedAt});
            this.dgvPatients.DefaultCellStyle = rowStyle;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowTemplate.Height = 42;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellDoubleClick);
            this.dgvPatients.SelectionChanged += new System.EventHandler(this.dgvPatients_SelectionChanged);

            this.colRow.FillWeight = 35F;
            this.colRow.HeaderText = "ردیف";
            this.colRow.Name = "colRow";
            this.colRow.ReadOnly = true;

            this.colFileNumber.FillWeight = 75F;
            this.colFileNumber.HeaderText = "شماره پرونده";
            this.colFileNumber.Name = "colFileNumber";
            this.colFileNumber.ReadOnly = true;

            this.colPatientName.FillWeight = 145F;
            this.colPatientName.HeaderText = "نام بیمار";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;

            this.colMobile.FillWeight = 100F;
            this.colMobile.HeaderText = "شماره موبایل";
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;

            this.colRegisteredAt.FillWeight = 100F;
            this.colRegisteredAt.HeaderText = "تاریخ ثبت";
            this.colRegisteredAt.Name = "colRegisteredAt";
            this.colRegisteredAt.ReadOnly = true;

            this.colUpdatedAt.FillWeight = 100F;
            this.colUpdatedAt.HeaderText = "آخرین تغییر";
            this.colUpdatedAt.Name = "colUpdatedAt";
            this.colUpdatedAt.ReadOnly = true;

            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblCount);
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 42;

            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatus.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblStatus.Text = "آماده";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblCount.Size = new System.Drawing.Size(140, 42);
            this.lblCount.Text = "0 پرونده";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1220, 720);
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.MinimumSize = new System.Drawing.Size(1050, 620);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست بیماران";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
