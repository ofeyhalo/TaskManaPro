namespace TaskManaPro.Forms
{
    partial class MainForm
    {
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.FlowLayoutPanel sidePanel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateBoard;

        private void InitializeComponent()
        {
            topPanel = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnMinimize = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            sidePanel = new System.Windows.Forms.FlowLayoutPanel();
            btnCreateBoard = new System.Windows.Forms.Button();
            mainContentPanel = new System.Windows.Forms.Panel();

            // 
            // topPanel
            // 
            topPanel.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(btnMinimize);
            topPanel.Controls.Add(btnClose);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Location = new System.Drawing.Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new System.Drawing.Size(1200, 40);
            topPanel.TabIndex = 2;

            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            lblTitle.Size = new System.Drawing.Size(200, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TaskMana Pro";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // btnMinimize
            // 
            btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMinimize.ForeColor = System.Drawing.Color.White;
            btnMinimize.Location = new System.Drawing.Point(1120, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new System.Drawing.Size(40, 40);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            // 
            // btnClose
            // 
            btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1160, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(40, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // sidePanel
            // 
            sidePanel.BackColor = System.Drawing.Color.White;
            sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            sidePanel.Location = new System.Drawing.Point(0, 40);
            sidePanel.Name = "sidePanel";
            sidePanel.Padding = new System.Windows.Forms.Padding(10);
            sidePanel.Size = new System.Drawing.Size(250, 660);
            sidePanel.TabIndex = 1;
            sidePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            sidePanel.WrapContents = false;
            sidePanel.AutoScroll = true;

            // 
            // btnCreateBoard
            // 
            btnCreateBoard.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            btnCreateBoard.FlatAppearance.BorderSize = 0;
            btnCreateBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCreateBoard.Margin = new System.Windows.Forms.Padding(5);
            btnCreateBoard.Name = "btnCreateBoard";
            btnCreateBoard.Size = new System.Drawing.Size(230, 40);
            btnCreateBoard.TabIndex = 0;
            btnCreateBoard.Text = "+ Create Board";
            btnCreateBoard.UseVisualStyleBackColor = false;
            btnCreateBoard.Click += new System.EventHandler(this.btnCreateBoard_Click);

            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainContentPanel.Location = new System.Drawing.Point(250, 40);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new System.Drawing.Size(950, 660);
            mainContentPanel.TabIndex = 0;

            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(mainContentPanel);
            this.Controls.Add(sidePanel);
            this.Controls.Add(topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
