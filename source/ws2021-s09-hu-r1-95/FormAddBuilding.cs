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
    public partial class FormAddBuilding : Form
    {
        public FormAddBuilding()
        {
            InitializeComponent();
        }
        public void InsertBuilding()
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO buildings (name, num_of_floors, address) VALUES (@name, @num_of_floors, @address)", conn);
                cmd.Parameters.AddWithValue("@name", tbNameBuilding.Text);
                cmd.Parameters.AddWithValue("@num_of_floors", numNoF.Value);
                cmd.Parameters.AddWithValue("@address", tbAddressBuilding.Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public Form1 ParentForm { get; set; }

        private void btnSaveBuilding_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbAddressBuilding.Text) == true || String.IsNullOrWhiteSpace(tbNameBuilding.Text) == true)
            {
                DialogResult dialog = MessageBox.Show("You need to fill every field!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numNoF.Value < 1)
            {
                DialogResult dialog = MessageBox.Show("Can't create a building with 0 floors!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InsertBuilding();
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
