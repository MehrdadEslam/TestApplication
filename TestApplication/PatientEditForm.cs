using System;
using System.Drawing;
using System.Drawing.Imaging;
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

        internal PatientEditForm(PatientDatabase database, long patientId = 0)
        {
            _database = database;
            _patientId = patientId;

            InitializeComponent();
            ConfigurePersianLayout();
            ConfigureInputFocusHighlight();
            ApplyApplicationIcon();
            ApplyButtonIcons();

            if (_patientId > 0)
                LoadPatient();
            else
                PrepareNewPatient();

            UpdateImageButtons();
        }

        private void ConfigurePersianLayout()
        {
            // In WinForms RTL mode, Left alignment is mirrored and is displayed
            // physically on the right side of a TextBox.
            TextBox[] inputs =
            {
                txtFirstName, txtLastName, txtFatherName,
                txtFileNumber, txtMobile, txtImagePath
            };

            foreach (TextBox input in inputs)
            {
                input.RightToLeft = RightToLeft.Yes;
                input.TextAlign = HorizontalAlignment.Left;
            }

            // Keep the Windows title bar standard while making the blue application
            // header explicitly Persian/RTL and always visible above its panel.
            pnlHeader.RightToLeft = RightToLeft.No;
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblSubtitle.RightToLeft = RightToLeft.Yes;
            lblTitle.BringToFront();
            lblSubtitle.BringToFront();
        }

        private void ConfigureInputFocusHighlight()
        {
            TextBox[] editableInputs =
            {
                txtFirstName, txtLastName, txtFatherName, txtFileNumber, txtMobile
            };

            foreach (TextBox input in editableInputs)
            {
                input.Enter += Input_EnterOrLeave;
                input.Leave += Input_EnterOrLeave;
            }

            pnlForm.Paint += pnlForm_Paint;
        }

        private void Input_EnterOrLeave(object sender, EventArgs e)
        {
            pnlForm.Invalidate();
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {
            TextBox[] editableInputs =
            {
                txtFirstName, txtLastName, txtFatherName, txtFileNumber, txtMobile
            };

            TextBox focusedInput = editableInputs.FirstOrDefault(input => input.Focused);
            if (focusedInput == null)
                return;

            Rectangle focusBorder = focusedInput.Bounds;
            focusBorder.Inflate(3, 3);

            using (Pen pen = new Pen(Color.FromArgb(218, 165, 32), 3F))
            {
                e.Graphics.DrawRectangle(pen, focusBorder);
            }
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
            btnCropCurrent.Image = UiIcons.EditIcon();
        }

        private void PrepareNewPatient()
        {
            Text = "ایجاد پرونده بیمار";
            lblTitle.Text = "ایجاد پرونده بیمار";
            lblSubtitle.Text = "اطلاعات پرونده را تکمیل کنید؛ نام پدر اختیاری است.";
            txtFirstName.Focus();
        }

        private void LoadPatient()
        {
            PatientRecord patient = _database.GetById(_patientId);
            if (patient == null)
            {
                UiMessage.Warning(this, "پرونده انتخاب‌شده پیدا نشد.", "پرونده بیمار");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            Text = "اصلاح پرونده بیمار";
            lblTitle.Text = "اصلاح پرونده بیمار";
            lblSubtitle.Text = "اطلاعات پرونده و تصویر بیمار را می‌توانید اصلاح کنید.";

            txtFirstName.Text = patient.FirstName;
            txtLastName.Text = patient.LastName;
            txtFatherName.Text = patient.FatherName;
            txtFileNumber.Text = patient.FileNumber;
            txtMobile.Text = patient.Mobile;
            _imageData = patient.ImageData;
            _imageFileName = patient.ImageFileName ?? string.Empty;
            txtImagePath.Text = string.IsNullOrWhiteSpace(_imageFileName) ? "بدون تصویر" : _imageFileName;
            ShowImage(_imageData);
            UpdateImageButtons();
        }

        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "انتخاب تصویر بیمار";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    using (Image source = Image.FromFile(dialog.FileName))
                    {
                        string outputName = Path.GetFileNameWithoutExtension(dialog.FileName) + "_cropped.png";
                        CropAndApplyImage(source, outputName);
                    }
                }
                catch (Exception ex)
                {
                    UiMessage.Warning(this, "پردازش تصویر انتخاب‌شده انجام نشد.\n" + ex.Message, "تصویر بیمار");
                }
            }
        }

        private void btnCropCurrent_Click(object sender, EventArgs e)
        {
            if (_imageData == null || _imageData.Length == 0)
            {
                UiMessage.Info(this, "برای این بیمار هنوز تصویری ثبت نشده است.", "ویرایش تصویر");
                return;
            }

            try
            {
                using (MemoryStream stream = new MemoryStream(_imageData))
                using (Image source = Image.FromStream(stream))
                using (Bitmap safeCopy = new Bitmap(source))
                {
                    string outputName = string.IsNullOrWhiteSpace(_imageFileName)
                        ? "patient_cropped.png"
                        : Path.GetFileNameWithoutExtension(_imageFileName) + "_edit.png";

                    CropAndApplyImage(safeCopy, outputName);
                }
            }
            catch (Exception ex)
            {
                UiMessage.Warning(this, "ویرایش تصویر فعلی انجام نشد.\n" + ex.Message, "ویرایش تصویر");
            }
        }

        private void CropAndApplyImage(Image source, string outputName)
        {
            using (CropImageForm cropForm = new CropImageForm(source))
            {
                if (cropForm.ShowDialog(this) != DialogResult.OK || cropForm.CroppedImage == null)
                    return;

                using (Bitmap cropped = new Bitmap(cropForm.CroppedImage))
                using (MemoryStream stream = new MemoryStream())
                {
                    cropped.Save(stream, ImageFormat.Png);
                    _imageData = stream.ToArray();
                }
            }

            _imageFileName = outputName;
            txtImagePath.Text = _imageFileName;
            ShowImage(_imageData);
            UpdateImageButtons();
        }

        private void UpdateImageButtons()
        {
            bool hasImage = _imageData != null && _imageData.Length > 0;
            btnCropCurrent.Enabled = hasImage;
            btnCropCurrent.BackColor = hasImage
                ? Color.FromArgb(239, 246, 255)
                : Color.FromArgb(248, 250, 252);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string fileNumber = txtFileNumber.Text.Trim();
            if (_database.FileNumberExists(fileNumber, _patientId))
            {
                UiMessage.Warning(this, "این شماره پرونده قبلاً برای بیمار دیگری ثبت شده است.", "شماره پرونده تکراری");
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
                    FatherName = txtFatherName.Text.Trim(),
                    FileNumber = fileNumber,
                    Mobile = txtMobile.Text.Trim(),
                    ImageData = _imageData,
                    ImageFileName = _imageFileName
                };

                _database.Save(patient);

                UiMessage.Info(this,
                    _patientId == 0 ? "پرونده بیمار با موفقیت ایجاد شد." : "تغییرات پرونده با موفقیت ذخیره شد.",
                    "ذخیره اطلاعات");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UiMessage.Error(this, "ذخیره اطلاعات انجام نشد:\n" + ex.Message, "خطای دیتابیس");
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
                UiMessage.Warning(this, "لطفاً تصویر بیمار را انتخاب و برش دهید.", "اطلاعات ناقص");
                btnAttachImage.Focus();
                return false;
            }

            return true;
        }

        private bool ValidationError(string message, Control control)
        {
            UiMessage.Warning(this, message, "اطلاعات ناقص");
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
