using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestApplication
{
    internal static class UiIcons
    {
        public static Bitmap CreateActionIcon(string glyph, Color color, int size = 38)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (SolidBrush shadow = new SolidBrush(Color.FromArgb(35, 15, 23, 42)))
                    g.FillEllipse(shadow, 3, 4, size - 6, size - 6);

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(2, 2, size - 5, size - 5),
                    ControlPaint.Light(color, 0.25f),
                    color,
                    45f))
                {
                    g.FillEllipse(brush, 2, 2, size - 6, size - 6);
                }

                using (Pen pen = new Pen(Color.FromArgb(90, Color.White), 1.2f))
                    g.DrawEllipse(pen, 3, 3, size - 8, size - 8);

                using (Font font = new Font("Segoe UI Symbol", size * 0.48f, FontStyle.Bold, GraphicsUnit.Pixel))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(glyph, font, textBrush, new RectangleF(0, 0, size - 1, size - 2), format);
                }
            }

            return bitmap;
        }

        public static Bitmap NewIcon() { return CreateActionIcon("+", Color.FromArgb(16, 185, 129)); }
        public static Bitmap EditIcon() { return CreateActionIcon("✎", Color.FromArgb(37, 99, 235)); }
        public static Bitmap DeleteIcon() { return CreateActionIcon("×", Color.FromArgb(239, 68, 68)); }
        public static Bitmap SearchIcon() { return CreateActionIcon("⌕", Color.FromArgb(14, 165, 233)); }
        public static Bitmap SaveIcon() { return CreateActionIcon("✓", Color.FromArgb(22, 163, 74)); }
        public static Bitmap ImageIcon() { return CreateActionIcon("▣", Color.FromArgb(99, 102, 241)); }
    }
}
