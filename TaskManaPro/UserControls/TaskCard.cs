using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TaskManaPro.Forms;
using TaskManaPro.Helpers;

namespace TaskManaPro.UserControls
{
    public partial class TaskCard : UserControl
    {
        public int TaskId { get; private set; }
        public int ListId { get; private set; }

        private ToolTip toolTip;
        private Point mouseOffset;
        private bool isDragging;

        public string TaskTitle
        {
            get => lblTaskTitle.Text;
            set => lblTaskTitle.Text = value;
        }

        public string TaskDescription
        {
            get => lblTaskDescription.Text;
            set => lblTaskDescription.Text = value;
        }

        // Constructor when all data is available
        public TaskCard(int taskId, string taskTitle, int listId)
        {
            InitializeComponent();
            TaskId = taskId;
            ListId = listId;
            TaskTitle = taskTitle;

            LoadTaskDescription(); // Load only the description (title already set)
            InitializeDragEvents();
        }

        // Constructor when only TaskId is known
        public TaskCard(int taskId)
        {
            InitializeComponent();
            TaskId = taskId;
            LoadTaskDetails();
            InitializeDragEvents();
        }

        private void LoadTaskDetails()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load task details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTaskDescription()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TaskDescription FROM Tasks WHERE TaskId = @TaskId", conn);
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TaskDescription = reader["TaskDescription"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load task description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTaskList(int newListId)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update task list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDragEvents()
        {
            this.MouseDown += TaskCard_MouseDown;
            this.MouseMove += TaskCard_MouseMove;
            this.MouseUp += TaskCard_MouseUp;
            this.Click += TaskCard_Click;
        }

        private void TaskCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseOffset = e.Location;
                DoDragDrop(this, DragDropEffects.Move);
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

            if (this.Parent is ListControl newParent && newParent.ListId != ListId)
            {
                UpdateTaskList(newParent.ListId);
                ListId = newParent.ListId;
            }
        }

        private void TaskCard_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Task ID: {TaskId}\nTitle: {TaskTitle}\nDescription: {TaskDescription}", "Task Details");
        }

        private void picOptions_Click(object sender, EventArgs e)
        {
            var editControl = new EditTaskControl(this.TaskId);
            editControl.Dock = DockStyle.Fill;

            Form mainForm = this.FindForm();
            if (mainForm is MainForm mf)
            {
                mf.ShowEditControl(editControl);
            }
        }

        public string ToolTipText
        {
            set
            {
                if (toolTip == null)
                    toolTip = new ToolTip();
                toolTip.SetToolTip(this, value);
            }
        }
    }
}
