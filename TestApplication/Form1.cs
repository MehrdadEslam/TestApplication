using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        private readonly string _recordsRoot;
        private string _selectedFolder = string.Empty;
        private string _selectedImagePath = string.Empty;
        private string _newAttachedImagePath = string.Empty;
        private string _originalFileNumber = string.Empty;
        private bool _isNewRecord;
        private bool _isEditMode;

        public Form1()
        {
            InitializeComponent();
            _recordsRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PatientRecords");
            Directory.CreateDirectory(_recordsRoot);

            SetEditMode(false);
            LoadPatients();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearEditor();
            _isNewRecord = true;
            _isEditMode = true;
            _originalFileNumber = string.Empty;
            SetEditMode(true);
            txtFirstName.Focus();
            lblStatus.Text = "در حال ایجاد پرونده جدید";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!EnsurePatientSelected())
                return;

            _isNewRecord = false;
            _isEditMode = true;
            _originalFileNumber = txtFileNumber.Text.Trim();
            _newAttachedImagePath = string.Empty;
            SetEditMode(true);
            txtFirstName.Focus();
            lblStatus.Text = "در حال اصلاح پرونده " + _originalFileNumber;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!EnsurePatientSelected())
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
                ReleasePatientImage();

                if (Directory.Exists(_selectedFolder))
                    Directory.Delete(_selectedFolder, true);

                ClearEditor();
                SetEditMode(false);
                LoadPatients(txtSearch.Text.Trim());
                lblStatus.Text = "پرونده با موفقیت حذف شد";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حذف پرونده انجام نشد:\n" + ex.Message,
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
                return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "انتخاب تصویر بیمار";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|All Files|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (Image testImage = Image.FromFile(dialog.FileName))
                    {
                    }

                    _newAttachedImagePath = dialog.FileName;
                    txtImagePath.Text = Path.GetFileName(dialog.FileName);
                    ShowImage(dialog.FileName);
                }
                catch
                {
                    MessageBox.Show("فایل انتخاب‌شده یک تصویر معتبر نیست.",
                        "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_isEditMode || !ValidateForm())
                return;

            try
            {
                string fileNumber = txtFileNumber.Text.Trim();
                string safeFileNumber = MakeSafeFileName(fileNumber);
                string targetFolder = Path.Combine(_recordsRoot, safeFileNumber);

                if (_isNewRecord)
                {
                    if (Directory.Exists(targetFolder))
                    {
                        MessageBox.Show("پرونده‌ای با این شماره پرونده قبلاً ثبت شده است.",
                            "شماره پرونده تکراری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFileNumber.Focus();
                        return;
                    }

                    Directory.CreateDirectory(targetFolder);
                }
                else
                {
                    string originalSafeNumber = MakeSafeFileName(_originalFileNumber);
                    string originalFolder = Path.Combine(_recordsRoot, originalSafeNumber);

                    if (!string.Equals(originalSafeNumber, safeFileNumber, StringComparison.OrdinalIgnoreCase))
                    {
                        if (Directory.Exists(targetFolder))
                        {
                            MessageBox.Show("شماره پرونده جدید قبلاً استفاده شده است.",
                                "شماره پرونده تکراری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtFileNumber.Focus();
                            return;
                        }

                        ReleasePatientImage();
                        if (Directory.Exists(originalFolder))
                            Directory.Move(originalFolder, targetFolder);
                        else
                            Directory.CreateDirectory(targetFolder);
                    }
                    else
                    {
                        Directory.CreateDirectory(targetFolder);
                    }
                }

                string savedImagePath = FindExistingImage(targetFolder);

                if (!string.IsNullOrWhiteSpace(_newAttachedImagePath))
                {
                    string extension = Path.GetExtension(_newAttachedImagePath);
                    string newImagePath = Path.Combine(targetFolder, "Attachment" + extension);

                    foreach (string oldImage in Directory.GetFiles(targetFolder, "Attachment.*"))
                    {
                        if (!string.Equals(oldImage, newImagePath, StringComparison.OrdinalIgnoreCase))
                            File.Delete(oldImage);
                    }

                    if (!string.Equals(_newAttachedImagePath, newImagePath, StringComparison.OrdinalIgnoreCase))
                        File.Copy(_newAttachedImagePath, newImagePath, true);

                    savedImagePath = newImagePath;
                }

                WritePatientInfo(targetFolder, savedImagePath);

                _selectedFolder = targetFolder;
                _selectedImagePath = savedImagePath;
                _newAttachedImagePath = string.Empty;
                _originalFileNumber = fileNumber;
                _isNewRecord = false;
                _isEditMode = false;

                SetEditMode(false);
                LoadPatients(txtSearch.Text.Trim(), fileNumber);
                lblStatus.Text = "پرونده با موفقیت ذخیره شد";
            }
            catch (Exception ex)
            {
                MessageBox.Show("هنگام ذخیره پرونده خطایی رخ داد:\n" + ex.Message,
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            _isNewRecord = false;
            _newAttachedImagePath = string.Empty;
            SetEditMode(false);

            if (dgvPatients.CurrentRow != null)
                ShowSelectedPatient();
            else
                ClearEditor();

            lblStatus.Text = "عملیات لغو شد";
        }

        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (_isEditMode)
                return;

            ShowSelectedPatient();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit.PerformClick();
        }

        private void ShowSelectedPatient()
        {
            if (dgvPatients.CurrentRow == null || dgvPatients.CurrentRow.Tag == null)
                return;

            PatientRecord record = dgvPatients.CurrentRow.Tag as PatientRecord;
            if (record == null)
                return;

            _selectedFolder = record.FolderPath;
            _selectedImagePath = record.ImagePath;
            _originalFileNumber = record.FileNumber;
            _newAttachedImagePath = string.Empty;

            txtFirstName.Text = record.FirstName;
            txtLastName.Text = record.LastName;
            txtFileNumber.Text = record.FileNumber;
            txtMobile.Text = record.Mobile;
            txtImagePath.Text = string.IsNullOrWhiteSpace(record.ImagePath)
                ? "بدون تصویر"
                : Path.GetFileName(record.ImagePath);

            ShowImage(record.ImagePath);
            lblStatus.Text = "پرونده " + record.FileNumber + " انتخاب شده است";
        }

        private void LoadPatients(string searchText = "", string selectFileNumber = "")
        {
            List<PatientRecord> records = ReadAllPatients();
            string query = (searchText ?? string.Empty).Trim();

            if (!string.IsNullOrWhiteSpace(query))
            {
                records = records.Where(p =>
                    ContainsText(p.FirstName, query) ||
                    ContainsText(p.LastName, query) ||
                    ContainsText(p.FileNumber, query) ||
                    ContainsText(p.Mobile, query) ||
                    ContainsText(p.FirstName + " " + p.LastName, query))
                    .ToList();
            }

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

            if (!string.IsNullOrWhiteSpace(selectFileNumber))
            {
                foreach (DataGridViewRow row in dgvPatients.Rows)
                {
                    PatientRecord item = row.Tag as PatientRecord;
                    if (item != null && item.FileNumber == selectFileNumber)
                    {
                        row.Selected = true;
                        dgvPatients.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }

            if (dgvPatients.Rows.Count == 0 && !_isEditMode)
            {
                ClearEditor();
                lblStatus.Text = string.IsNullOrWhiteSpace(query)
                    ? "هنوز پرونده‌ای ثبت نشده است"
                    : "نتیجه‌ای برای جستجو پیدا نشد";
            }
        }

        private List<PatientRecord> ReadAllPatients()
        {
            var result = new List<PatientRecord>();

            if (!Directory.Exists(_recordsRoot))
                return result;

            foreach (string folder in Directory.GetDirectories(_recordsRoot))
            {
                string infoPath = Path.Combine(folder, "PatientInfo.txt");
                if (!File.Exists(infoPath))
                    continue;

                try
                {
                    string[] lines = File.ReadAllLines(infoPath, Encoding.UTF8);
                    var record = new PatientRecord
                    {
                        FirstName = ReadValue(lines, "نام:"),
                        LastName = ReadValue(lines, "نام خانوادگی:"),
                        FileNumber = ReadValue(lines, "شماره پرونده:"),
                        Mobile = ReadValue(lines, "شماره موبایل:"),
                        RegisteredAt = ReadValue(lines, "تاریخ ثبت:"),
                        FolderPath = folder,
                        ImagePath = FindExistingImage(folder)
                    };

                    if (string.IsNullOrWhiteSpace(record.FileNumber))
                        record.FileNumber = Path.GetFileName(folder);

                    result.Add(record);
                }
                catch
                {
                    // A damaged record should not stop the rest of the list from loading.
                }
            }

            return result
                .OrderByDescending(p => p.RegisteredAt)
                .ThenBy(p => p.FileNumber)
                .ToList();
        }

        private void WritePatientInfo(string patientFolder, string savedImagePath)
        {
            string infoPath = Path.Combine(patientFolder, "PatientInfo.txt");
            string registeredAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string patientInfo =
                "نام: " + txtFirstName.Text.Trim() + Environment.NewLine +
                "نام خانوادگی: " + txtLastName.Text.Trim() + Environment.NewLine +
                "شماره پرونده: " + txtFileNumber.Text.Trim() + Environment.NewLine +
                "شماره موبایل: " + txtMobile.Text.Trim() + Environment.NewLine +
                "فایل تصویر: " + (string.IsNullOrWhiteSpace(savedImagePath) ? "" : Path.GetFileName(savedImagePath)) + Environment.NewLine +
                "تاریخ ثبت: " + registeredAt;

            File.WriteAllText(infoPath, patientInfo, Encoding.UTF8);
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
                return ValidationError("شماره موبایل باید فقط شامل عدد و بین 10 تا 15 رقم باشد.", txtMobile);

            bool hasExistingImage = !_isNewRecord &&
                (!string.IsNullOrWhiteSpace(_selectedImagePath) && File.Exists(_selectedImagePath));

            if (string.IsNullOrWhiteSpace(_newAttachedImagePath) && !hasExistingImage)
            {
                MessageBox.Show("لطفاً یک تصویر برای بیمار انتخاب کنید.",
                    "اطلاعات ناقص", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAttachImage.Focus();
                return false;
            }

            return true;
        }

        private bool ValidationError(string message, Control control)
        {
            MessageBox.Show(message, "اطلاعات ناقص",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }

        private bool EnsurePatientSelected()
        {
            if (dgvPatients.CurrentRow != null && dgvPatients.CurrentRow.Tag != null)
                return true;

            MessageBox.Show("ابتدا یک پرونده را از لیست انتخاب کنید.",
                "انتخاب پرونده", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            _selectedFolder = string.Empty;
            _selectedImagePath = string.Empty;
            _newAttachedImagePath = string.Empty;
            _originalFileNumber = string.Empty;
        }

        private void ShowImage(string path)
        {
            ReleasePatientImage();

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return;

            try
            {
                using (Image source = Image.FromFile(path))
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

        private string FindExistingImage(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
                return string.Empty;

            return Directory.GetFiles(folder, "Attachment.*").FirstOrDefault() ?? string.Empty;
        }

        private string ReadValue(string[] lines, string key)
        {
            string line = lines.FirstOrDefault(x => x.StartsWith(key, StringComparison.Ordinal));
            return line == null ? string.Empty : line.Substring(key.Length).Trim();
        }

        private bool ContainsText(string value, string query)
        {
            return (value ?? string.Empty).IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private string MakeSafeFileName(string value)
        {
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
                value = value.Replace(invalidChar, '_');

            return value;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ReleasePatientImage();
            base.OnFormClosed(e);
        }

        private sealed class PatientRecord
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FileNumber { get; set; }
            public string Mobile { get; set; }
            public string RegisteredAt { get; set; }
            public string FolderPath { get; set; }
            public string ImagePath { get; set; }
        }
    }
}
