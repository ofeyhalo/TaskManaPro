﻿using System;
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
            ListId = listId;
            LoadTasks();
        }

        public void LoadTasks()
        {
            flpTasks.Controls.Clear(); // Clear existing controls

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TaskId, TaskTitle, ListId, CreatedAt FROM Tasks WHERE ListId = @ListId ORDER BY CreatedAt", conn);
                    cmd.Parameters.AddWithValue("@ListId", ListId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int taskId = (int)reader["TaskId"];
                        string taskTitle = reader["TaskTitle"].ToString();
                        int listId = (int)reader["ListId"];
                        DateTime createdAt = reader["CreatedAt"] != DBNull.Value
                            ? (DateTime)reader["CreatedAt"]
                            : DateTime.MinValue;

                        TaskCard taskCard = new TaskCard(taskId, taskTitle, listId);
                        taskCard.ToolTipText = $"Created: {createdAt:ddd, MMM d yyyy h:mm tt}";
                        flpTasks.Controls.Add(taskCard);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //AddAddTaskButton(); // Ensure this is only added once
        }

        //private void AddAddTaskButton()
        //{
        //    // Avoid adding multiple Add buttons
        //    foreach (Control ctrl in flpTasks.Controls)
        //    {
        //        if (ctrl is Button btn && btn.Text == "+ Add Task")
        //            return;
        //    }

        //    Button addTaskBtn = new Button
        //    {
        //        Text = "+ Add Task",
        //        Dock = DockStyle.Top,
        //        Height = 30
        //    };

        //    addTaskBtn.Click += AddTaskBtn_Click;
        //    flpTasks.Controls.Add(addTaskBtn);
        //}

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            
            // Use a custom input form if preferred; fallback to input box
            string taskTitle = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter task title:", "Add Task", "");

            if (!string.IsNullOrWhiteSpace(taskTitle))
            {
                InsertTaskToDatabase(taskTitle);
                LoadTasks(); // Reload list with new task
            }
        }

        private void InsertTaskToDatabase(string taskTitle)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Tasks (TaskTitle, ListId, CreatedAt) VALUES (@Title, @ListId, GETDATE())", conn);
                    cmd.Parameters.AddWithValue("@Title", taskTitle);
                    cmd.Parameters.AddWithValue("@ListId", ListId);
                    cmd.ExecuteNonQuery();
                }

                NotificationHelper.Show("New task added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
