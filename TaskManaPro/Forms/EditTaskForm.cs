using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TaskManaPro.Helpers;

namespace TaskManaPro.Forms
{
    public partial class EditTaskForm : Form
    {
        public int TaskId { get; private set; }

        public EditTaskForm(int taskId, string taskTitle)
        {
            InitializeComponent();
            TaskId = taskId;
            txtTitle.Text = taskTitle;
            LoadTaskDetails();
        }

        private void LoadTaskDetails()
        {
            string query = "SELECT TaskTitle, TaskDescription, DueDate FROM Tasks WHERE TaskId = @TaskId";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTitle.Text = reader["TaskTitle"].ToString();
                            txtDescription.Text = reader["TaskDescription"].ToString();

                            if (reader["DueDate"] != DBNull.Value)
                                dtpDueDate.Value = Convert.ToDateTime(reader["DueDate"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Tasks SET TaskTitle = @Title, TaskDescription = @Description, DueDate = @DueDate WHERE TaskId = @TaskId";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Task updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
