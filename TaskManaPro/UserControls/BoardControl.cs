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
                        listControl.Title = listTitle;
                        flpLists.Controls.Add(listControl);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading lists: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AddAddListControl(); // Add the "+ Add another list" control
        }

        private void AddAddListControl()
        {
            AddListControl addListControl = new AddListControl(boardId);
            flpLists.Controls.Add(addListControl);
        }

        public void ReloadLists()
        {
            LoadLists(); // Just reuse the same list loading logic
        }
    }
}
