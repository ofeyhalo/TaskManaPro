using System;
using System.Windows.Forms;
using TaskManaPro.Forms;
using TaskManaPro.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;


namespace TaskManaPro
{
    public partial class LoginForm : Form
    {

        public int UserId { get; private set; } = -1;


        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            int userId = AuthenticateUser(username, password);
            if (userId > 0)
            {
                UserId = userId;  // Set the UserId for later use
                this.DialogResult = DialogResult.OK;  // Close the login form and return success
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void LinkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            using (RegistrationForm registrationForm = new RegistrationForm()) 
            { 
                registrationForm.ShowDialog(); 
            }
                
        }


        private int AuthenticateUser(string username, string password)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserId, PasswordHash FROM Users WHERE Username = @Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Check if PasswordHash is null
                    object passwordHashObj = reader["PasswordHash"];
                    if (passwordHashObj != DBNull.Value)
                    {
                        string hash = passwordHashObj.ToString();  // Safe to convert
                        if (BCrypt.Net.BCrypt.Verify(password, hash))
                        {
                            return (int)reader["UserId"];
                        }
                    }
                }
            }
            return -1;
        }

    }

}
