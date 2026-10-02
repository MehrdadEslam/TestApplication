using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TestApplication
{
    internal partial class CropImageForm : Form
    {
        private const int HandleSize = 12;
        private const int MinimumSelectionSize = 40;

        private enum DragMode
        {
            None,
            NewSelection,
            Move,
            NorthWest,
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West
        }

        private readonly Bitmap _sourceImage;
        private Rectangle _selection;
        private Rectangle _dragOriginal;
        private Point _dragStart;
        private DragMode _dragMode = DragMode.None;
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

            _dragMode = HitTest(e.Location);

            if (_dragMode == DragMode.None)
            {
                _dragMode = DragMode.NewSelection;
                _selection = new Rectangle(e.X, e.Y, 1, 1);
            }

            _dragging = true;
            _dragStart = e.Location;
            _dragOriginal = _selection;
            picImage.Capture = true;
            UpdateCursor(_dragMode);
            picImage.Invalidate();
        }

        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging)
            {
                UpdateCursor(HitTest(e.Location));
                return;
            }

            Rectangle display = GetDisplayedImageRectangle();
            Point current = ClampPoint(e.Location, display);

            if (_dragMode == DragMode.NewSelection)
            {
                int left = Math.Min(_dragStart.X, current.X);
                int top = Math.Min(_dragStart.Y, current.Y);
                int right = Math.Max(_dragStart.X, current.X);
                int bottom = Math.Max(_dragStart.Y, current.Y);

                _selection = Rectangle.Intersect(
                    Rectangle.FromLTRB(left, top, Math.Max(left + 1, right), Math.Max(top + 1, bottom)),
                    display);
            }
            else if (_dragMode == DragMode.Move)
            {
                int dx = current.X - _dragStart.X;
                int dy = current.Y - _dragStart.Y;
                int newLeft = Math.Max(display.Left,
                    Math.Min(_dragOriginal.Left + dx, display.Right - _dragOriginal.Width));
                int newTop = Math.Max(display.Top,
                    Math.Min(_dragOriginal.Top + dy, display.Bottom - _dragOriginal.Height));

                _selection = new Rectangle(newLeft, newTop, _dragOriginal.Width, _dragOriginal.Height);
            }
            else
            {
                ResizeSelection(current, display);
            }

            picImage.Invalidate();
        }

        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _dragging = false;
            picImage.Capture = false;
            _dragMode = DragMode.None;
            UpdateCursor(HitTest(e.Location));
            picImage.Invalidate();
        }

        private void ResizeSelection(Point current, Rectangle display)
        {
            int left = _dragOriginal.Left;
            int top = _dragOriginal.Top;
            int right = _dragOriginal.Right;
            int bottom = _dragOriginal.Bottom;

            bool resizeLeft = _dragMode == DragMode.NorthWest ||
                              _dragMode == DragMode.West ||
                              _dragMode == DragMode.SouthWest;
            bool resizeRight = _dragMode == DragMode.NorthEast ||
                               _dragMode == DragMode.East ||
                               _dragMode == DragMode.SouthEast;
            bool resizeTop = _dragMode == DragMode.NorthWest ||
                             _dragMode == DragMode.North ||
                             _dragMode == DragMode.NorthEast;
            bool resizeBottom = _dragMode == DragMode.SouthWest ||
                                _dragMode == DragMode.South ||
                                _dragMode == DragMode.SouthEast;

            if (resizeLeft)
                left = Math.Max(display.Left, Math.Min(current.X, right - MinimumSelectionSize));
            if (resizeRight)
                right = Math.Min(display.Right, Math.Max(current.X, left + MinimumSelectionSize));
            if (resizeTop)
                top = Math.Max(display.Top, Math.Min(current.Y, bottom - MinimumSelectionSize));
            if (resizeBottom)
                bottom = Math.Min(display.Bottom, Math.Max(current.Y, top + MinimumSelectionSize));

            _selection = Rectangle.FromLTRB(left, top, right, bottom);
        }

        private DragMode HitTest(Point point)
        {
            if (_selection.Width <= 0 || _selection.Height <= 0)
                return DragMode.None;

            Point[] handles = GetHandlePoints();
            DragMode[] modes =
            {
                DragMode.NorthWest,
                DragMode.North,
                DragMode.NorthEast,
                DragMode.East,
                DragMode.SouthEast,
                DragMode.South,
                DragMode.SouthWest,
                DragMode.West
            };

            for (int i = 0; i < handles.Length; i++)
            {
                Rectangle hit = new Rectangle(
                    handles[i].X - HandleSize,
                    handles[i].Y - HandleSize,
                    HandleSize * 2,
                    HandleSize * 2);

                if (hit.Contains(point))
                    return modes[i];
            }

            if (_selection.Contains(point))
                return DragMode.Move;

            return DragMode.None;
        }

        private Point[] GetHandlePoints()
        {
            int centerX = _selection.Left + _selection.Width / 2;
            int centerY = _selection.Top + _selection.Height / 2;

            return new[]
            {
                new Point(_selection.Left, _selection.Top),
                new Point(centerX, _selection.Top),
                new Point(_selection.Right, _selection.Top),
                new Point(_selection.Right, centerY),
                new Point(_selection.Right, _selection.Bottom),
                new Point(centerX, _selection.Bottom),
                new Point(_selection.Left, _selection.Bottom),
                new Point(_selection.Left, centerY)
            };
        }

        private void UpdateCursor(DragMode mode)
        {
            switch (mode)
            {
                case DragMode.NorthWest:
                case DragMode.SouthEast:
                    picImage.Cursor = Cursors.SizeNWSE;
                    break;
                case DragMode.NorthEast:
                case DragMode.SouthWest:
                    picImage.Cursor = Cursors.SizeNESW;
                    break;
                case DragMode.North:
                case DragMode.South:
                    picImage.Cursor = Cursors.SizeNS;
                    break;
                case DragMode.East:
                case DragMode.West:
                    picImage.Cursor = Cursors.SizeWE;
                    break;
                case DragMode.Move:
                    picImage.Cursor = Cursors.SizeAll;
                    break;
                default:
                    picImage.Cursor = Cursors.Cross;
                    break;
            }
        }

        private Point ClampPoint(Point point, Rectangle bounds)
        {
            return new Point(
                Math.Max(bounds.Left, Math.Min(point.X, bounds.Right)),
                Math.Max(bounds.Top, Math.Min(point.Y, bounds.Bottom)));
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
                e.Graphics.FillRectangle(shade, display.Left, display.Top, display.Width,
                    Math.Max(0, _selection.Top - display.Top));
                e.Graphics.FillRectangle(shade, display.Left, _selection.Bottom, display.Width,
                    Math.Max(0, display.Bottom - _selection.Bottom));
                e.Graphics.FillRectangle(shade, display.Left, _selection.Top,
                    Math.Max(0, _selection.Left - display.Left), _selection.Height);
                e.Graphics.FillRectangle(shade, _selection.Right, _selection.Top,
                    Math.Max(0, display.Right - _selection.Right), _selection.Height);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen borderShadow = new Pen(Color.FromArgb(160, 15, 23, 42), 4F))
                e.Graphics.DrawRectangle(borderShadow, _selection);

            using (Pen border = new Pen(Color.White, 2F))
            {
                border.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(border, _selection);
            }

            Point[] handles = GetHandlePoints();
            int radius = HandleSize / 2;

            using (SolidBrush handleFill = new SolidBrush(Color.White))
            using (Pen handleBorder = new Pen(Color.FromArgb(37, 99, 235), 3F))
            {
                foreach (Point point in handles)
                {
                    Rectangle handleRectangle = new Rectangle(
                        point.X - radius, point.Y - radius, HandleSize, HandleSize);
                    e.Graphics.FillEllipse(handleFill, handleRectangle);
                    e.Graphics.DrawEllipse(handleBorder, handleRectangle);
                }
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
