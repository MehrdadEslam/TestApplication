using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class PatientEditForm : Form
    {
        private readonly PatientDatabase _database;
        private readonly long _patientId;
        private byte[] _imageData;
        private string _imageFileName = string.Empty;

        public PatientEditForm(PatientDatabase database, long patientId = 0)
        {
            _database = database;
            _patientId = patientId;

            InitializeComponent();
            ApplyApplicationIcon();
            ApplyButtonIcons();

            if (_patientId > 0)
                LoadPatient();
            else
                PrepareNewPatient();
        }

        private void ApplyApplicationIcon()
        {
            try { Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); }
            catch { }
        }

        private void ApplyButtonIcons()
        {
            btnSave.Image = UiIcons.SaveIcon();
            btnAttachImage.Image = UiIcons.ImageIcon();
        }

        private void PrepareNewPatient()
        {
            Text = "ایجاد پرونده بیمار";
            lblTitle.Text = "ایجاد پرونده جدید";
            lblSubtitle.Text = "اطلاعات بیمار را تکمیل و ذخیره کنید";
            txtFirstName.Focus();
        }

        private void LoadPatient()
        {
            PatientRecord patient = _database.GetById(_patientId);
            if (patient == null)
            {
                MessageBox.Show("پرونده انتخاب‌شده پیدا نشد.", "پرونده بیمار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            Text = "اصلاح پرونده بیمار";
            lblTitle.Text = "اصلاح پرونده بیمار";
            lblSubtitle.Text = "اطلاعات بیمار را ویرایش و دوباره ذخیره کنید";

            txtFirstName.Text = patient.FirstName;
            txtLastName.Text = patient.LastName;
            txtFileNumber.Text = patient.FileNumber;
            txtMobile.Text = patient.Mobile;
            _imageData = patient.ImageData;
            _imageFileName = patient.ImageFileName ?? string.Empty;
            txtImagePath.Text = string.IsNullOrWhiteSpace(_imageFileName) ? "بدون تصویر" : _imageFileName;
            ShowImage(_imageData);
        }

        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "انتخاب تصویر بیمار";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    byte[] bytes = File.ReadAllBytes(dialog.FileName);
                    using (MemoryStream stream = new MemoryStream(bytes))
                    using (Image test = Image.FromStream(stream)) { }

                    _imageData = bytes;
                    _imageFileName = Path.GetFileName(dialog.FileName);
                    txtImagePath.Text = _imageFileName;
                    ShowImage(_imageData);
                }
                catch
                {
                    MessageBox.Show("فایل انتخاب‌شده تصویر معتبر نیست.", "تصویر بیمار",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string fileNumber = txtFileNumber.Text.Trim();
            if (_database.FileNumberExists(fileNumber, _patientId))
            {
                MessageBox.Show("این شماره پرونده قبلاً برای بیمار دیگری ثبت شده است.",
                    "شماره پرونده تکراری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFileNumber.Focus();
                return;
            }

            try
            {
                PatientRecord patient = new PatientRecord
                {
                    Id = _patientId,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    FileNumber = fileNumber,
                    Mobile = txtMobile.Text.Trim(),
                    ImageData = _imageData,
                    ImageFileName = _imageFileName
                };

                _database.Save(patient);

                MessageBox.Show(
                    _patientId == 0 ? "پرونده بیمار با موفقیت ایجاد شد." : "تغییرات پرونده با موفقیت ذخیره شد.",
                    "ذخیره اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذخیره اطلاعات انجام نشد:\n" + ex.Message,
                    "خطای دیتابیس", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                return ValidationError("شماره موبایل باید فقط شامل عدد و بین 10 تا 15 رقم باشد.", txtMobile);

            if (_imageData == null || _imageData.Length == 0)
            {
                MessageBox.Show("لطفاً تصویر بیمار را انتخاب کنید.", "اطلاعات ناقص",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAttachImage.Focus();
                return false;
            }

            return true;
        }

        private bool ValidationError(string message, Control control)
        {
            MessageBox.Show(message, "اطلاعات ناقص", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }

        private void ShowImage(byte[] bytes)
        {
            if (picPatient.Image != null)
            {
                picPatient.Image.Dispose();
                picPatient.Image = null;
            }

            if (bytes == null || bytes.Length == 0)
                return;

            try
            {
                using (MemoryStream stream = new MemoryStream(bytes))
                using (Image source = Image.FromStream(stream))
                    picPatient.Image = new Bitmap(source);
            }
            catch { }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picPatient.Image != null)
                picPatient.Image.Dispose();
            base.OnFormClosed(e);
        }
    }
}
