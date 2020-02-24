using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws2021_s09_hu_r1_95
{
    public partial class FormEditBuilding : Form
    {
        private int id, min_floor;

        public FormEditBuilding(int id, string name, int num_of_floors, string address)
        {
            InitializeComponent();
            numNoF.Value = num_of_floors;
            tbAddressBuilding.Text = address;
            tbNameBuilding.Text = name;
            this.id = id;
            MinFloor();
        }

        public void MinFloor()
        {
            Program.sql.CommandText = "SELECT MAX(num_of_floors) FROM `buildings` WHERE id = " + id;
            try
            {
                using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        min_floor = dataReader.GetInt32("MAX(num_of_floors)");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditBuilding()
        {
            if (String.IsNullOrWhiteSpace(tbAddressBuilding.Text) == false && String.IsNullOrWhiteSpace(tbNameBuilding.Text) == false && numNoF.Value > 0)
            {
                MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder
                {
                    Server = "localhost",
                    Port = 3306,
                    UserID = "skill09-95",
                    Password = "Shanghai2021",
                    Database = "skills_it_95",
                    CharacterSet = "utf8"
                };
                MySqlConnection conn = new MySqlConnection(sb.ToString());
                MySqlCommand cmd = new MySqlCommand("UPDATE buildings SET name = @name, num_of_floors = @num_of_floors, address = @address WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", tbNameBuilding.Text);
                cmd.Parameters.AddWithValue("@num_of_floors", numNoF.Value);
                cmd.Parameters.AddWithValue("@address", tbAddressBuilding.Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public Form1 ParentForm { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbAddressBuilding.Text) == true || String.IsNullOrWhiteSpace(tbNameBuilding.Text) == true)
            {
                DialogResult dialog = MessageBox.Show("You need to fill every field!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numNoF.Value < 1)
            {
                DialogResult dialog = MessageBox.Show("Can't have a building with 0 floors!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numNoF.Value < min_floor)
            {
                DialogResult dialog = MessageBox.Show("The building already has flats on floor " + min_floor, "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EditBuilding();
                if (ParentForm != null)
                {
                    ParentForm.BuildingsSelect();
                }
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
