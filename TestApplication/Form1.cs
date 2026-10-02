using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        private PatientDatabase _database;
        private long _selectedPatientId;
        private byte[] _selectedImageData;
        private byte[] _newImageData;
        private string _selectedImageFileName = string.Empty;
        private string _newImageFileName = string.Empty;
        private bool _isNewRecord;
        private bool _isEditMode;

        public Form1()
        {
            InitializeComponent();

            try
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch
            {
            }

            try
            {
                _database = new PatientDatabase();
                SetEditMode(false);
                LoadPatients();
                lblStatus.Text = "آماده — اطلاعات در SQLite ذخیره می‌شود";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "راه‌اندازی دیتابیس SQLite انجام نشد:\n" + ex.Message +
                    "\n\nابتدا NuGet Package Restore را اجرا و پروژه را دوباره Build کنید.",
                    "خطای دیتابیس",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseReady())
                return;

            ClearEditor();
            _isNewRecord = true;
            _isEditMode = true;
            SetEditMode(true);
            txtFirstName.Focus();
            lblStatus.Text = "در حال ایجاد پرونده جدید";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseReady() || !EnsurePatientSelected())
                return;

            _isNewRecord = false;
            _isEditMode = true;
            _newImageData = null;
            _newImageFileName = string.Empty;
            SetEditMode(true);
            txtFirstName.Focus();
            lblStatus.Text = "در حال اصلاح پرونده " + txtFileNumber.Text.Trim();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseReady() || !EnsurePatientSelected())
                return;

            string patientName = (txtFirstName.Text + " " + txtLastName.Text).Trim();
            DialogResult result = MessageBox.Show(
                "آیا از حذف پرونده «" + patientName + "» مطمئن هستید؟\nاین عملیات قابل بازگشت نیست.",
                "تأیید حذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _database.Delete(_selectedPatientId);
                ClearEditor();
                SetEditMode(false);
                LoadPatients(txtSearch.Text.Trim());
                lblStatus.Text = "پرونده با موفقیت از دیتابیس حذف شد";
            }
            catch (Exception ex)
            {
                ShowDatabaseError("حذف پرونده انجام نشد", ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_isEditMode)
                LoadPatients(txtSearch.Text.Trim());
        }

        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
                return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "انتخاب تصویر بیمار";
                dialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|" +
                    "JPEG Files|*.jpg;*.jpeg|" +
                    "PNG Files|*.png|" +
                    "All Files|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    byte[] imageBytes = File.ReadAllBytes(dialog.FileName);

                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    using (Image testImage = Image.FromStream(stream))
                    {
                    }

                    _newImageData = imageBytes;
                    _newImageFileName = Path.GetFileName(dialog.FileName);
                    txtImagePath.Text = _newImageFileName;
                    ShowImage(_newImageData);
                }
                catch
                {
                    MessageBox.Show(
                        "فایل انتخاب‌شده یک تصویر معتبر نیست.",
                        "خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseReady() || !_isEditMode || !ValidateForm())
                return;

            try
            {
                string fileNumber = txtFileNumber.Text.Trim();
                long excludeId = _isNewRecord ? 0 : _selectedPatientId;

                if (_database.FileNumberExists(fileNumber, excludeId))
                {
                    MessageBox.Show(
                        "پرونده‌ای با این شماره پرونده قبلاً ثبت شده است.",
                        "شماره پرونده تکراری",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtFileNumber.Focus();
                    return;
                }

                byte[] imageData = _newImageData ?? _selectedImageData;
                string imageFileName = !string.IsNullOrWhiteSpace(_newImageFileName)
                    ? _newImageFileName
                    : _selectedImageFileName;

                var patient = new PatientRecord
                {
                    Id = _isNewRecord ? 0 : _selectedPatientId,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    FileNumber = fileNumber,
                    Mobile = txtMobile.Text.Trim(),
                    ImageData = imageData,
                    ImageFileName = imageFileName
                };

                long savedId = _database.Save(patient);

                _selectedPatientId = savedId;
                _selectedImageData = imageData;
                _selectedImageFileName = imageFileName;
                _newImageData = null;
                _newImageFileName = string.Empty;
                _isNewRecord = false;
                _isEditMode = false;

                SetEditMode(false);
                LoadPatients(txtSearch.Text.Trim(), savedId);
                lblStatus.Text = "پرونده با موفقیت در SQLite ذخیره شد";
            }
            catch (Exception ex)
            {
                ShowDatabaseError("ذخیره پرونده انجام نشد", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            _isNewRecord = false;
            _newImageData = null;
            _newImageFileName = string.Empty;
            SetEditMode(false);

            if (_selectedPatientId > 0)
                ShowPatient(_selectedPatientId);
            else
                ClearEditor();

            lblStatus.Text = "عملیات لغو شد";
        }

        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (_isEditMode || dgvPatients.CurrentRow == null || dgvPatients.CurrentRow.Tag == null)
                return;

            PatientRecord record = dgvPatients.CurrentRow.Tag as PatientRecord;
            if (record != null)
                ShowPatient(record.Id);
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit.PerformClick();
        }

        private void ShowPatient(long id)
        {
            if (!EnsureDatabaseReady())
                return;

            try
            {
                PatientRecord record = _database.GetById(id);
                if (record == null)
                    return;

                _selectedPatientId = record.Id;
                _selectedImageData = record.ImageData;
                _selectedImageFileName = record.ImageFileName ?? string.Empty;
                _newImageData = null;
                _newImageFileName = string.Empty;

                txtFirstName.Text = record.FirstName;
                txtLastName.Text = record.LastName;
                txtFileNumber.Text = record.FileNumber;
                txtMobile.Text = record.Mobile;
                txtImagePath.Text = string.IsNullOrWhiteSpace(record.ImageFileName)
                    ? "بدون تصویر"
                    : record.ImageFileName;

                ShowImage(record.ImageData);
                lblStatus.Text = "پرونده " + record.FileNumber + " انتخاب شده است";
            }
            catch (Exception ex)
            {
                ShowDatabaseError("خواندن پرونده انجام نشد", ex);
            }
        }

        private void LoadPatients(string searchText = "", long selectPatientId = 0)
        {
            if (!EnsureDatabaseReady(false))
                return;

            try
            {
                List<PatientRecord> records = _database.Search(searchText);
                dgvPatients.Rows.Clear();

                foreach (PatientRecord patient in records)
                {
                    int rowIndex = dgvPatients.Rows.Add(
                        patient.FileNumber,
                        patient.FirstName,
                        patient.LastName,
                        patient.Mobile,
                        patient.RegisteredAt);

                    dgvPatients.Rows[rowIndex].Tag = patient;
                }

                lblCount.Text = records.Count + " پرونده";

                if (selectPatientId > 0)
                {
                    foreach (DataGridViewRow row in dgvPatients.Rows)
                    {
                        PatientRecord item = row.Tag as PatientRecord;
                        if (item != null && item.Id == selectPatientId)
                        {
                            row.Selected = true;
                            dgvPatients.CurrentCell = row.Cells[0];
                            ShowPatient(item.Id);
                            return;
                        }
                    }
                }

                if (dgvPatients.Rows.Count > 0 && dgvPatients.CurrentRow != null)
                {
                    PatientRecord first = dgvPatients.CurrentRow.Tag as PatientRecord;
                    if (first != null && !_isEditMode)
                        ShowPatient(first.Id);
                }
                else if (!_isEditMode)
                {
                    ClearEditor();
                    lblStatus.Text = string.IsNullOrWhiteSpace(searchText)
                        ? "هنوز پرونده‌ای ثبت نشده است"
                        : "نتیجه‌ای برای جستجو پیدا نشد";
                }
            }
            catch (Exception ex)
            {
                ShowDatabaseError("خواندن لیست بیماران انجام نشد", ex);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                return ValidationError("لطفاً نام بیمار را وارد کنید.", txtFirstName);
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                return ValidationError("لطفاً نام خانوادگی بیمار را وارد کنید.", txtLastName);
            if (string.IsNullOrWhiteSpace(txtFileNumber.Text))
                return ValidationError("لطفاً شماره پرونده را وارد کنید.", txtFileNumber);

            string mobile = txtMobile.Text.Trim();
            if (string.IsNullOrWhiteSpace(mobile))
                return ValidationError("لطفاً شماره موبایل را وارد کنید.", txtMobile);
            if (!mobile.All(char.IsDigit) || mobile.Length < 10 || mobile.Length > 15)
                return ValidationError(
                    "شماره موبایل باید فقط شامل عدد و بین 10 تا 15 رقم باشد.",
                    txtMobile);

            byte[] imageData = _newImageData ?? _selectedImageData;
            if (imageData == null || imageData.Length == 0)
            {
                MessageBox.Show(
                    "لطفاً یک تصویر برای بیمار انتخاب کنید.",
                    "اطلاعات ناقص",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                btnAttachImage.Focus();
                return false;
            }

            return true;
        }

        private bool ValidationError(string message, Control control)
        {
            MessageBox.Show(
                message,
                "اطلاعات ناقص",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }

        private bool EnsurePatientSelected()
        {
            if (_selectedPatientId > 0)
                return true;

            MessageBox.Show(
                "ابتدا یک پرونده را از لیست انتخاب کنید.",
                "انتخاب پرونده",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return false;
        }

        private bool EnsureDatabaseReady(bool showMessage = true)
        {
            if (_database != null)
                return true;

            if (showMessage)
            {
                MessageBox.Show(
                    "دیتابیس SQLite در دسترس نیست. پروژه را Rebuild کنید و مطمئن شوید NuGet Package Restore انجام شده است.",
                    "دیتابیس",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return false;
        }

        private void SetEditMode(bool enabled)
        {
            txtFirstName.ReadOnly = !enabled;
            txtLastName.ReadOnly = !enabled;
            txtFileNumber.ReadOnly = !enabled;
            txtMobile.ReadOnly = !enabled;

            btnAttachImage.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnCancel.Enabled = enabled;

            btnNew.Enabled = !enabled;
            btnEdit.Enabled = !enabled;
            btnDelete.Enabled = !enabled;
            dgvPatients.Enabled = !enabled;
            txtSearch.Enabled = !enabled;
            btnSearch.Enabled = !enabled;

            Color readOnlyColor = Color.FromArgb(248, 250, 252);
            Color editColor = Color.White;
            txtFirstName.BackColor = enabled ? editColor : readOnlyColor;
            txtLastName.BackColor = enabled ? editColor : readOnlyColor;
            txtFileNumber.BackColor = enabled ? editColor : readOnlyColor;
            txtMobile.BackColor = enabled ? editColor : readOnlyColor;
        }

        private void ClearEditor()
        {
            ReleasePatientImage();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFileNumber.Clear();
            txtMobile.Clear();
            txtImagePath.Text = "تصویری انتخاب نشده است";

            _selectedPatientId = 0;
            _selectedImageData = null;
            _selectedImageFileName = string.Empty;
            _newImageData = null;
            _newImageFileName = string.Empty;
        }

        private void ShowImage(byte[] imageData)
        {
            ReleasePatientImage();

            if (imageData == null || imageData.Length == 0)
                return;

            try
            {
                using (MemoryStream stream = new MemoryStream(imageData))
                using (Image source = Image.FromStream(stream))
                    picPatientImage.Image = new Bitmap(source);
            }
            catch
            {
                picPatientImage.Image = null;
            }
        }

        private void ReleasePatientImage()
        {
            if (picPatientImage.Image != null)
            {
                picPatientImage.Image.Dispose();
                picPatientImage.Image = null;
            }
        }

        private void ShowDatabaseError(string title, Exception ex)
        {
            MessageBox.Show(
                title + ":\n" + ex.Message,
                "خطای دیتابیس",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ReleasePatientImage();
            base.OnFormClosed(e);
        }
    }
}
