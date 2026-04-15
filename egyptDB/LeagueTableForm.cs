using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class LeagueTableForm : Form
    {

        private string conn_string = @"Server=DESKTOP-Q8TGVU9;Database=Egyptian_Primer_League_EL_25;Integrated Security=True;TrustServerCertificate=True;";
        public LeagueTableForm()
        {
            InitializeComponent();
            LoadData();
            SetupFormElements();
        }
        private void SetupFormElements()
        {
            // Form Title
            this.Text = "League Table Management";

            // Configure DataGridView
            dgvLeagueStandings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeagueStandings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeagueStandings.ReadOnly = true;
            dgvLeagueStandings.AllowUserToAddRows = false;

            // Set numeric fields
            txtMatchesPlayed.KeyPress += NumericOnly_KeyPress;
            txtWins.KeyPress += NumericOnly_KeyPress;
            txtDraws.KeyPress += NumericOnly_KeyPress;
            txtLosses.KeyPress += NumericOnly_KeyPress;
            txtGoalsFor.KeyPress += NumericOnly_KeyPress;
            txtGoalsAgainst.KeyPress += NumericOnly_KeyPress;
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string query = @"SELECT lt.club_id, c.club_name, 
                                   lt.matches_played, lt.wins, lt.draws, lt.losses, 
                                   lt.goals_for, lt.goals_against, lt.points
                                   FROM league_table lt
                                   JOIN Clubs c ON lt.club_id = c.club_id
                                   ORDER BY lt.points DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLeagueStandings.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClubId.Text) ||
                string.IsNullOrWhiteSpace(txtMatchesPlayed.Text))
            {
                MessageBox.Show("Please fill in Club ID and Matches Played at minimum");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string query = @"INSERT INTO league_table 
                                   (club_id, matches_played, wins, draws, losses, goals_for, goals_against)
                                   VALUES (@club_id, @matches_played, @wins, @draws, @losses, @goals_for, @goals_against)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@club_id", Convert.ToInt32(txtClubId.Text));
                        cmd.Parameters.AddWithValue("@matches_played", Convert.ToInt32(txtMatchesPlayed.Text));
                        cmd.Parameters.AddWithValue("@wins", string.IsNullOrEmpty(txtWins.Text) ? 0 : Convert.ToInt32(txtWins.Text));
                        cmd.Parameters.AddWithValue("@draws", string.IsNullOrEmpty(txtDraws.Text) ? 0 : Convert.ToInt32(txtDraws.Text));
                        cmd.Parameters.AddWithValue("@losses", string.IsNullOrEmpty(txtLosses.Text) ? 0 : Convert.ToInt32(txtLosses.Text));
                        cmd.Parameters.AddWithValue("@goals_for", string.IsNullOrEmpty(txtGoalsFor.Text) ? 0 : Convert.ToInt32(txtGoalsFor.Text));
                        cmd.Parameters.AddWithValue("@goals_against", string.IsNullOrEmpty(txtGoalsAgainst.Text) ? 0 : Convert.ToInt32(txtGoalsAgainst.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                MessageBox.Show("League record added successfully");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvLeagueStandings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this league record?",
                                            "Confirm Delete",
                                            MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int clubId = Convert.ToInt32(dgvLeagueStandings.SelectedRows[0].Cells["club_id"].Value);

                    using (SqlConnection conn = new SqlConnection(conn_string))
                    {
                        string query = "DELETE FROM league_table WHERE club_id = @club_id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@club_id", clubId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }

                    MessageBox.Show("Record deleted successfully");
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLeagueStandings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this league record?",
                                        "Confirm Delete",
                                        MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int clubId = Convert.ToInt32(dgvLeagueStandings.SelectedRows[0].Cells["club_id"].Value);

                    using (SqlConnection conn = new SqlConnection(conn_string))
                    {
                        string query = "DELETE FROM league_table WHERE club_id = @club_id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@club_id", clubId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }

                    MessageBox.Show("Record deleted successfully");
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearFields()
        {
            txtClubId.Clear();
            txtMatchesPlayed.Clear();
            txtWins.Clear();
            txtDraws.Clear();
            txtLosses.Clear();
            txtGoalsFor.Clear();
            txtGoalsAgainst.Clear();
        }

        private void dgvLeagueTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLeagueStandings.Rows[e.RowIndex];
                txtClubId.Text = row.Cells["club_id"].Value.ToString();
                txtMatchesPlayed.Text = row.Cells["matches_played"].Value.ToString();
                txtWins.Text = row.Cells["wins"].Value.ToString();
                txtDraws.Text = row.Cells["draws"].Value.ToString();
                txtLosses.Text = row.Cells["losses"].Value.ToString();
                txtGoalsFor.Text = row.Cells["goals_for"].Value.ToString();
                txtGoalsAgainst.Text = row.Cells["goals_against"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvLeagueStandings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a club to update.");
                return;
            }

            DataGridViewRow row = dgvLeagueStandings.SelectedRows[0];
            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);
            int matchesPlayed = Convert.ToInt32(row.Cells["matches_played"].Value);
            int wins = Convert.ToInt32(row.Cells["wins"].Value);
            int draws = Convert.ToInt32(row.Cells["draws"].Value);
            int goalsFor = Convert.ToInt32(row.Cells["goals_for"].Value);
            int goalsAgainst = Convert.ToInt32(row.Cells["goals_against"].Value);
            int losses = Convert.ToInt32(row.Cells["losses"].Value);

            UpdateLeagueForm updateForm = new UpdateLeagueForm(clubId, matchesPlayed, wins, draws, goalsFor, goalsAgainst, losses);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Refresh the grid after update
            }
        }
    }
}


