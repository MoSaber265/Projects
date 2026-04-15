namespace WinFormsApp12
{
    partial class PlayersForm
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
            btnAdd = new Button();
            label1 = new Label();
            dgvplayers = new DataGridView();
            txtPosition = new TextBox();
            txtNationality = new TextBox();
            btnDelete = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtPlayerName = new TextBox();
            label6 = new Label();
            numTshirt = new NumericUpDown();
            txtBirthDate = new TextBox();
            txtClub = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvplayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTshirt).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(152, 489);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(158, 61);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Insert";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(194, 317);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 1;
            label1.Text = "BirthDate";
            // 
            // dgvplayers
            // 
            dgvplayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvplayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvplayers.Location = new Point(694, 12);
            dgvplayers.Name = "dgvplayers";
            dgvplayers.RowHeadersWidth = 51;
            dgvplayers.Size = new Size(724, 668);
            dgvplayers.TabIndex = 3;
            dgvplayers.CellContentClick += dgvplayers_CellContentClick;
            dgvplayers.RowEnter += dgvplayers_RowEnter;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(277, 251);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(205, 27);
            txtPosition.TabIndex = 4;
            // 
            // txtNationality
            // 
            txtNationality.Location = new Point(277, 196);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(205, 27);
            txtNationality.TabIndex = 5;
            txtNationality.TextChanged += textBox3_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(452, 489);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 61);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 372);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 9;
            label2.Text = "Club";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(205, 254);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 10;
            label3.Text = "Position";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(175, 203);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 11;
            label4.Text = "Nationality";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(222, 410);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 12;
            label5.Text = "Tshirt";
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(282, 147);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(205, 27);
            txtPlayerName.TabIndex = 13;
            txtPlayerName.TextChanged += txtPlayerName_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(177, 147);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 14;
            label6.Text = "PlayerName";
            // 
            // numTshirt
            // 
            numTshirt.Location = new Point(283, 403);
            numTshirt.Name = "numTshirt";
            numTshirt.Size = new Size(150, 27);
            numTshirt.TabIndex = 15;
            // 
            // txtBirthDate
            // 
            txtBirthDate.Location = new Point(283, 314);
            txtBirthDate.Name = "txtBirthDate";
            txtBirthDate.Size = new Size(205, 27);
            txtBirthDate.TabIndex = 16;
            // 
            // txtClub
            // 
            txtClub.Location = new Point(282, 365);
            txtClub.Name = "txtClub";
            txtClub.Size = new Size(205, 27);
            txtClub.TabIndex = 17;
            txtClub.UseWaitCursor = true;
            // 
            // PlayersForm
            // 
            ClientSize = new Size(1430, 686);
            Controls.Add(txtClub);
            Controls.Add(txtBirthDate);
            Controls.Add(numTshirt);
            Controls.Add(label6);
            Controls.Add(txtPlayerName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(txtNationality);
            Controls.Add(txtPosition);
            Controls.Add(dgvplayers);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Name = "PlayersForm";
            ((System.ComponentModel.ISupportInitialize)dgvplayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTshirt).EndInit();
            ResumeLayout(false);
            PerformLayout();
            // لا يوجد أي شيء هنا
        }

        #endregion

        private Button btnAdd;
        private Label label1;
        private DataGridView dgvplayers;
        private TextBox txtPosition;
        private TextBox txtNationality;
        private Button btnDelete;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtPlayerName;
        private Label label6;
        private NumericUpDown numTshirt;
        private TextBox txtBirthDate;
        private TextBox txtClub;
    }
}
