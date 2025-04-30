
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TaskManaPro.Forms
{
    public partial class EditTaskForm : Form
    {
        public int TaskId { get; set; }

        public EditTaskForm(int taskId, string taskTitle)
        {
            InitializeComponent();
            this.TaskId = taskId;
            txtTitle.Text = taskTitle;
            LoadTask(taskId);
        }

        private void LoadTask(int taskId)
        {
            string connectionString = "Data Source=.;Initial Catalog=TaskManaDB;Integrated Security=True";
            string query = "SELECT Title, Description, DueDate FROM Tasks WHERE TaskId = @TaskId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TaskId", taskId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTitle.Text = reader["Title"].ToString();
                    txtDescription.Text = reader["Description"].ToString();
                    dtpDueDate.Value = Convert.ToDateTime(reader["DueDate"]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=TaskManaDB;Integrated Security=True";
            string query = "UPDATE Tasks SET Title = @Title, Description = @Description, DueDate = @DueDate WHERE TaskId = @TaskId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                cmd.Parameters.AddWithValue("@TaskId", TaskId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Task updated successfully.");
            this.Close();
        }
    }
}
