namespace TaskManaPro.Forms
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Create Your Account";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // txtName
            this.txtName.PlaceholderText = "Full Name";
            this.txtName.Location = new System.Drawing.Point(50, 80);
            this.txtName.Size = new System.Drawing.Size(300, 30);

            // txtEmail
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.Location = new System.Drawing.Point(50, 130);
            this.txtUsername.Size = new System.Drawing.Size(300, 30);

            // txtPassword
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Location = new System.Drawing.Point(50, 180);
            this.txtPassword.Size = new System.Drawing.Size(300, 30);

            // txtConfirmPassword
            this.txtConfirmPassword.PlaceholderText = "Confirm Password";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(50, 230);
            this.txtConfirmPassword.Size = new System.Drawing.Size(300, 30);

            // btnRegister
            this.btnRegister.Text = "Register";
            this.btnRegister.Location = new System.Drawing.Point(50, 290);
            this.btnRegister.Size = new System.Drawing.Size(300, 40);
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // RegistrationForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
