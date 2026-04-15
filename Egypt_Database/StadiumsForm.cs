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
    public partial class StadiumsForm : Form
    {
        private string conn_string = @"Server=DESKTOP-Q8TGVU9;Database=Egyptian_Primer_League_EL_25;Integrated Security=True;TrustServerCertificate=True;"; // Set your connection string here
        private int currID = -1;
        private object selectedRow;

        public StadiumsForm()
        {
            InitializeComponent();

            SetupForm();
            LoadData();
        }
        private void SetupForm()
        {
            // Form Configuration
            this.Text = "Stadium Management";

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView Configuration
            dgvStadiums.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // to select full row not cell
            dgvStadiums.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // can not make modifiy
            dgvStadiums.ReadOnly = true;
            dgvStadiums.AllowUserToAddRows = false;
            // Optional: Allow resizing
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // Optional: Center form on screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Set numeric input for capacity field
            txtcapacity.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
        }

        // ✅ Method to Load Stadium Data
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string query = "SELECT * FROM Stadiums";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);

                    if (dgvStadiums == null)
                    {
                        dgvStadiums = new DataGridView();
                        this.Controls.Add(dgvStadiums);
                    }

                    dgvStadiums.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        // ✅ Method to Add Stadium
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //to sure that all fields not empty 
                if (string.IsNullOrWhiteSpace(txtStdname.Text) || string.IsNullOrWhiteSpace(txtcity.Text) || string.IsNullOrWhiteSpace(txtcapacity.Text))
                {
                    // apper when the fields is empty
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                //make connection with database
                // using ----> to close connection after finish
                using (SqlConnection conn = new SqlConnection(conn_string))
                {

                    /// (stadium_name, city, capacity)--> attribute from database    
                    /// //(@stadium_name, @city, @capacity) ---> as parameters
                    string query = "INSERT INTO Stadiums (stadium_name, city, capacity) VALUES (@stadium_name, @city, @capacity)";
                    // to use querys
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // to send data from form to database
                        cmd.Parameters.AddWithValue("@stadium_name", txtStdname.Text);
                        cmd.Parameters.AddWithValue("@city", txtcity.Text);
                        cmd.Parameters.AddWithValue("@capacity", Convert.ToInt32(txtcapacity.Text));
                        // to open connection 
                        conn.Open();
                        // to execute query ----> using with insert , delete , update
                        cmd.ExecuteNonQuery();
                        // to close connection
                        conn.Close();
                    }
                }

                MessageBox.Show("Stadium added successfully.");
                // load data to datagrid view
                LoadData();
                // make fields empty
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // ✅ Method to Delete Stadium
        private void btnDelete_Click(object sender, EventArgs e)
        {
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
        }

        // ✅ Method to Clear Fields
        private void ClearFields()
        {
            txtStdname.Clear();
            txtcity.Clear();
            txtcapacity.Clear();
        }

        // ✅ Optional: Show Button (To Refresh Data)
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // ✅ DataGridView Click Event (Selects Row)
        private void dgvStadiums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ((DataGridView)dgvStadiums).Rows[e.RowIndex];
                currID = Convert.ToInt32(row.Cells["stadium_id"].Value);
                txtStdname.Text = row.Cells["stadium_name"].Value.ToString();
                txtcity.Text = row.Cells["city"].Value.ToString();
                txtcapacity.Text = row.Cells["capacity"].Value.ToString();
            }
        }

        private void btnShow_Click_1(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvStadiums.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a stadium to update.");
                return;
            }

            // Get selected stadium data
            DataGridViewRow row = dgvStadiums.SelectedRows[0];
            try
            {
                // Get values from the selected row
                int stadiumId = Convert.ToInt32(row.Cells["stadium_id"].Value);
                string name = row.Cells["stadium_name"].Value.ToString();
                string city = row.Cells["city"].Value.ToString();
                int capacity = Convert.ToInt32(row.Cells["capacity"].Value);

                // Open the update form
                UpdateStadiumForm updateForm = new UpdateStadiumForm(stadiumId, name, city, capacity);
                // make form not close else we finish
                updateForm.ShowDialog();

                // Refresh data after the update form closes
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing update: {ex.Message}");
            }


        }

        private void dgvStadiums_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStadiums.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvStadiums.SelectedRows[0];
                currID = Convert.ToInt32(row.Cells["stadium_id"].Value);
                txtStdname.Text = row.Cells["stadium_name"].Value.ToString();
                txtcity.Text = row.Cells["city"].Value.ToString();
                txtcapacity.Text = row.Cells["capacity"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}

