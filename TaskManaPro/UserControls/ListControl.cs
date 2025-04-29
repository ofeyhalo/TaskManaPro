using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using TaskManaPro.Helpers;

namespace TaskManaPro.UserControls
{
    public partial class ListControl : UserControl
    {
        public int ListId { get; private set; }

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public ListControl(int listId)
        {
            InitializeComponent();
            this.ListId = listId;
            LoadTasks();
        }

        public void LoadTasks()
        {
            flpTasks.Controls.Clear();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tasks WHERE ListId = @ListId ORDER BY CreatedAt", conn);
                cmd.Parameters.AddWithValue("@ListId", ListId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int taskId = (int)reader["TaskId"];
                    string taskTitle = reader["TaskTitle"].ToString();
                    int listId = (int)reader["ListId"];

                    TaskCard taskCard = new TaskCard(taskId, taskTitle, listId); // You’ll create this next
                    flpTasks.Controls.Add(taskCard);
                }
            }

            AddAddTaskCard();
        }

        private void AddAddTaskCard()
        {
            Button addTaskBtn = new Button();
            addTaskBtn.Text = "+ Add Task";
            addTaskBtn.Dock = DockStyle.Top;
            addTaskBtn.Height = 30;
            addTaskBtn.Click += AddTaskBtn_Click;

            flpTasks.Controls.Add(addTaskBtn);
        }

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            // You can replace this with a custom 'AddTaskCard' control if needed
            string taskTitle = Microsoft.VisualBasic.Interaction.InputBox("Enter task title:", "Add Task", "");

            if (!string.IsNullOrWhiteSpace(taskTitle))
            {
                InsertTaskToDatabase(taskTitle);
                LoadTasks(); // Refresh task list
            }
        }

        private void InsertTaskToDatabase(string taskTitle)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tasks (TaskTitle, ListId, CreatedAt) VALUES (@Title, @ListId, GETDATE())", conn);
                cmd.Parameters.AddWithValue("@Title", taskTitle);
                cmd.Parameters.AddWithValue("@ListId", ListId);
                cmd.ExecuteNonQuery();
            }
            NotificationHelper.Show("New task added!");
        }
    }
}
