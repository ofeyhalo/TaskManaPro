using System.Windows.Forms;
using TaskManaPro.UserControls;
using System.Drawing;

namespace TaskManaPro.Helpers
{
    public static class NotificationHelper
    {
        public static void Show(string message)
        {
            Form mainForm = Application.OpenForms["MainForm"];
            if (mainForm != null)
            {
                ToastNotification toast = new ToastNotification(message);
                toast.Location = new Point(mainForm.Width - toast.Width - 30, 30);
                toast.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                mainForm.Controls.Add(toast);
                toast.BringToFront();
            }
        }
    }
}
