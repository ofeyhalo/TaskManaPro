namespace TaskManaPro.UserControls
{
    partial class BoardControl
    {
        private System.Windows.Forms.Label lblBoardName;
        private System.Windows.Forms.FlowLayoutPanel flpLists;

        private void InitializeComponent()
        {
            this.lblBoardName = new System.Windows.Forms.Label();
            this.flpLists = new System.Windows.Forms.FlowLayoutPanel();

            this.SuspendLayout();

            // lblBoardName
            this.lblBoardName.Text = "Board Title";
            this.lblBoardName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBoardName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBoardName.Height = 50;
            this.lblBoardName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBoardName.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblBoardName.ForeColor = System.Drawing.Color.Black;
            this.lblBoardName.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            // flpLists
            this.flpLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLists.AutoScroll = true;
            this.flpLists.Padding = new System.Windows.Forms.Padding(15);
            this.flpLists.WrapContents = false;
            this.flpLists.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpLists.BackColor = System.Drawing.Color.White;

            // BoardControl
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.flpLists);
            this.Controls.Add(this.lblBoardName);
            this.Size = new System.Drawing.Size(1200, 700);
            this.ResumeLayout(false);
        }
    }
}
