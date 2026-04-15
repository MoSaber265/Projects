using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp12
{
    public partial class PlayersForm : Form
    {
        int current_ID = -1;
        public PlayersForm()
        {
            InitializeComponent();
            LoadPlayers();
        }

        // ========== يتم استدعاؤها عند تحميل الفورم ========== 
        private void PlayersForm_Load(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            try
            {
                string connectionString = Constants.conn_string;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Players";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvplayers.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ========== دوال غير مفعّلة بعد ========== 
        private void dgvplayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvplayers.Rows[e.RowIndex];

                txtPlayerName.Text = row.Cells["player_name"].Value.ToString();
                txtBirthDate.Text = row.Cells["birth_date"].Value.ToString();
                txtNationality.Text = row.Cells["nationality"].Value.ToString();
                txtPosition.Text = row.Cells["position"].Value.ToString();
                numTshirt.Value = Convert.ToInt32(row.Cells["tshirt_num"].Value);
                txtClub.Text = row.Cells["club_name"].Value.ToString();

                // ✅ أضف هذا السطر لتحديث current_ID
                current_ID = Convert.ToInt32(row.Cells["player_id"].Value);
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        // ========== زر الإضافة ========== 
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Please enter all required fields.");
                return;
            }

            try
            {
                string connectionString = Constants.conn_string;

                string query = @"
            INSERT INTO Players (player_name, birth_date, nationality, position, club_id, tshirt_num) 
            VALUES (@PlayerName, @BirthDate, @Nationality, @Position, @ClubId, @TshirtNumber)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerName", txtPlayerName.Text);
                    command.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(txtBirthDate.Text));
                    command.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                    command.Parameters.AddWithValue("@Position", txtPosition.Text);
                    command.Parameters.AddWithValue("@ClubId", GetClubId(txtClub.Text)); // تأكد أن هذه الدالة تعمل بشكل صحيح
                    command.Parameters.AddWithValue("@TshirtNumber", numTshirt.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Player inserted successfully.");
                    LoadPlayers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // ========== زر الحذف ========== 


        private void dgvplayers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvplayers.Rows[e.RowIndex];
            current_ID = Convert.ToInt32(row.Cells["player_id"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                    string query = $"DELETE FROM Players WHERE player_id = {current_ID}";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(query, connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        LoadPlayers(); // إعادة تحميل البيانات بعد الحذف
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        // ========== التحقق من الإدخال ========== 
        private bool ValidateInput()
        {
            return !string.IsNullOrWhiteSpace(txtPlayerName.Text)
                && !string.IsNullOrWhiteSpace(txtNationality.Text)
                && !string.IsNullOrWhiteSpace(txtPosition.Text)
                && !string.IsNullOrWhiteSpace(txtClub.Text);
        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {

        }

        // Assuming this method exists to get the ClubId based on the club name
        private int GetClubId(string clubName)
        {
            // You can implement this to get the ClubId from the Clubs table
            return 1; // Just for example, replace with real logic.
        }
    }
}
