using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TaskManaPro.Forms;
using TaskManaPro.Helpers;
using System.Data;


namespace TaskManaPro.UserControls
{
    public partial class TaskCard : UserControl
    {
        public int TaskId { get; set; }
        public int ListId { get; set; }

        private Point mouseOffset;
        private bool isDragging;

        public string TaskTitle
        {
            get { return lblTaskTitle.Text; }
            set { lblTaskTitle.Text = value; }
        }

        public string TaskDescription
        {
            get { return lblTaskDescription.Text; }
            set { lblTaskDescription.Text = value; }
        }

        // New constructor with TaskId and TaskTitle
        public TaskCard(int taskId, string taskTitle, int listId)
        {
            InitializeComponent();
            TaskId = taskId;
            TaskTitle = taskTitle;
            ListId = listId;
            LoadTaskDetails();

            // Enable mouse dragging
            this.MouseDown += TaskCard_MouseDown;
        }

        public TaskCard(int taskId)
        {
            InitializeComponent();
            TaskId = taskId;
            LoadTaskDetails();
        }

        private void LoadTaskDetails()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TaskTitle, TaskDescription, ListId FROM Tasks WHERE TaskId = @TaskId", conn);
                cmd.Parameters.AddWithValue("@TaskId", TaskId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TaskTitle = reader["TaskTitle"].ToString();
                    TaskDescription = reader["TaskDescription"].ToString();
                    ListId = (int)reader["ListId"];
                }
            }
        }

        private void UpdateTaskList(int newListId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Tasks SET ListId = @NewListId WHERE TaskId = @TaskId", conn);
                cmd.Parameters.AddWithValue("@NewListId", newListId);
                cmd.Parameters.AddWithValue("@TaskId", TaskId);
                cmd.ExecuteNonQuery();
            }
        }

        private void TaskCard_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Task ID: {TaskId}\nTitle: {TaskTitle}\nDescription: {TaskDescription}");
        }

        private void TaskCard_MouseDown(object sender, MouseEventArgs e)
        {
            // Start dragging the task card when the left mouse button is pressed
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(this, DragDropEffects.Move); // Initiate the drag operation
            }
        }

        private void TaskCard_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Left += e.X - mouseOffset.X;
                this.Top += e.Y - mouseOffset.Y;
            }
        }

        private void TaskCard_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            ListControl newParent = this.Parent as ListControl;
            if (newParent != null && newParent.ListId != ListId)
            {
                UpdateTaskList(newParent.ListId);
                ListId = newParent.ListId;
            }
        }

        private void picOptions_Click(object sender, EventArgs e)
        {
            var editControl = new EditTaskControl(this.TaskId); // Pass task ID
            editControl.Dock = DockStyle.Fill;

            // Show on top of the parent form or mainContentPanel
            Form mainForm = this.FindForm();
            if (mainForm is MainForm mf)
            {
                mf.ShowEditControl(editControl); // You'll create this method next
            }
        }

    }
}
