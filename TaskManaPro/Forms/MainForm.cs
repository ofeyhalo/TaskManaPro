using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TaskManaPro.Helpers;
using TaskManaPro.UserControls;

namespace TaskManaPro.Forms
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private int _userId;

        public MainForm() : this(1) // <- passes dummy 1
        {
        }


        public MainForm(int userId)
        {
            InitializeComponent();
            _userId = userId; // Default userId
            MakeDraggable();
            LoadBoards();
        }

        // Enable dragging the window by clicking and holding the top panel
        private void MakeDraggable()
        {
            this.topPanel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
        }

        // Load boards from the database and add buttons for each one
        private void LoadBoards()
        {
            sidePanel.Controls.Clear();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Boards WHERE UserId = @UserId", conn);
                cmd.Parameters.AddWithValue("@UserId", _userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Button btn = new Button
                    {
                        Text = reader["BoardName"].ToString(),
                        Width = sidePanel.Width - 20,
                        Height = 40,
                        BackColor = Color.LightSteelBlue,
                        Tag = (int)reader["BoardId"]
                    };
                    btn.Click += Btn_Click;
                    btn.Margin = new Padding(5);
                    sidePanel.Controls.Add(btn);
                }
            }

            // ✅ Ensure CreateBoard button is always shown
            sidePanel.Controls.Add(btnCreateBoard);
        }


        // Handle board button click, load the corresponding board
        private void Btn_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            int boardId = (int)clicked.Tag;

            mainContentPanel.Controls.Clear();  // Clear existing board contents

            // Create and add the BoardControl for the selected board
            BoardControl boardControl = new BoardControl(boardId);
            boardControl.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(boardControl);
        }

        // Button click to create a new board
        private void btnCreateBoard_Click(object sender, EventArgs e)
        {
            string boardName = Microsoft.VisualBasic.Interaction.InputBox("Enter board name:", "Create New Board", "My Board");

            if (!string.IsNullOrWhiteSpace(boardName))
            {
                int boardId = InsertBoardToDatabase(boardName);
                if (boardId > 0)
                {
                    LoadBoards();  // Reload the boards list
                    LoadBoard(boardId); // Load the newly created board
                }
            }
            NotificationHelper.Show("Board created successfully!");
        }

        // Insert a new board into the database and return the new BoardId
        private int InsertBoardToDatabase(string boardName)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Boards (BoardName, UserId, CreatedAt) OUTPUT INSERTED.BoardId VALUES (@BoardName, @UserId, GETDATE())",
                    conn
                );
                cmd.Parameters.AddWithValue("@BoardName", boardName);
                cmd.Parameters.AddWithValue("@UserId", _userId);

                return (int)cmd.ExecuteScalar();
            }
        }

        // Load the selected board by BoardId
        private void LoadBoard(int boardId)
        {
            mainContentPanel.Controls.Clear();  // Clear any existing controls

            // Create and add the BoardControl for the selected board
            BoardControl boardControl = new BoardControl(boardId);
            boardControl.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(boardControl);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowEditControl(UserControl control)
        {
            control.BringToFront();
            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(control);
        }

        public void ShowEditControlOverlay(UserControl control)
        {
            Panel overlay = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(180, 0, 0, 0), // translucent black
            };

            control.Anchor = AnchorStyles.None;
            control.BackColor = Color.White;
            control.Location = new Point((overlay.Width - control.Width) / 2, (overlay.Height - control.Height) / 2);
            control.BringToFront();

            overlay.Controls.Add(control);
            mainContentPanel.Controls.Add(overlay);
            overlay.BringToFront();
        }


    }
}
