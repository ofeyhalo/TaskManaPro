using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManaPro.UserControls
{
    public partial class ToastNotification : UserControl
    {
        private System.Windows.Forms.Timer autoCloseTimer;
        private System.Windows.Forms.Timer slideTimer;
        private int targetTop;
        private int slideSpeed = 5; // pixels per tick


        public ToastNotification(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;

            this.Visible = false; // start hidden   // start transparent

            autoCloseTimer = new System.Windows.Forms.Timer();
            autoCloseTimer.Interval = 3000; // 3 seconds
            autoCloseTimer.Tick += AutoCloseTimer_Tick;

            slideTimer = new System.Windows.Forms.Timer();
            slideTimer.Interval = 15; // faster interval for smoother animation
            slideTimer.Tick += SlideTimer_Tick;
        }

        public void ShowNotification(Form parentForm)
        {
            parentForm.Controls.Add(this);

            int startX = parentForm.ClientSize.Width - this.Width - 20; // right side with margin
            int startY = 0 - this.Height; // Start above the form

            this.Location = new Point(startX, startY);

            targetTop = 20; // where it should slide down to
            this.BringToFront();
            this.Visible = true;
            slideTimer.Start();
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            if (this.Top < targetTop)
            {
                this.Top += slideSpeed;
            }
            else
            {
                slideTimer.Stop();
                autoCloseTimer.Start();
            }
        }

        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }


        //private void InitializeComponent()
        //{
        //    this.lblMessage = new Label();
        //    this.SuspendLayout();

        //    // lblMessage
        //    this.lblMessage.Dock = DockStyle.Fill;
        //    this.lblMessage.Font = new Font("Segoe UI", 10F);
        //    this.lblMessage.ForeColor = Color.White;
        //    this.lblMessage.BackColor = Color.Transparent;
        //    this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

        //    // ToastNotification (UserControl)
        //    this.BackColor = Color.FromArgb(50, 50, 50);
        //    this.Size = new Size(300, 50);
        //    this.BorderStyle = BorderStyle.None;
        //    this.Controls.Add(this.lblMessage);
        //    this.Padding = new Padding(10);
        //    this.Margin = new Padding(5);
        //    this.BringToFront();

        //    // Rounded corners
        //    this.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

        //    this.ResumeLayout(false);
        //}

        private Label lblMessage;
    }

    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect,
            int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
