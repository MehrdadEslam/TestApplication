using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TestApplication
{
    internal partial class CropImageForm : Form
    {
        private readonly Bitmap _sourceImage;
        private Rectangle _selection;
        private Point _dragStart;
        private bool _dragging;

        internal Bitmap CroppedImage { get; private set; }

        internal CropImageForm(Image sourceImage)
        {
            if (sourceImage == null)
                throw new ArgumentNullException("sourceImage");

            _sourceImage = new Bitmap(sourceImage);
            InitializeComponent();
            ApplyApplicationIcon();

            picImage.Image = _sourceImage;
            Shown += CropImageForm_Shown;
        }

        private void ApplyApplicationIcon()
        {
            try { Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); }
            catch { }
        }

        private void CropImageForm_Shown(object sender, EventArgs e)
        {
            Rectangle display = GetDisplayedImageRectangle();
            if (display.Width <= 0 || display.Height <= 0)
                return;

            int width = Math.Max(80, (int)(display.Width * 0.72));
            int height = Math.Max(80, (int)(display.Height * 0.72));
            width = Math.Min(width, display.Width);
            height = Math.Min(height, display.Height);

            _selection = new Rectangle(
                display.Left + (display.Width - width) / 2,
                display.Top + (display.Height - height) / 2,
                width,
                height);

            picImage.Invalidate();
        }

        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Rectangle display = GetDisplayedImageRectangle();
            if (!display.Contains(e.Location))
                return;

            _dragging = true;
            _dragStart = e.Location;
            _selection = new Rectangle(e.X, e.Y, 1, 1);
            picImage.Invalidate();
        }

        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging)
                return;

            Rectangle display = GetDisplayedImageRectangle();
            Point current = new Point(
                Math.Max(display.Left, Math.Min(e.X, display.Right - 1)),
                Math.Max(display.Top, Math.Min(e.Y, display.Bottom - 1)));

            int left = Math.Min(_dragStart.X, current.X);
            int top = Math.Min(_dragStart.Y, current.Y);
            int right = Math.Max(_dragStart.X, current.X);
            int bottom = Math.Max(_dragStart.Y, current.Y);

            _selection = Rectangle.Intersect(
                new Rectangle(left, top, Math.Max(1, right - left), Math.Max(1, bottom - top)),
                display);

            picImage.Invalidate();
        }

        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
            picImage.Invalidate();
        }

        private void picImage_Paint(object sender, PaintEventArgs e)
        {
            if (_selection.Width <= 0 || _selection.Height <= 0)
                return;

            Rectangle display = GetDisplayedImageRectangle();
            if (display.Width <= 0 || display.Height <= 0)
                return;

            using (SolidBrush shade = new SolidBrush(Color.FromArgb(135, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(shade, display.Left, display.Top, display.Width, Math.Max(0, _selection.Top - display.Top));
                e.Graphics.FillRectangle(shade, display.Left, _selection.Bottom, display.Width, Math.Max(0, display.Bottom - _selection.Bottom));
                e.Graphics.FillRectangle(shade, display.Left, _selection.Top, Math.Max(0, _selection.Left - display.Left), _selection.Height);
                e.Graphics.FillRectangle(shade, _selection.Right, _selection.Top, Math.Max(0, display.Right - _selection.Right), _selection.Height);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen border = new Pen(Color.White, 2F))
            {
                border.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(border, _selection);
            }

            using (SolidBrush handle = new SolidBrush(Color.FromArgb(37, 99, 235)))
            {
                const int size = 9;
                Point[] points =
                {
                    new Point(_selection.Left, _selection.Top),
                    new Point(_selection.Right, _selection.Top),
                    new Point(_selection.Left, _selection.Bottom),
                    new Point(_selection.Right, _selection.Bottom)
                };

                foreach (Point point in points)
                    e.Graphics.FillEllipse(handle, point.X - size / 2, point.Y - size / 2, size, size);
            }
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            Rectangle display = GetDisplayedImageRectangle();
            Rectangle selected = Rectangle.Intersect(_selection, display);

            if (selected.Width < 10 || selected.Height < 10)
            {
                UiMessage.Info(this, "لطفاً با ماوس محدوده موردنظر برای برش تصویر را انتخاب کنید.", "برش تصویر");
                return;
            }

            float scaleX = (float)_sourceImage.Width / display.Width;
            float scaleY = (float)_sourceImage.Height / display.Height;

            Rectangle sourceRectangle = new Rectangle(
                Math.Max(0, (int)Math.Round((selected.Left - display.Left) * scaleX)),
                Math.Max(0, (int)Math.Round((selected.Top - display.Top) * scaleY)),
                Math.Max(1, (int)Math.Round(selected.Width * scaleX)),
                Math.Max(1, (int)Math.Round(selected.Height * scaleY)));

            if (sourceRectangle.Right > _sourceImage.Width)
                sourceRectangle.Width = _sourceImage.Width - sourceRectangle.Left;
            if (sourceRectangle.Bottom > _sourceImage.Height)
                sourceRectangle.Height = _sourceImage.Height - sourceRectangle.Top;

            Bitmap result = new Bitmap(sourceRectangle.Width, sourceRectangle.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(_sourceImage,
                    new Rectangle(0, 0, result.Width, result.Height),
                    sourceRectangle,
                    GraphicsUnit.Pixel);
            }

            CroppedImage = result;
            DialogResult = DialogResult.OK;
            Close();
        }

        private Rectangle GetDisplayedImageRectangle()
        {
            if (_sourceImage == null || picImage.ClientSize.Width <= 0 || picImage.ClientSize.Height <= 0)
                return Rectangle.Empty;

            float ratio = Math.Min(
                (float)picImage.ClientSize.Width / _sourceImage.Width,
                (float)picImage.ClientSize.Height / _sourceImage.Height);

            int width = (int)Math.Round(_sourceImage.Width * ratio);
            int height = (int)Math.Round(_sourceImage.Height * ratio);
            int left = (picImage.ClientSize.Width - width) / 2;
            int top = (picImage.ClientSize.Height - height) / 2;

            return new Rectangle(left, top, width, height);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            picImage.Image = null;
            _sourceImage.Dispose();
            base.OnFormClosed(e);
        }
    }
}
