namespace TaskManaPro.UserControls
{
    partial class ListControl
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpTasks;
        private System.Windows.Forms.Button btnAddTask;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            flpTasks = new FlowLayoutPanel();
            btnAddTask = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(74, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "List Title";
            // 
            // flpTasks
            // 
            flpTasks.AutoScroll = true;
            flpTasks.FlowDirection = FlowDirection.TopDown;
            flpTasks.Location = new Point(15, 45);
            flpTasks.Name = "flpTasks";
            flpTasks.Size = new Size(220, 316);
            flpTasks.TabIndex = 1;
            flpTasks.WrapContents = false;
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.CornflowerBlue;
            btnAddTask.FlatAppearance.BorderSize = 0;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Location = new Point(3, 367);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(244, 30);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "+ Add Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += AddTaskBtn_Click;
            // 
            // ListControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblTitle);
            Controls.Add(flpTasks);
            Controls.Add(btnAddTask);
            Margin = new Padding(10, 0, 10, 10);
            Name = "ListControl";
            Size = new Size(250, 400);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
