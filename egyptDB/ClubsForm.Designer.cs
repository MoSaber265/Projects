namespace WinFormsApp12
{
    partial class ClubsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewClubs = new DataGridView();
            label1 = new Label();
            txtClubName = new TextBox();
            txtCity = new TextBox();
            txtFoundationYear = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnAddClub = new Button();
            btnDeleteClub = new Button();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClubs).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewClubs
            // 
            dataGridViewClubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClubs.GridColor = SystemColors.Info;
            dataGridViewClubs.Location = new Point(700, 5);
            dataGridViewClubs.Name = "dataGridViewClubs";
            dataGridViewClubs.RowHeadersWidth = 51;
            dataGridViewClubs.Size = new Size(757, 625);
            dataGridViewClubs.TabIndex = 0;
            dataGridViewClubs.CellContentClick += dataGridViewClubs_CellContentClick;
            dataGridViewClubs.RowEnter += dgvplayers_RowEnter;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 8;
            // 
            // txtClubName
            // 
            txtClubName.Location = new Point(219, 161);
            txtClubName.Name = "txtClubName";
            txtClubName.Size = new Size(258, 27);
            txtClubName.TabIndex = 2;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(219, 307);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(258, 27);
            txtCity.TabIndex = 3;
            // 
            // txtFoundationYear
            // 
            txtFoundationYear.Location = new Point(219, 234);
            txtFoundationYear.Name = "txtFoundationYear";
            txtFoundationYear.Size = new Size(258, 27);
            txtFoundationYear.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 314);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 5;
            label2.Text = "City";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 241);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 6;
            label3.Text = "Foundation Year";
            // 
            // btnAddClub
            // 
            btnAddClub.Location = new Point(97, 448);
            btnAddClub.Name = "btnAddClub";
            btnAddClub.Size = new Size(201, 67);
            btnAddClub.TabIndex = 7;
            btnAddClub.Text = "Insert";
            btnAddClub.UseVisualStyleBackColor = true;
            btnAddClub.Click += btnAddClub_Click;
            // 
            // btnDeleteClub
            // 
            btnDeleteClub.Location = new Point(0, 0);
            btnDeleteClub.Name = "btnDeleteClub";
            btnDeleteClub.Size = new Size(75, 23);
            btnDeleteClub.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(130, 164);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 9;
            label4.Text = "Club Name\t";
            // 
            // button1
            // 
            button1.Location = new Point(395, 448);
            button1.Name = "button1";
            button1.Size = new Size(170, 67);
            button1.TabIndex = 10;
            button1.Text = "Delete ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Emoji", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(113, 25);
            button2.Name = "button2";
            button2.Size = new Size(452, 75);
            button2.TabIndex = 11;
            button2.Text = "Club";
            button2.UseVisualStyleBackColor = true;
            // 
            // ClubsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1469, 642);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(btnDeleteClub);
            Controls.Add(btnAddClub);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtFoundationYear);
            Controls.Add(txtCity);
            Controls.Add(txtClubName);
            Controls.Add(label1);
            Controls.Add(dataGridViewClubs);
            Name = "ClubsForm";
            Text = "Form2";
            Load += ClubsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClubs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewClubs;
        private Label label1;
        private TextBox txtClubName;
        private TextBox txtCity;
        private TextBox txtFoundationYear;
        private Label label2;
        private Label label3;
        private Button btnAddClub;
        private Button btnDeleteClub;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}