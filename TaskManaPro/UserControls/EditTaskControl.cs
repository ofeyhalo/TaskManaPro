using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TaskTitle, TaskDescription, ListId, DueDate FROM Tasks WHERE TaskId = @TaskId", conn);
                cmd.Parameters.AddWithValue("@TaskId", TaskId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTitle.Text = reader["TaskTitle"].ToString();
                    txtDescription.Text = reader["TaskDescription"].ToString();
                    CurrentListId = (int)reader["ListId"];
                    if (reader["DueDate"] != DBNull.Value)
                        dtpDueDate.Value = (DateTime)reader["DueDate"];
                }
            }
        }

        private void LoadListOptions()
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
                cmbLists.SelectedValue = CurrentListId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            int selectedListId = (int)cmbLists.SelectedValue;
            DateTime dueDate = dtpDueDate.Value;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Tasks SET TaskTitle = @Title, TaskDescription = @Desc, ListId = @ListId, DueDate = @DueDate WHERE TaskId = @TaskId", conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Desc", description);
                cmd.Parameters.AddWithValue("@ListId", selectedListId);
                cmd.Parameters.AddWithValue("@DueDate", dueDate);
                cmd.Parameters.AddWithValue("@TaskId", TaskId);
                cmd.ExecuteNonQuery();
            }

            // Show notification if due date is within 1 day
            if ((dueDate - DateTime.Now).TotalDays <= 1)
            {
                NotificationHelper.Show("Task deadline approaching!");
            }

            MessageBox.Show("Task updated successfully.");
            this.Parent?.Controls.Remove(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
        }
    }


}
