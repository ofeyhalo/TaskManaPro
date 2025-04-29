namespace TaskManaPro.UserControls
{
    partial class EditTaskControl
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.ComboBox cmbLists;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblList = new Label();
            this.cmbLists = new ComboBox();
            this.lblDueDate = new Label();
            this.dtpDueDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // Label: Title
            lblTitle.Text = "Task Title";
            lblTitle.Location = new Point(10, 10);

            // TextBox: Title
            txtTitle.Location = new Point(10, 30);
            txtTitle.Width = 300;

            // Label: Description
            lblDescription.Text = "Description";
            lblDescription.Location = new Point(10, 60);

            // TextBox: Description
            txtDescription.Location = new Point(10, 80);
            txtDescription.Multiline = true;
            txtDescription.Size = new Size(300, 60);

            // Label: List
            lblList.Text = "Move to List";
            lblList.Location = new Point(10, 150);

            // ComboBox: Lists
            cmbLists.Location = new Point(10, 170);
            cmbLists.Width = 300;

            // Label: Due Date
            lblDueDate.Text = "Due Date";
            lblDueDate.Location = new Point(10, 200);

            // DateTimePicker: Due Date
            dtpDueDate.Location = new Point(10, 220);
            dtpDueDate.Width = 300;

            // Save Button
            btnSave.Text = "Save";
            btnSave.Location = new Point(10, 260);
            btnSave.Click += btnSave_Click;

            // Cancel Button
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(100, 260);
            btnCancel.Click += btnCancel_Click;

            // Add Controls
            this.Controls.AddRange(new Control[] {
                lblTitle, txtTitle,
                lblDescription, txtDescription,
                lblList, cmbLists,
                lblDueDate, dtpDueDate,
                btnSave, btnCancel
            });

            this.Size = new Size(330, 310);
        }
    }
}
