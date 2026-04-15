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
    public partial class UpdateLeagueForm : Form
    {
        private string conn_string = @"Server=DESKTOP-Q8TGVU9;Database=Egyptian_Primer_League_EL_25;Integrated Security=True;TrustServerCertificate=True;";
        private int clubId;
        public UpdateLeagueForm(int clubId, int matchesPlayed, int wins, int draws, int goalsFor, int goalsAgainst, int losses)

        {
            InitializeComponent();

            this.clubId = clubId;
            txtClubID.Text = clubId.ToString();
            txtMatchesPlayed.Text = matchesPlayed.ToString();
            txtWins.Text = wins.ToString();
            txtDraws.Text = draws.ToString();
            txtGoalsFor.Text = goalsFor.ToString();
            txtGoalsAgainst.Text = goalsAgainst.ToString();
            txtLosses.Text = losses.ToString();


            // Configure form appearance
            this.Text = "Update League Details";
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Optional: Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Optional: Allow resizing by dragging edges
            this.MaximizeBox = true; // Allows maximizing
            this.MinimizeBox = true; // Allows minimizing


            // Make Club ID readonly
            txtClubID.ReadOnly = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMatchesPlayed.Text) ||
                    string.IsNullOrWhiteSpace(txtWins.Text) ||
                    string.IsNullOrWhiteSpace(txtDraws.Text) ||
                    string.IsNullOrWhiteSpace(txtGoalsFor.Text) ||
                    string.IsNullOrWhiteSpace(txtGoalsAgainst.Text) ||
                    string.IsNullOrWhiteSpace(txtLosses.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string query = @"
                        UPDATE league_table SET  
                            matches_played = @matchesPlayed,
                            wins = @wins,
                            draws = @draws,
                            goals_for = @goalsFor,
                            goals_against = @goalsAgainst,
                            losses = @losses
                        WHERE club_id = @clubId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@clubId", clubId);
                        cmd.Parameters.AddWithValue("@matchesPlayed", Convert.ToInt32(txtMatchesPlayed.Text));
                        cmd.Parameters.AddWithValue("@wins", Convert.ToInt32(txtWins.Text));
                        cmd.Parameters.AddWithValue("@draws", Convert.ToInt32(txtDraws.Text));
                        cmd.Parameters.AddWithValue("@goalsFor", Convert.ToInt32(txtGoalsFor.Text));
                        cmd.Parameters.AddWithValue("@goalsAgainst", Convert.ToInt32(txtGoalsAgainst.Text));
                        cmd.Parameters.AddWithValue("@losses", Convert.ToInt32(txtLosses.Text));

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("League details updated successfully.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No record was updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
