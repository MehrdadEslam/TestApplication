using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            ApplyApplicationIcon();
            LoadSystemInformation();
            LoadAppearanceSettings();
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

        private void LoadSystemInformation()
        {
            try
            {
                PatientDatabase database = new PatientDatabase();
                txtDatabasePath.Text = database.DatabasePath;
                lblDatabaseStatus.Text = "SQLite فعال و آماده استفاده است";
                lblDatabaseStatus.ForeColor = Color.FromArgb(22, 163, 74);
            }
            catch (Exception ex)
            {
                txtDatabasePath.Text = "-";
                lblDatabaseStatus.Text = "خطا در اتصال به SQLite: " + ex.Message;
                lblDatabaseStatus.ForeColor = Color.FromArgb(185, 28, 28);
            }
        }

        private void LoadAppearanceSettings()
        {
            pnlFocusColorPreview.BackColor = Color.FromArgb(Properties.Settings.Default.FocusBorderColorArgb);
        }

        private void btnChooseFocusColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = pnlFocusColorPreview.BackColor;
                dialog.FullOpen = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                SaveFocusBorderColor(dialog.Color);
            }
        }

        private void btnResetFocusColor_Click(object sender, EventArgs e)
        {
            SaveFocusBorderColor(Color.FromArgb(218, 165, 32));
        }

        private void SaveFocusBorderColor(Color color)
        {
            pnlFocusColorPreview.BackColor = color;
            Properties.Settings.Default.FocusBorderColorArgb = color.ToArgb();
            Properties.Settings.Default.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
