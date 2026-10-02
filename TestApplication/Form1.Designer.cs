namespace TestApplication
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblAppSubtitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegisteredAt;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Label lblEditorTitle;
        private System.Windows.Forms.Label lblEditorHint;
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
        private System.Windows.Forms.PictureBox picPatientImage;
        private System.Windows.Forms.Button btnAttachImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblAppSubtitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.colFileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegisteredAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            this.lblEditorHint = new System.Windows.Forms.Label();
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
            this.picPatientImage = new System.Windows.Forms.PictureBox();
            this.btnAttachImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.pnlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatientImage)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblAppSubtitle);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 78;

            this.lblAppTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblAppTitle.AutoSize = false;
            this.lblAppTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(840, 14);
            this.lblAppTitle.Size = new System.Drawing.Size(400, 34);
            this.lblAppTitle.Text = "مدیریت پرونده بیماران";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblAppSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblAppSubtitle.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblAppSubtitle.Location = new System.Drawing.Point(840, 50);
            this.lblAppSubtitle.Size = new System.Drawing.Size(400, 20);
            this.lblAppSubtitle.Text = "Patient Records Management";
            this.lblAppSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Toolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnNew);
            this.pnlToolbar.Controls.Add(this.btnEdit);
            this.pnlToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Controls.Add(this.btnSearch);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.lblSearch);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 82;
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(24, 16, 24, 14);

            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(1102, 18);
            this.btnNew.Size = new System.Drawing.Size(138, 44);
            this.btnNew.Text = "ایجاد پرونده";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnEdit.Location = new System.Drawing.Point(958, 18);
            this.btnEdit.Size = new System.Drawing.Size(132, 44);
            this.btnEdit.Text = "اصلاح";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(254, 202, 202);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnDelete.Location = new System.Drawing.Point(814, 18);
            this.btnDelete.Size = new System.Drawing.Size(132, 44);
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSearch.Location = new System.Drawing.Point(394, 31);
            this.lblSearch.Text = "جستجو";

            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSearch.Location = new System.Drawing.Point(128, 24);
            this.txtSearch.Size = new System.Drawing.Size(255, 28);
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(24, 23);
            this.btnSearch.Size = new System.Drawing.Size(92, 32);
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Grid container
            this.pnlGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom |
                                  System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(24, 180);
            this.pnlGrid.Size = new System.Drawing.Size(810, 515);
            this.pnlGrid.Controls.Add(this.dgvPatients);
            this.pnlGrid.Controls.Add(this.lblCount);
            this.pnlGrid.Controls.Add(this.lblListTitle);

            this.lblListTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblListTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblListTitle.Location = new System.Drawing.Point(555, 17);
            this.lblListTitle.Size = new System.Drawing.Size(235, 30);
            this.lblListTitle.Text = "لیست بیماران";
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblCount.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Location = new System.Drawing.Point(18, 20);
            this.lblCount.Size = new System.Drawing.Size(150, 25);
            this.lblCount.Text = "0 پرونده";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom |
                                      System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPatients.ColumnHeadersHeight = 42;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFileNumber,
                this.colFirstName,
                this.colLastName,
                this.colMobile,
                this.colRegisteredAt});
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvPatients.Location = new System.Drawing.Point(18, 58);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowTemplate.Height = 42;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(772, 438);
            this.dgvPatients.SelectionChanged += new System.EventHandler(this.dgvPatients_SelectionChanged);
            this.dgvPatients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellDoubleClick);

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            headerStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.dgvPatients.ColumnHeadersDefaultCellStyle = headerStyle;

            rowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.dgvPatients.DefaultCellStyle = rowStyle;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.dgvPatients.AlternatingRowsDefaultCellStyle = alternatingStyle;

            this.colFileNumber.HeaderText = "شماره پرونده";
            this.colFileNumber.Name = "colFileNumber";
            this.colFileNumber.ReadOnly = true;
            this.colFirstName.HeaderText = "نام";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            this.colLastName.HeaderText = "نام خانوادگی";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            this.colMobile.HeaderText = "شماره موبایل";
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;
            this.colRegisteredAt.HeaderText = "تاریخ ثبت";
            this.colRegisteredAt.Name = "colRegisteredAt";
            this.colRegisteredAt.ReadOnly = true;

            // Editor panel
            this.pnlEditor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom |
                                    System.Windows.Forms.AnchorStyles.Right;
            this.pnlEditor.BackColor = System.Drawing.Color.White;
            this.pnlEditor.Location = new System.Drawing.Point(854, 180);
            this.pnlEditor.Size = new System.Drawing.Size(386, 515);
            this.pnlEditor.Controls.Add(this.lblEditorTitle);
            this.pnlEditor.Controls.Add(this.lblEditorHint);
            this.pnlEditor.Controls.Add(this.lblFirstName);
            this.pnlEditor.Controls.Add(this.txtFirstName);
            this.pnlEditor.Controls.Add(this.lblLastName);
            this.pnlEditor.Controls.Add(this.txtLastName);
            this.pnlEditor.Controls.Add(this.lblFileNumber);
            this.pnlEditor.Controls.Add(this.txtFileNumber);
            this.pnlEditor.Controls.Add(this.lblMobile);
            this.pnlEditor.Controls.Add(this.txtMobile);
            this.pnlEditor.Controls.Add(this.lblImage);
            this.pnlEditor.Controls.Add(this.picPatientImage);
            this.pnlEditor.Controls.Add(this.txtImagePath);
            this.pnlEditor.Controls.Add(this.btnAttachImage);
            this.pnlEditor.Controls.Add(this.btnSave);
            this.pnlEditor.Controls.Add(this.btnCancel);

            this.lblEditorTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditorTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblEditorTitle.Location = new System.Drawing.Point(24, 16);
            this.lblEditorTitle.Size = new System.Drawing.Size(338, 30);
            this.lblEditorTitle.Text = "اطلاعات پرونده";
            this.lblEditorTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblEditorHint.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblEditorHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEditorHint.Location = new System.Drawing.Point(24, 47);
            this.lblEditorHint.Size = new System.Drawing.Size(338, 22);
            this.lblEditorHint.Text = "برای ویرایش، پرونده را انتخاب و کلید اصلاح را بزنید";
            this.lblEditorHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFirstName.Location = new System.Drawing.Point(204, 80);
            this.lblFirstName.Size = new System.Drawing.Size(158, 20);
            this.lblFirstName.Text = "نام";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(204, 103);
            this.txtFirstName.Size = new System.Drawing.Size(158, 28);
            this.txtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblLastName.Location = new System.Drawing.Point(24, 80);
            this.lblLastName.Size = new System.Drawing.Size(158, 20);
            this.lblLastName.Text = "نام خانوادگی";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLastName.Location = new System.Drawing.Point(24, 103);
            this.txtLastName.Size = new System.Drawing.Size(158, 28);
            this.txtLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblFileNumber.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFileNumber.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFileNumber.Location = new System.Drawing.Point(204, 143);
            this.lblFileNumber.Size = new System.Drawing.Size(158, 20);
            this.lblFileNumber.Text = "شماره پرونده";
            this.lblFileNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtFileNumber.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFileNumber.Location = new System.Drawing.Point(204, 166);
            this.txtFileNumber.Size = new System.Drawing.Size(158, 28);
            this.txtFileNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblMobile.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMobile.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblMobile.Location = new System.Drawing.Point(24, 143);
            this.lblMobile.Size = new System.Drawing.Size(158, 20);
            this.lblMobile.Text = "شماره موبایل";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobile.Location = new System.Drawing.Point(24, 166);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.Size = new System.Drawing.Size(158, 28);
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblImage.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblImage.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblImage.Location = new System.Drawing.Point(204, 207);
            this.lblImage.Size = new System.Drawing.Size(158, 20);
            this.lblImage.Text = "تصویر بیمار";
            this.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.picPatientImage.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.picPatientImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPatientImage.Location = new System.Drawing.Point(204, 230);
            this.picPatientImage.Size = new System.Drawing.Size(158, 150);
            this.picPatientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.txtImagePath.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImagePath.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtImagePath.Location = new System.Drawing.Point(24, 230);
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(158, 26);
            this.txtImagePath.Text = "تصویری انتخاب نشده است";
            this.txtImagePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.btnAttachImage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnAttachImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnAttachImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachImage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnAttachImage.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnAttachImage.Location = new System.Drawing.Point(24, 268);
            this.btnAttachImage.Size = new System.Drawing.Size(158, 40);
            this.btnAttachImage.Text = "انتخاب تصویر";
            this.btnAttachImage.UseVisualStyleBackColor = false;
            this.btnAttachImage.Click += new System.EventHandler(this.btnAttachImage_Click);

            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(204, 447);
            this.btnSave.Size = new System.Drawing.Size(158, 44);
            this.btnSave.Text = "ذخیره تغییرات";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCancel.Location = new System.Drawing.Point(24, 447);
            this.btnCancel.Size = new System.Drawing.Size(158, 44);
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Status bar
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Height = 34;
            this.pnlStatus.Controls.Add(this.lblStatus);

            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStatus.Padding = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.lblStatus.Text = "آماده";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1264, 741);
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت پرونده بیماران";

            this.pnlHeader.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatientImage)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
