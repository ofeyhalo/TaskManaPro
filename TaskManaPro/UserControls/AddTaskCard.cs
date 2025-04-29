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
    public partial class AddTaskCard : UserControl
    {
        public int ListId { get; set; }

        public AddTaskCard(int listId)
        {
            InitializeComponent();
            ListId = listId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string taskTitle = txtTaskTitle.Text;
            //string taskDescription = txtTaskDescription.Text;

            // Insert into database
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tasks (ListId, TaskTitle, TaskDescription) VALUES (@ListId, @TaskTitle, @TaskDescription)", conn);
                cmd.Parameters.AddWithValue("@ListId", ListId);
                cmd.Parameters.AddWithValue("@TaskTitle", taskTitle);
                //cmd.Parameters.AddWithValue("@TaskDescription", taskDescription);
                cmd.ExecuteNonQuery();
            }

            // Refresh the list after adding
            ListControl parentList = (ListControl)this.Parent;
            parentList.LoadTasks();
        }
    }

}
