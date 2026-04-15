namespace WinFormsApp12
{
    partial class UpdateStadiumForm
    {
        // Renaming the field to resolve ambiguity  
        private System.ComponentModel.IContainer components = null;
        private Button btnupdate;
        private TextBox txtCapacity;
        private TextBox txtCity;
        private TextBox txtName;
        private Label lblCapacity;
        private Label lblCity;
        private Label lblStdName;
        private Label label1;
        private Label label2;
        private TextBox txtStadiumId; // Updated field name to avoid ambiguity  

        /// <summary>  
        /// Clean up any resources being used.  
        /// </summary>  
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>  
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code  

        /// <summary>  
        /// Required method for Designer support - do not modify the contents of this method with the code editor.  
        /// </summary>  
        private void InitializeComponent()
        {
            btnupdate = new Button();
            txtCapacity = new TextBox();
            txtCity = new TextBox();
            txtName = new TextBox();
            lblCapacity = new Label();
            lblCity = new Label();
            lblStdName = new Label();
            label1 = new Label();
            label2 = new Label();
            txtStadiumId = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnupdate
            // 
            btnupdate.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnupdate.Location = new Point(750, 435);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(434, 81);
            btnupdate.TabIndex = 26;
            btnupdate.Text = "UPDATE";
            btnupdate.UseVisualStyleBackColor = true;
            btnupdate.Click += btnupdate_Click;
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCapacity.Location = new Point(305, 323);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(426, 43);
            txtCapacity.TabIndex = 19;
            // 
            // txtCity
            // 
            txtCity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCity.Location = new Point(305, 253);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(426, 43);
            txtCity.TabIndex = 20;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(305, 184);
            txtName.Name = "txtName";
            txtName.Size = new Size(426, 43);
            txtName.TabIndex = 21;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacity.Location = new Point(109, 323);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(121, 38);
            lblCapacity.TabIndex = 16;
            lblCapacity.Text = "Capacity";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCity.Location = new Point(109, 253);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(64, 38);
            lblCity.TabIndex = 17;
            lblCity.Text = "City";
            // 
            // lblStdName
            // 
            lblStdName.AutoSize = true;
            lblStdName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStdName.Location = new Point(100, 174);
            lblStdName.Name = "lblStdName";
            lblStdName.Size = new Size(199, 38);
            lblStdName.TabIndex = 18;
            lblStdName.Text = "Stadium Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(488, 24);
            label1.Name = "label1";
            label1.Size = new Size(319, 50);
            label1.TabIndex = 15;
            label1.Text = "Update Stadiums";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(100, 111);
            label2.Name = "label2";
            label2.Size = new Size(152, 38);
            label2.TabIndex = 18;
            label2.Text = "Stadium ID";
            // 
            // txtStadiumId
            // 
            txtStadiumId.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStadiumId.Location = new Point(305, 111);
            txtStadiumId.Name = "txtStadiumId";
            txtStadiumId.ReadOnly = true;
            txtStadiumId.Size = new Size(426, 43);
            txtStadiumId.TabIndex = 21;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(234, 435);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(434, 81);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // UpdateStadiumForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1367, 645);
            Controls.Add(btnCancel);
            Controls.Add(btnupdate);
            Controls.Add(txtCapacity);
            Controls.Add(txtCity);
            Controls.Add(txtName);
            Controls.Add(txtStadiumId);
            Controls.Add(lblCapacity);
            Controls.Add(lblCity);
            Controls.Add(lblStdName);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "UpdateStadiumForm";
            Text = "Update Stadium";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
    }
}
