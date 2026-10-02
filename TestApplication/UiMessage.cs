using System.Windows.Forms;

namespace TestApplication
{
    internal static class UiMessage
    {
        private const MessageBoxOptions RtlOptions =
            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;

        public static DialogResult Info(IWin32Window owner, string text, string caption)
        {
            return MessageBox.Show(owner, text, caption, MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, RtlOptions);
        }

        public static DialogResult Warning(IWin32Window owner, string text, string caption)
        {
            return MessageBox.Show(owner, text, caption, MessageBoxButtons.OK,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, RtlOptions);
        }

        public static DialogResult Error(IWin32Window owner, string text, string caption)
        {
            return MessageBox.Show(owner, text, caption, MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, RtlOptions);
        }

        public static DialogResult Confirm(IWin32Window owner, string text, string caption)
        {
            return MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, RtlOptions);
        }
    }
}
