namespace TaskManaPro.UserControls
{
    partial class AddTaskCard
    {
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Dock = DockStyle.Top;
            this.txtTaskTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskTitle.PlaceholderText = "Enter task title...";
            this.txtTaskTitle.Margin = new Padding(5);
            this.txtTaskTitle.Height = 30;
            // 
            // btnSave
            // 
            this.btnSave.Dock = DockStyle.Bottom;
            this.btnSave.Text = "Save";
            this.btnSave.BackColor = Color.LightSkyBlue;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Height = 30;
            this.btnSave.Click += btnSave_Click; // You define this
                                                 // 
                                                 // AddTaskCard
                                                 // 
            this.BackColor = Color.WhiteSmoke;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.btnSave);
            this.Size = new System.Drawing.Size(200, 70);
            this.Margin = new Padding(5);
            this.ResumeLayout(false);
        }
    }

}
