using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        private string _attachedImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "انتخاب تصویر";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|All Files|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK) return;

                _attachedImagePath = dialog.FileName;
                txtImagePath.Text = _attachedImagePath;

                try
                {
                    if (picPatientImage.Image != null)
                    {
                        picPatientImage.Image.Dispose();
                        picPatientImage.Image = null;
                    }

                    using (var tempImage = Image.FromFile(_attachedImagePath))
                        picPatientImage.Image = new Bitmap(tempImage);
                }
                catch
                {
                    MessageBox.Show("فایل انتخاب‌شده یک تصویر معتبر نیست.", "خطا",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _attachedImagePath = string.Empty;
                    txtImagePath.Clear();
                    picPatientImage.Image = null;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                string safeFileNumber = MakeSafeFileName(txtFileNumber.Text.Trim());
                string recordsRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PatientRecords");
                string patientFolder = Path.Combine(recordsRoot, safeFileNumber);
                Directory.CreateDirectory(patientFolder);

                string imageExtension = Path.GetExtension(_attachedImagePath);
                string savedImagePath = Path.Combine(patientFolder, "Attachment" + imageExtension);
                File.Copy(_attachedImagePath, savedImagePath, true);

                string infoPath = Path.Combine(patientFolder, "PatientInfo.txt");
                string patientInfo =
                    "نام: " + txtFirstName.Text.Trim() + Environment.NewLine +
                    "نام خانوادگی: " + txtLastName.Text.Trim() + Environment.NewLine +
                    "شماره پرونده: " + txtFileNumber.Text.Trim() + Environment.NewLine +
                    "شماره موبایل: " + txtMobile.Text.Trim() + Environment.NewLine +
                    "فایل تصویر: " + Path.GetFileName(savedImagePath) + Environment.NewLine +
                    "تاریخ ثبت: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                File.WriteAllText(infoPath, patientInfo, System.Text.Encoding.UTF8);

                MessageBox.Show("پرونده بیمار با موفقیت ذخیره شد.\n" + patientFolder,
                    "ثبت موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هنگام ذخیره پرونده خطایی رخ داد:\n" + ex.Message,
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrWhiteSpace(_attachedImagePath) || !File.Exists(_attachedImagePath))
            {
                MessageBox.Show("لطفاً یک فایل تصویر به پرونده Attach کنید.",
                    "اطلاعات ناقص", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private string MakeSafeFileName(string value)
        {
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
                value = value.Replace(invalidChar, '_');
            return value;
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFileNumber.Clear();
            txtMobile.Clear();
            txtImagePath.Clear();
            _attachedImagePath = string.Empty;

            if (picPatientImage.Image != null)
            {
                picPatientImage.Image.Dispose();
                picPatientImage.Image = null;
            }

            txtFirstName.Focus();
        }
    }
}
