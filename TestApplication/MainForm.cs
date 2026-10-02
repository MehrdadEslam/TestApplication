using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class MainForm : Form
    {
        private Image _patientsMenuImage;
        private Image _settingsMenuImage;
        private Image _supportMenuImage;

        public MainForm()
        {
            InitializeComponent();
            ApplyApplicationIcon();
            LoadMenuImages();
        }

        private void ApplyApplicationIcon()
        {
            try { Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); }
            catch { }
        }

        private void LoadMenuImages()
        {
            try
            {
                string assets = Path.Combine(Application.StartupPath, "Assets");
                string patientsPath = Path.Combine(assets, "PatientsMenu.png");
                string settingsPath = Path.Combine(assets, "SettingsMenu.png");

                if (File.Exists(patientsPath))
                {
                    using (Image image = Image.FromFile(patientsPath))
                        _patientsMenuImage = new Bitmap(image);
                    picPatients.Image = _patientsMenuImage;
                }

                if (File.Exists(settingsPath))
                {
                    using (Image image = Image.FromFile(settingsPath))
                        _settingsMenuImage = new Bitmap(image);
                    picSettings.Image = _settingsMenuImage;
                }
                _supportMenuImage = UiIcons.CreateActionIcon("⚙", Color.FromArgb(14, 165, 233), 112);
                picSupport.Image = _supportMenuImage;
            }
            catch
            {
            }
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            using (Form1 patientsForm = new Form1())
                patientsForm.ShowDialog(this);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
                settingsForm.ShowDialog(this);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            using (SupportForm supportForm = new SupportForm())
                supportForm.ShowDialog(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_patientsMenuImage != null) _patientsMenuImage.Dispose();
            if (_settingsMenuImage != null) _settingsMenuImage.Dispose();
            if (_supportMenuImage != null) _supportMenuImage.Dispose();
            base.OnFormClosed(e);
        }
    }
}
