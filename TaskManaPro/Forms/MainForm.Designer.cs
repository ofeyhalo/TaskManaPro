namespace TaskManaPro.Forms
{
    partial class MainForm
    {
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateBoard;

        private void InitializeComponent()
        {
            topPanel = new Panel();
            lblTitle = new Label();
            btnMinimize = new Button();
            btnClose = new Button();
            sidePanel = new Panel();
            btnCreateBoard = new Button();
            mainContentPanel = new Panel();
            topPanel.SuspendLayout();
            sidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(44, 62, 80);
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(btnMinimize);
            topPanel.Controls.Add(btnClose);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1200, 40);
            topPanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10, 0, 0, 0);
            lblTitle.Size = new Size(200, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TaskMana Pro";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1120, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 40);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "_";
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1160, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.White;
            sidePanel.Controls.Add(btnCreateBoard);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 40);
            sidePanel.Name = "sidePanel";
            sidePanel.Padding = new Padding(10);
            sidePanel.Size = new Size(250, 660);
            sidePanel.TabIndex = 1;
            // 
            // btnCreateBoard
            // 
            btnCreateBoard.BackColor = Color.FromArgb(220, 220, 220);
            btnCreateBoard.Dock = DockStyle.Top;
            btnCreateBoard.FlatAppearance.BorderSize = 0;
            btnCreateBoard.FlatStyle = FlatStyle.Flat;
            btnCreateBoard.Location = new Point(10, 10);
            btnCreateBoard.Margin = new Padding(5);
            btnCreateBoard.Name = "btnCreateBoard";
            btnCreateBoard.Size = new Size(230, 40);
            btnCreateBoard.TabIndex = 0;
            btnCreateBoard.Text = "+ Create Board";
            btnCreateBoard.UseVisualStyleBackColor = false;
            btnCreateBoard.Click += btnCreateBoard_Click;
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.WhiteSmoke;
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(250, 40);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(950, 660);
            mainContentPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1200, 700);
            Controls.Add(mainContentPanel);
            Controls.Add(sidePanel);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            topPanel.ResumeLayout(false);
            sidePanel.ResumeLayout(false);
            ResumeLayout(false);
        }


    }

}