using System;
using System.Windows.Forms;
using TaskManaPro.Forms; // ✅ IMPORTANT! Make sure this line exists

namespace TaskManaPro
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show LoginForm first
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK) // If login is successful
            {
                // Pass the userId to MainForm
                int userId = loginForm.UserId; // Assuming you store the userId on successful login
                Application.Run(new MainForm(userId));
            }
        }
    }
}
