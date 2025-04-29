namespace TaskManaPro.UserControls
{
    partial class ListControl
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private Label lblTitle;
        private FlowLayoutPanel flpTasks;
        private Button btnAddTask;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Required method for Designer support.
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "List Title";

            // 
            // flpTasks
            // 
            this.flpTasks.AutoScroll = true;
            this.flpTasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTasks.Location = new System.Drawing.Point(15, 45);
            this.flpTasks.Name = "flpTasks";
            this.flpTasks.Size = new System.Drawing.Size(220, 300); // Adjust size as needed
            this.flpTasks.TabIndex = 1;
            this.flpTasks.WrapContents = false;

            // 
            // btnAddTask
            // 
            this.btnAddTask.Text = "+ Add Task";
            this.btnAddTask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddTask.Height = 35;
            this.btnAddTask.Click += new System.EventHandler(this.AddTaskBtn_Click);
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(0, 123, 255); // Blue background for the button
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.TabIndex = 2;

            // 
            // ListControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.flpTasks);
            this.Controls.Add(this.btnAddTask);
            this.Name = "ListControl";
            this.Size = new System.Drawing.Size(250, 400); // Adjust size as needed
            this.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
