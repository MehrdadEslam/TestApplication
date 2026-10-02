using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        private PatientDatabase _database;
        private long _selectedPatientId;

        public Form1()
        {
            InitializeComponent();
            ApplyApplicationIcon();
            ApplyToolbarIcons();

            try
            {
                _database = new PatientDatabase();
                LoadPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("راه‌اندازی دیتابیس SQLite انجام نشد:\n" + ex.Message,
                    "خطای دیتابیس", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateActionState();
        }

        private void ApplyApplicationIcon()
        {
            try { Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); }
            catch { }
        }

        private void ApplyToolbarIcons()
        {
            btnNew.Image = UiIcons.NewIcon();
            btnEdit.Image = UiIcons.EditIcon();
            btnDelete.Image = UiIcons.DeleteIcon();
            btnSearch.Image = UiIcons.SearchIcon();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseReady()) return;

            using (PatientEditForm form = new PatientEditForm(_database))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadPatients(txtSearch.Text.Trim());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseReady() || _selectedPatientId <= 0) return;

            long id = _selectedPatientId;
            using (PatientEditForm form = new PatientEditForm(_database, id))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadPatients(txtSearch.Text.Trim(), id);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!EnsureDatabaseReady() || _selectedPatientId <= 0) return;

            PatientRecord patient = _database.GetById(_selectedPatientId);
            if (patient == null) return;

            DialogResult result = MessageBox.Show(
                "آیا از حذف پرونده «" + patient.FirstName + " " + patient.LastName + "» مطمئن هستید؟\n" +
                "شماره پرونده: " + patient.FileNumber + "\n\nاین عملیات قابل بازگشت نیست.",
                "تأیید حذف پرونده",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            try
            {
                _database.Delete(_selectedPatientId);
                _selectedPatientId = 0;
                LoadPatients(txtSearch.Text.Trim());
                lblStatus.Text = "پرونده با موفقیت حذف شد";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حذف پرونده انجام نشد:\n" + ex.Message,
                    "خطای دیتابیس", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            _selectedPatientId = 0;

            if (dgvPatients.CurrentRow != null && dgvPatients.CurrentRow.Tag is PatientRecord)
                _selectedPatientId = ((PatientRecord)dgvPatients.CurrentRow.Tag).Id;

            UpdateActionState();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnEdit.Enabled)
                btnEdit.PerformClick();
        }

        private void LoadPatients(string searchText = "", long selectId = 0)
        {
            if (!EnsureDatabaseReady(false)) return;

            try
            {
                List<PatientRecord> patients = _database.Search(searchText);
                DisposeGridImages();
                dgvPatients.Rows.Clear();
                _selectedPatientId = 0;

                int rowNumber = 1;
                foreach (PatientRecord patient in patients)
                {
                    Bitmap thumbnail = CreatePatientThumbnail(patient.ImageData);
                    int index = dgvPatients.Rows.Add(
                        rowNumber++,
                        thumbnail,
                        patient.FileNumber,
                        patient.FirstName + " " + patient.LastName,
                        patient.Mobile,
                        patient.RegisteredAt,
                        patient.UpdatedAt);

                    dgvPatients.Rows[index].Tag = patient;
                }

                lblCount.Text = patients.Count + " پرونده";
                lblStatus.Text = string.IsNullOrWhiteSpace(searchText)
                    ? "نمایش لیست بیماران"
                    : "نتیجه جستجو برای «" + searchText + "»";

                if (selectId > 0)
                {
                    foreach (DataGridViewRow row in dgvPatients.Rows)
                    {
                        PatientRecord patient = row.Tag as PatientRecord;
                        if (patient != null && patient.Id == selectId)
                        {
                            row.Selected = true;
                            dgvPatients.CurrentCell = row.Cells[0];
                            _selectedPatientId = selectId;
                            break;
                        }
                    }
                }

                if (selectId == 0)
                    dgvPatients.ClearSelection();

                UpdateActionState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خواندن لیست بیماران انجام نشد:\n" + ex.Message,
                    "خطای دیتابیس", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap CreatePatientThumbnail(byte[] imageData)
        {
            const int size = 52;
            Bitmap result = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                if (imageData != null && imageData.Length > 0)
                {
                    try
                    {
                        using (MemoryStream stream = new MemoryStream(imageData))
                        using (Image source = Image.FromStream(stream))
                        {
                            float scale = Math.Min((float)size / source.Width, (float)size / source.Height);
                            int width = Math.Max(1, (int)(source.Width * scale));
                            int height = Math.Max(1, (int)(source.Height * scale));
                            int left = (size - width) / 2;
                            int top = (size - height) / 2;
                            g.DrawImage(source, new Rectangle(left, top, width, height));
                            return result;
                        }
                    }
                    catch
                    {
                    }
                }

                using (SolidBrush circle = new SolidBrush(Color.FromArgb(226, 232, 240)))
                    g.FillEllipse(circle, 6, 4, 40, 40);
                using (SolidBrush person = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    g.FillEllipse(person, 19, 11, 14, 14);
                    g.FillEllipse(person, 13, 26, 26, 20);
                }
            }

            return result;
        }

        private void DisposeGridImages()
        {
            if (dgvPatients == null || !dgvPatients.Columns.Contains("colPhoto"))
                return;

            foreach (DataGridViewRow row in dgvPatients.Rows)
            {
                Image image = row.Cells["colPhoto"].Value as Image;
                if (image != null)
                    image.Dispose();
            }
        }

        private void UpdateActionState()
        {
            bool hasSelection = _selectedPatientId > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;

            btnEdit.BackColor = hasSelection
                ? Color.FromArgb(239, 246, 255)
                : Color.FromArgb(248, 250, 252);
            btnDelete.BackColor = hasSelection
                ? Color.FromArgb(254, 242, 242)
                : Color.FromArgb(248, 250, 252);
        }

        private bool EnsureDatabaseReady(bool showMessage = true)
        {
            if (_database != null) return true;

            if (showMessage)
                MessageBox.Show("دیتابیس SQLite در دسترس نیست.", "دیتابیس",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DisposeGridImages();
            base.OnFormClosed(e);
        }
    }
}
