using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TaskManaPro.Helpers;

namespace TaskManaPro.UserControls
{
    public partial class AddListControl : UserControl
    {
        private int boardId;

        public AddListControl(int boardId)
        {
            this.boardId = boardId;
            InitializeComponent();
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

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    var getMaxOrderCmd = new SqlCommand(
                        "SELECT ISNULL(MAX(SortOrder), 0) FROM Lists WHERE BoardId = @BoardId",
                        conn
                    );
                    getMaxOrderCmd.Parameters.AddWithValue("@BoardId", boardId);
                    int maxSortOrder = (int)getMaxOrderCmd.ExecuteScalar();

                    var insertCmd = new SqlCommand(
                        "INSERT INTO Lists (BoardId, listTitle, SortOrder, CreatedAt) VALUES (@BoardId, @listTitle, @SortOrder, GETDATE())",
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

                // Reload lists from BoardControl
                if (this.Parent is FlowLayoutPanel flowPanel && flowPanel.Parent is BoardControl boardControl)
                {
                    boardControl.ReloadLists();
                }
                else
                {
                    MessageBox.Show("Error: Unable to locate BoardControl to refresh lists.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding list: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
