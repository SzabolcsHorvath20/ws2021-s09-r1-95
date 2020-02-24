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
    public partial class FormAddFlat : Form
    {
        private int num_of_floors, id;
        private string sqlwhere;

        public FormAddFlat(int num_of_floors, int id, string sqlwhere)
        {
            InitializeComponent();
            this.num_of_floors = num_of_floors;
            this.id = id;
            this.sqlwhere = sqlwhere;
            fillcbFloor();
            fillcbOrientation();
            fillcbReserved();
        }

        private void fillcbFloor()
        {
            for (int i = 0; i < num_of_floors; i++)
            {
                cbFloor.Items.Add(i+1);
            }
            cbFloor.SelectedIndex = 0;
        }
        private void fillcbOrientation()
        {
            string[] orientations = {"E", "N", "NE", "NW", "S", "SE", "SW", "W"};
            foreach (var item in orientations)
            {
                cbOrientation.Items.Add(item);
            }
            cbOrientation.SelectedIndex = 0;
        }
        private void fillcbReserved()
        {
            cbReserved.Items.Add("-");
            cbReserved.Items.Add("Reserved");
            cbReserved.Items.Add("Sold");
            cbReserved.SelectedIndex = 0;
        }

        public void InsertFlat()
        {
            if (numNetArea.Value > 0 && numPrice.Value > 0 && numRef.Value > 0 && numRooms.Value > 0)
            {
                int reserved = 0;
                switch (cbReserved.SelectedItem.ToString())
                {
                    case "-":
                        reserved = 0;
                        break;
                    case "Reserved":
                        reserved = 1;
                        break;
                    case "Sold":
                        reserved = 2;
                        break;
                }
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO flats (building_id, ref, floor, rooms, orientation, net_area, balcony_area, price, reserved) " +
                                                    "VALUES (@building_id, @ref, @floor, @rooms, @orientation, @net_area, @balcony_area, @price, @reserved)", conn);
                cmd.Parameters.AddWithValue("@building_id", id);
                cmd.Parameters.AddWithValue("@ref", numRef.Value);
                cmd.Parameters.AddWithValue("@floor", cbFloor.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@rooms", numRooms.Value);
                cmd.Parameters.AddWithValue("@orientation", cbOrientation.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@net_area", numNetArea.Value);
                cmd.Parameters.AddWithValue("@balcony_area", numBalcony.Value);
                cmd.Parameters.AddWithValue("@price", numPrice.Value);
                cmd.Parameters.AddWithValue("@reserved", reserved);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Form1 ParentForm { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertFlat();
            if (ParentForm != null)
            {
                ParentForm.FlatsSelect(sqlwhere);
                ParentForm.BuildingsSelect();
            }
            Close();
        }
    }
}
