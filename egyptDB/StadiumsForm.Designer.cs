
using Microsoft.Data.SqlClient;

namespace WinFormsApp12
{
    partial class StadiumsForm
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
            label1 = new Label();
            lblStdName = new Label();
            txtStdname = new TextBox();
            lblCity = new Label();
            txtcity = new TextBox();
            lblCapacity = new Label();
            txtcapacity = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnShow = new Button();
            dgvStadiums = new DataGridView();
            label2 = new Label();
            btnback = new Button();
            btnupdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStadiums).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(457, 23);
            label1.Name = "label1";
            label1.Size = new Size(182, 50);
            label1.TabIndex = 0;
            label1.Text = "Stadiums";
            label1.Click += label1_Click;
            // 
            // lblStdName
            // 
            lblStdName.AutoSize = true;
            lblStdName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStdName.Location = new Point(72, 138);
            lblStdName.Name = "lblStdName";
            lblStdName.Size = new Size(199, 38);
            lblStdName.TabIndex = 1;
            lblStdName.Text = "Stadium Name";
            lblStdName.Click += this.lblStdName_Click;
            // 
            // txtStdname
            // 
            txtStdname.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStdname.Location = new Point(277, 138);
            txtStdname.Name = "txtStdname";
            txtStdname.Size = new Size(426, 43);
            txtStdname.TabIndex = 2;
            txtStdname.TextChanged += this.txtStdname_TextChanged;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCity.Location = new Point(81, 217);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(64, 38);
            lblCity.TabIndex = 1;
            lblCity.Text = "City";
            lblCity.Click += this.lblCity_Click;
            // 
            // txtcity
            // 
            txtcity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcity.Location = new Point(277, 217);
            txtcity.Name = "txtcity";
            txtcity.Size = new Size(426, 43);
            txtcity.TabIndex = 2;
            txtcity.TextChanged += this.txtcity_TextChanged;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacity.Location = new Point(81, 304);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(121, 38);
            lblCapacity.TabIndex = 1;
            lblCapacity.Text = "Capacity";
            lblCapacity.Click += this.lblCapacity_Click;
            // 
            // txtcapacity
            // 
            txtcapacity.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcapacity.Location = new Point(277, 304);
            txtcapacity.Name = "txtcapacity";
            txtcapacity.Size = new Size(426, 43);
            txtcapacity.TabIndex = 2;
            txtcapacity.TextChanged += this.txtcapacity_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Lime;
            btnAdd.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(600, 362);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 77);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += button1_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ImageAlign = ContentAlignment.BottomRight;
            btnDelete.Location = new Point(277, 362);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 77);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += button2_Click;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.Silver;
            btnShow.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShow.Location = new Point(600, 445);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(103, 77);
            btnShow.TabIndex = 3;
            btnShow.Text = "SHOW";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click_1;
            // 
            // dgvStadiums
            // 
            dgvStadiums.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStadiums.BackgroundColor = SystemColors.Desktop;
            dgvStadiums.BorderStyle = BorderStyle.None;
            dgvStadiums.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStadiums.GridColor = SystemColors.MenuText;
            dgvStadiums.Location = new Point(793, 138);
            dgvStadiums.Name = "dgvStadiums";
            dgvStadiums.ReadOnly = true;
            dgvStadiums.RowHeadersWidth = 51;
            dgvStadiums.Size = new Size(346, 446);
            dgvStadiums.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(925, 70);
            label2.Name = "label2";
            label2.Size = new Size(91, 50);
            label2.TabIndex = 0;
            label2.Text = "LIST";
            // 
            // btnback
            // 
            btnback.BackColor = SystemColors.ScrollBar;
            btnback.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnback.Location = new Point(277, 444);
            btnback.Name = "btnback";
            btnback.Size = new Size(103, 75);
            btnback.TabIndex = 5;
            btnback.Text = "BACK";
            btnback.UseVisualStyleBackColor = false;
            btnback.Click += btnback_Click;
            // 
            // btnupdate
            // 
            btnupdate.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnupdate.Location = new Point(412, 410);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(159, 81);
            btnupdate.TabIndex = 14;
            btnupdate.Text = "UPDATE";
            btnupdate.UseVisualStyleBackColor = true;
            btnupdate.Click += btnupdate_Click;
            // 
            // StadiumsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1173, 641);
            Controls.Add(btnupdate);
            Controls.Add(btnback);
            Controls.Add(dgvStadiums);
            Controls.Add(btnShow);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtcapacity);
            Controls.Add(txtcity);
            Controls.Add(txtStdname);
            Controls.Add(lblCapacity);
            Controls.Add(lblCity);
            Controls.Add(lblStdName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "StadiumsForm";
            Text = "Form1";
            Load += StadiumsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStadiums).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void txtcapacity_TextChanged(object sender, EventArgs e)
        {
         //   throw new NotImplementedException();
        }

        private void lblCapacity_Click(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void txtcity_TextChanged(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void lblCity_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtStdname_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void lblStdName_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StadiumsForm_Load(object sender, EventArgs e)
        {
            // Optionally call LoadData() here if needed
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e) {
            try
            {
                if (((DataGridView)dgvStadiums).SelectedRows.Count > 0)
                {
                    var res = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        int stadiumID = Convert.ToInt32(((DataGridView)dgvStadiums).SelectedRows[0].Cells["stadium_id"].Value);

                        using (SqlConnection conn = new SqlConnection(conn_string))
                        {
                            string query = "DELETE FROM Stadiums WHERE stadium_id = @id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", stadiumID);
                                conn.Open();
                                int rows = cmd.ExecuteNonQuery();
                                conn.Close();

                                if (rows > 0)
                                    MessageBox.Show("Stadium deleted successfully.");
                                else
                                    MessageBox.Show("No record found to delete.");
                            }
                        }

                        LoadData();
                        ClearFields();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a stadium to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            //LoadData();
        }

        private void button1_Click(object sender, EventArgs e) {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStdname.Text) ||
                    string.IsNullOrWhiteSpace(txtcity.Text) ||
                    string.IsNullOrWhiteSpace(txtcapacity.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string query = "INSERT INTO Stadiums (stadium_name, city, capacity) VALUES (@stadium_name, @city, @capacity)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@stadium_name", txtStdname.Text);
                        cmd.Parameters.AddWithValue("@city", txtcity.Text);
                        cmd.Parameters.AddWithValue("@capacity", Convert.ToInt32(txtcapacity.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                MessageBox.Show("Stadium added successfully.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            //LoadData();
        }

        #endregion

        private Label label1;
        private Label lblStdName;
        private TextBox txtStdname;
        private Label lblCity;
        private TextBox txtcity;
        private Label lblCapacity;
        private TextBox txtcapacity;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnShow;
        private DataGridView dgvStadiums;
        private Label label2;
        private Button btnback;
        private Button btnupdate;
    }
}