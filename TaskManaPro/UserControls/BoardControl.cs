using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using TaskManaPro.Helpers;

namespace TaskManaPro.UserControls
{
    public partial class BoardControl : UserControl
    {
        private int boardId;

        public BoardControl(int boardId)
        {
            InitializeComponent();
            this.boardId = boardId;
            LoadLists();
        }

        private void LoadLists()
        {
            flpLists.Controls.Clear(); // Clear the current lists before reloading

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Lists WHERE BoardId = @BoardId ORDER BY SortOrder", conn);
                    cmd.Parameters.AddWithValue("@BoardId", boardId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int listId = (int)reader["ListId"];
                        string listTitle = reader["ListTitle"].ToString();

                        ListControl listControl = new ListControl(listId);
                        listControl.Title = listTitle; // Set the title for the list
                        flpLists.Controls.Add(listControl); // Add the list control to the FlowLayoutPanel
                    }

                    reader.Close(); // Close the reader explicitly
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading lists: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Optional: Add control to create a new list at the bottom of the panel
            AddAddListControl();
            NotificationHelper.Show("List added to board.");
        }

        private void AddAddListControl()
        {
            AddListControl addListControl = new AddListControl(boardId);
            flpLists.Controls.Add(addListControl);
        }

        public void ReloadLists()
        {
            LoadLists(); // Calls your existing LoadLists() method
        }

    }
}
