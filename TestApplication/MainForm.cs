using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyApplicationIcon();
        }

        private void ApplyApplicationIcon()
        {
            try
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch
            {
            }
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            using (Form1 patientsForm = new Form1())
            {
                patientsForm.ShowDialog(this);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog(this);
            }
        }
    }
}
