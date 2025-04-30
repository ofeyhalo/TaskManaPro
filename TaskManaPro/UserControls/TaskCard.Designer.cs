using TaskManaPro.Properties;

namespace TaskManaPro.UserControls
{
    partial class TaskCard
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private Label lblTaskTitle;
        private Label lblTaskDescription;
        private PictureBox picOptions;

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
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.picOptions = new PictureBox();

            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.AutoSize = true;
            this.lblTaskTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTaskTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTaskTitle.TabIndex = 0;
            this.lblTaskTitle.Text = "Task Title";

            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.AutoSize = true;
            this.lblTaskDescription.Font = new System.Drawing.Font("Arial", 8F);
            this.lblTaskDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblTaskDescription.Location = new System.Drawing.Point(10, 30);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(99, 14);
            this.lblTaskDescription.TabIndex = 1;
            this.lblTaskDescription.Text = "Task Description";

            // 
            // TaskCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTaskTitle);
            this.Controls.Add(this.lblTaskDescription);
            this.Cursor = System.Windows.Forms.Cursors.Hand; // Makes it look clickable
            this.Name = "TaskCard";
            this.Size = new System.Drawing.Size(220, 60); // Adjust size as needed
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskCard_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskCard_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TaskCard_MouseUp);
            this.Click += new System.EventHandler(this.TaskCard_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

            //// picOptions (three dots)
            //using var _ =

            //// picOptions (three dots)
            //this.picOptions.Image = Properties.Resources.icon_more_vert_24; // Add your 3-dot icon to Resources
            //this.picOptions.SizeMode = PictureBoxSizeMode.CenterImage;
            //this.picOptions.Size = new Size(24, 24);
            //this.picOptions.Location = new Point(this.Width - 30, 5); // Top-right corner
            //this.picOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //this.picOptions.Cursor = Cursors.Hand;
            //this.picOptions.Click += picOptions_Click;
            //this.Controls.Add(this.picOptions);
        }
    }
}
