using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class UpdateStadiumForm : Form
    {
        private string conn_string = @"Server=DESKTOP-Q8TGVU9;Database=Egyptian_Primer_League_EL_25;Integrated Security=True;TrustServerCertificate=True;";
        private int stadiumId;

        //as constructor 
        public UpdateStadiumForm(int id, string name, string city, int capacity)
        {
            InitializeComponent();
            stadiumId = id;
            txtName.Text = name;
            txtCity.Text = city;
            txtCapacity.Text = capacity.ToString();

            // Form configuration  
            this.Text = "Update Stadium Details";
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Optional: Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Optional: Allow resizing by dragging edges
            this.MaximizeBox = true; // Allows maximizing
            this.MinimizeBox = true; // Allows minimizing
        }

        private void UpdateStadiumForm_Load(object sender, EventArgs e)
        {
            // Set numeric input for capacity field  
            txtCapacity.KeyPress += (sender, args) =>
            {
                if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar))
                {
                    // prevent send char to field , just numric
                    args.Handled = true;
                }
            };
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtCity.Text) ||
                    string.IsNullOrWhiteSpace(txtCapacity.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string query = @"UPDATE Stadiums SET   
                                  stadium_name = @name,   
                                  city = @city,   
                                  capacity = @capacity  
                                  WHERE stadium_id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@city", txtCity.Text);
                        cmd.Parameters.AddWithValue("@capacity", Convert.ToInt32(txtCapacity.Text));
                        cmd.Parameters.AddWithValue("@id", stadiumId); // Corrected variable name  

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stadium updated successfully.");
                            //sure that operation done 
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
