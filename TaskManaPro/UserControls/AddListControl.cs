using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TaskManaPro.Helpers;

namespace TaskManaPro.UserControls
{
    public partial class AddListControl : UserControl
    {
        private int boardId;

        public AddListControl(int boardId)
        {
            InitializeComponent();
            this.boardId = boardId;
        }

        private void btnShowInput_Click(object sender, EventArgs e)
        {
            btnShowInput.Visible = false;
            panelInput.Visible = true;
            txtListTitle.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtListTitle.Clear();
            panelInput.Visible = false;
            btnShowInput.Visible = true;
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            string listTitle = txtListTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(listTitle))
            {
                MessageBox.Show("Please enter a list title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // Get the current max SortOrder for the board
                SqlCommand getMaxOrderCmd = new SqlCommand(
                    "SELECT ISNULL(MAX(SortOrder), 0) FROM Lists WHERE BoardId = @BoardId",
                    conn
                );
                getMaxOrderCmd.Parameters.AddWithValue("@BoardId", boardId);

                int maxSortOrder = (int)getMaxOrderCmd.ExecuteScalar();

                // Insert new list with SortOrder = max + 1
                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO Lists (BoardId, listTitle, CreatedAt, SortOrder) VALUES (@BoardId, @listTitle, GETDATE(), @SortOrder)",
                    conn
                );
                insertCmd.Parameters.AddWithValue("@BoardId", boardId);
                insertCmd.Parameters.AddWithValue("@listTitle", listTitle);
                insertCmd.Parameters.AddWithValue("@SortOrder", maxSortOrder + 1);

                insertCmd.ExecuteNonQuery();
            }


            txtListTitle.Clear();
            panelInput.Visible = false;
            btnShowInput.Visible = true;

            // Reload lists from parent (BoardControl)
            BoardControl parent = this.Parent as BoardControl;
            parent?.ReloadLists(); // You must add a public ReloadLists() method to BoardControl
        }

    }
}
