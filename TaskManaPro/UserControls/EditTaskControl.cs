using System;
using System.Data;
using System.Windows.Forms;
using TaskManaPro.Helpers;
using Microsoft.Data.SqlClient;

namespace TaskManaPro.UserControls
{
    public partial class EditTaskControl : UserControl
    {
        public int TaskId { get; set; }
        public int CurrentListId { get; set; }

        public EditTaskControl(int taskId)
        {
            InitializeComponent();
            TaskId = taskId;

            LoadTaskDetails();
            LoadListOptions();
        }

        private void LoadTaskDetails()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TaskTitle, TaskDescription, ListId, DueDate FROM Tasks WHERE TaskId = @TaskId", conn);
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtTitle.Text = reader["TaskTitle"].ToString();
                        txtDescription.Text = reader["TaskDescription"].ToString();
                        CurrentListId = (int)reader["ListId"];

                        if (reader["DueDate"] != DBNull.Value)
                        {
                            dtpDueDate.Value = (DateTime)reader["DueDate"];
                        }
                        else
                        {
                            dtpDueDate.Value = DateTime.Today;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading task details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadListOptions()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ListId, ListTitle FROM Lists", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbLists.DataSource = dt;
                    cmbLists.DisplayMember = "ListTitle";
                    cmbLists.ValueMember = "ListId";

                    // Ensure CurrentListId is set before trying to select
                    if (CurrentListId > 0)
                    {
                        cmbLists.SelectedValue = CurrentListId;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading list options: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Task title cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedListId = (int)cmbLists.SelectedValue;
            DateTime dueDate = dtpDueDate.Value;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Tasks SET TaskTitle = @Title, TaskDescription = @Desc, ListId = @ListId, DueDate = @DueDate WHERE TaskId = @TaskId", conn);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Desc", description);
                    cmd.Parameters.AddWithValue("@ListId", selectedListId);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);

                    cmd.ExecuteNonQuery();
                }

                if ((dueDate - DateTime.Now).TotalDays <= 1)
                {
                    NotificationHelper.Show("Task deadline approaching!");
                }

                MessageBox.Show("Task updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Parent?.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
        }
    }
}
