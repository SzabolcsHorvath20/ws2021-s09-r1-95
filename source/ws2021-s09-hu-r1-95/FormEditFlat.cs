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
    public partial class FormEditFlat : Form
    {
        private int num_of_floors, id, building_id, reference, reserved, all_floors;
        private decimal rooms, net_area, balcony_area, price;
        private string sqlwhere, orientation;

        public FormEditFlat(int all_floors, int num_of_floors, int id, int building_id, int reference, decimal rooms, string orientation, decimal net_area, decimal balcony_area, decimal price, int reserved, string sqlwhere)
        {
            InitializeComponent();
            this.all_floors = all_floors;
            this.num_of_floors = num_of_floors;
            this.id = id;
            this.building_id = building_id;
            this.reference = reference;
            this.reserved = reserved;
            this.rooms = rooms;
            this.net_area = net_area;
            this.balcony_area = balcony_area;
            this.price = price;
            this.orientation = orientation;
            this.sqlwhere = sqlwhere;
            numNetArea.DecimalPlaces = 2;
            numNetArea.ThousandsSeparator = true;
            numPrice.DecimalPlaces = 2;
            numPrice.ThousandsSeparator = true;
            numRooms.DecimalPlaces = 2;
            numRooms.ThousandsSeparator = true;
            numBalcony.DecimalPlaces = 2;
            numBalcony.ThousandsSeparator = true;
            fillcbFloor();
            fillcbOrientation();
            fillcbReserved();
            fillFields();
        }
        public Form1 ParentForm { get; set; }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            InsertFlat();
            if (ParentForm != null)
            {
                ParentForm.FlatsSelect(sqlwhere);
                ParentForm.BuildingsSelect();
            }
            Close();
        }

        private void fillcbFloor()
        {
            for (int i = 0; i < all_floors; i++)
            {
                cbFloor.Items.Add(i + 1);
            }
            cbFloor.SelectedItem = num_of_floors;
        }
        private void fillcbOrientation()
        {
            string[] orientations = { "E", "N", "NE", "NW", "S", "SE", "SW", "W" };
            foreach (var item in orientations)
            {
                cbOrientation.Items.Add(item);
            }
            cbOrientation.SelectedItem = orientation;
        }
        private void fillcbReserved()
        {
            cbReserved.Items.Add("-");
            cbReserved.Items.Add("Reserved");
            cbReserved.Items.Add("Sold");
            switch (reserved)
            {
                case 0:
                    cbReserved.SelectedIndex = 0;
                    break;
                case 1:
                    cbReserved.SelectedIndex = 1;
                    break;
                case 2:
                    cbReserved.SelectedIndex = 2;
                    break;
            }
        }
        private void fillFields()
        {
            numRef.Value = reference;
            numRooms.Value = rooms;
            numNetArea.Value = net_area;
            numPrice.Value = price;
            numBalcony.Value = balcony_area;
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
                MySqlCommand cmd = new MySqlCommand("UPDATE flats SET building_id = @building_id, ref = @ref, floor = @floor, rooms = @rooms, orientation = @orientation, net_area = @net_area, balcony_area = @balcony_area, price = @price, reserved = @reserved WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@building_id", building_id);
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
