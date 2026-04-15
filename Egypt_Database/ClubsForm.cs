using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp12
{
    public partial class ClubsForm : Form
    {
        int current_ID = -1;

        public ClubsForm()
        {
            InitializeComponent();
            LoadClubs(); // تحميل البيانات عند فتح الفورم
        }

        // 🟢 تحميل البيانات من جدول Clubs
        private void LoadClubs()
        {
            try
            {
                string connectionString = Constants.conn_string;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Clubs";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewClubs.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // 🟢 إفراغ الحقول
        private void ResetFields()
        {
            txtClubName.Text = "";

            txtFoundationYear.Text = "";
            txtCity.Text = "";
            current_ID = -1;
        }

        // 🔵 زر الإدراج
        private void but_insert_Click(object sender, EventArgs e)
        {

        }


        // 🔴 زر الحذف
        private void but_delete_Click(object sender, EventArgs e)
        {

        }


        // 🟡 حدث عند اختيار صف في DataGridView
        private void dataGridViewClubs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewClubs.Rows[e.RowIndex];
                current_ID = Convert.ToInt32(row.Cells["club_id"].Value);
                txtClubName.Text = row.Cells["club_name"].Value.ToString();
                txtFoundationYear.Text = row.Cells["foundation_year"].Value.ToString();
                txtCity.Text = row.Cells["city"].Value.ToString();
            }
        }

        private void ClubsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddClub_Click(object sender, EventArgs e)
        {
            string clubName = txtClubName.Text.Trim();
            string city = txtCity.Text.Trim();

            if (!int.TryParse(txtFoundationYear.Text, out int foundationYear))
            {
                MessageBox.Show("Please enter a valid foundation year.");
                return;
            }

            if (string.IsNullOrWhiteSpace(clubName) || string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                string connectionString = Constants.conn_string;
                string connectionString1 = connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    string query = @"INSERT INTO Clubs (club_name, foundation_year, city)
                             VALUES (@name, @year, @city)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = clubName;
                        cmd.Parameters.Add("@year", SqlDbType.Int).Value = foundationYear;
                        cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = city;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Club '{clubName}' inserted successfully.");

                        LoadClubs();
                        ResetFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting club: " + ex.Message);
            }
        }

        //onnection_string;


        private void dgvplayers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridViewClubs.Rows[e.RowIndex];
            current_ID = Convert.ToInt32(row.Cells["club_id"].Value);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete the record?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = Constants.conn_string;
                    string query = $"DELETE FROM Clubs WHERE club_id = {current_ID}";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(query, connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        LoadClubs();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridViewClubs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
