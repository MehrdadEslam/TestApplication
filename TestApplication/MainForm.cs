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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_patientsMenuImage != null) _patientsMenuImage.Dispose();
            if (_settingsMenuImage != null) _settingsMenuImage.Dispose();
            base.OnFormClosed(e);
        }
    }
}
