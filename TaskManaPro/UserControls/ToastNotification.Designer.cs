namespace TaskManaPro.UserControls
{
    partial class ToastNotification
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.lblMessage = new Label();
            this.SuspendLayout();

            // lblMessage
            this.lblMessage.Dock = DockStyle.Fill;
            this.lblMessage.Font = new Font("Segoe UI", 10F);
            this.lblMessage.ForeColor = Color.White;
            this.lblMessage.BackColor = Color.Transparent;
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            // ToastNotification (UserControl)
            this.BackColor = Color.FromArgb(50, 50, 50);
            this.Size = new Size(300, 50);
            this.BorderStyle = BorderStyle.None;
            this.Controls.Add(this.lblMessage);
            this.Padding = new Padding(10);
            this.Margin = new Padding(5);
            this.BringToFront();

            // Rounded corners
            this.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            this.ResumeLayout(false);

        }

        #endregion
    }
}
