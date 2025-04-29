namespace TaskManaPro.UserControls
{
    partial class AddListControl
    {
        private System.Windows.Forms.Button btnShowInput;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox txtListTitle;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.btnShowInput = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.txtListTitle = new System.Windows.Forms.TextBox();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.panelInput.SuspendLayout();
            this.SuspendLayout();

            // 
            // btnShowInput
            // 
            this.btnShowInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowInput.FlatAppearance.BorderSize = 1;
            this.btnShowInput.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnShowInput.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.btnShowInput.ForeColor = System.Drawing.Color.DimGray;
            this.btnShowInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowInput.Text = "+ Add another list";
            this.btnShowInput.Margin = new System.Windows.Forms.Padding(5);
            this.btnShowInput.Padding = new System.Windows.Forms.Padding(5);
            this.btnShowInput.Click += new System.EventHandler(this.btnShowInput_Click);

            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.txtListTitle);
            this.panelInput.Controls.Add(this.btnAddList);
            this.panelInput.Controls.Add(this.btnCancel);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelInput.Visible = false;

            // 
            // txtListTitle
            // 
            this.txtListTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtListTitle.Location = new System.Drawing.Point(5, 5);
            this.txtListTitle.Size = new System.Drawing.Size(160, 23);
            this.txtListTitle.PlaceholderText = "Enter list title...";

            // 
            // btnAddList
            // 
            this.btnAddList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddList.Text = "Add List";
            this.btnAddList.Location = new System.Drawing.Point(5, 35);
            this.btnAddList.Size = new System.Drawing.Size(75, 25);
            this.btnAddList.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddList.ForeColor = System.Drawing.Color.White;
            this.btnAddList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddList.FlatAppearance.BorderSize = 0;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "X";
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(85, 35);
            this.btnCancel.Size = new System.Drawing.Size(25, 25);
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // AddListControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Size = new System.Drawing.Size(180, 80);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.btnShowInput);
            this.Margin = new System.Windows.Forms.Padding(10);

            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
