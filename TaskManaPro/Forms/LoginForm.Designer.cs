namespace TaskManaPro
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.Label lblNotUser; // NEW
        private System.Windows.Forms.LinkLabel linkRegister; // NEW

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.lblNotUser = new System.Windows.Forms.Label(); // NEW
            this.linkRegister = new System.Windows.Forms.LinkLabel(); // NEW
            this.SuspendLayout();

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(100, 50);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 0;

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(100, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.PasswordChar = '●';

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(100, 130);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);

            // linkForgotPassword
            this.linkForgotPassword.Location = new System.Drawing.Point(100, 170);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(200, 20);
            this.linkForgotPassword.TabIndex = 3;
            this.linkForgotPassword.Text = "Forgot Password?";
            this.linkForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblNotUser (NEW)
            this.lblNotUser.Location = new System.Drawing.Point(100, 200);
            this.lblNotUser.Name = "lblNotUser";
            this.lblNotUser.Size = new System.Drawing.Size(120, 20);
            this.lblNotUser.Text = "Not yet a user?";
            this.lblNotUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // linkRegister (NEW)
            this.linkRegister.Location = new System.Drawing.Point(220, 200);
            this.linkRegister.Name = "linkRegister";
            this.linkRegister.Size = new System.Drawing.Size(80, 25);
            this.linkRegister.TabIndex = 4;
            this.linkRegister.Text = "Register";
            this.linkRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); // Bigger font
            this.linkRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkRegister_LinkClicked);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.linkForgotPassword);
            this.Controls.Add(this.lblNotUser);
            this.Controls.Add(this.linkRegister);
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
