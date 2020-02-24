using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ws2021_s09_hu_r1_95
{
    public partial class Form1 : Form
    {
        private int num_of_floors, id, all_floors, building_id;
        private string address, name;
        private string sql = "SELECT * FROM `flats`";
        private string sqlwhere = "SELECT * FROM `flats` WHERE reserved <> -1";
        private string sqleditflat;
        private bool sum = false;
        private string file;
        private List<List<string>> singularBuildings = new List<List<string>>();
        private ListViewColumnSorter lvwColumnSorter;

        public Form1()
        {
            InitializeComponent();
            FlatListColumns();
            BuildingListColumns();
            FlatListColumnsCustomers();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvFlat.ListViewItemSorter = lvwColumnSorter;
        }

        //Properties

        public void BuildingListColumns()
        {
            lvBuilding.FullRowSelect = true;
            lvBuilding.View = View.Details;
            lvBuilding.GridLines = true;
            lvBuilding.Columns.Add("id", -2, HorizontalAlignment.Center);
            lvBuilding.Columns.Add("    Buildings    ", -2, HorizontalAlignment.Center);
            lvBuilding.Columns.Add("Floors", -2, HorizontalAlignment.Center);
            lvBuilding.Columns.Add("Flats", -2, HorizontalAlignment.Center);
            lvBuilding.Columns.Add("Sold", -2, HorizontalAlignment.Center);
            lvBuilding.Columns.Add("Reserved", -2, HorizontalAlignment.Center);
            lvBuilding.Columns.Add("For Sale", -2, HorizontalAlignment.Center);
            lvBuilding.Columns[0].Width = 0;
            BuildingsSelect();
        }
        public void FlatListColumns()
        {
            lvFlat.FullRowSelect = true;
            lvFlat.GridLines = true;
            lvFlat.ShowItemToolTips = true;
            lvFlat.View = View.Details;
            lvFlat.Columns.Add("id", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("tooltip", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("REF", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("Floor", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("Rooms", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("Net Area", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("Balcony", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("Orientation", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("Price", -2, HorizontalAlignment.Center);
            lvFlat.Columns.Add("Reserved", -2, HorizontalAlignment.Center);
            lvFlat.Columns[0].Width = 0;
            lvFlat.Columns[1].Width = 0;
            FlatsSelect(sql);
        }
        public void BuildingsSelect()
        {
            List<List<string>> rows = new List<List<string>>();
            lvBuilding.Items.Clear();
            Program.sql.CommandText = "SELECT b.id, b.name, b.num_of_floors, b.address, COUNT(f.id) as flats FROM `flats` f RIGHT JOIN buildings b ON b.id = f.building_id GROUP BY b.id UNION SELECT b.id, b.name, b.num_of_floors, b.address, COUNT(f.id) as flats FROM `flats` f RIGHT JOIN buildings b ON b.id = f.building_id WHERE f.building_id IS NULL GROUP BY b.id order by id";
            try
            {
                using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        List<string> row = new List<string>();
                        row.Add(dataReader.GetInt32("id").ToString());
                        row.Add(dataReader.GetString("name"));
                        row.Add(dataReader.GetUInt32("num_of_floors").ToString());
                        row.Add(dataReader.GetString("flats"));
                        rows.Add(row);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 2; i > -1; i--)
            {
                Program.sql.CommandText = "SELECT b.id, b.name, b.num_of_floors, b.address, COUNT(f.id) as flats FROM `flats` f RIGHT JOIN buildings b ON b.id = f.building_id WHERE reserved = "+ i + " GROUP BY b.id UNION SELECT b.id, b.name, b.num_of_floors, b.address, COUNT(f.id) as flats FROM `flats` f RIGHT JOIN buildings b ON b.id = f.building_id WHERE f.building_id IS NULL GROUP BY b.id order by id";
                try
                {
                    using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            rows[dataReader.GetInt32("id") - 1].Add(Convert.ToString(dataReader.GetInt32("flats")));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            foreach (var item in rows)
            {
                item.Add("0");
            }
            foreach (var item in rows)
            {
                int helper = Convert.ToInt32(item[item.Count - 3]) - (Convert.ToInt32(item[item.Count - 1]) + Convert.ToInt32(item[item.Count - 2]));
                //item[item.Count-1] = Convert.ToString(Convert.ToString(helper));
            }
            foreach (var item in rows)
            {
                string[] listdata = new string[7];
                for (int i = 0; i < item.Count()-1; i++)
                {
                    listdata[i] = item[i];
                }
                lvBuilding.Items.Add(new ListViewItem(listdata));
            }
        }
        public void FlatsSelect(string sql)
        {
            lvFlat.Items.Clear();
            Program.sql.CommandText = sql;
            string reserved = "";
            try
            {
                using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        switch (dataReader.GetInt32("reserved"))
                        {
                            case 0:
                                reserved = "For Sale";
                                break;
                            case 1:
                                reserved = "Reserved";
                                break;
                            case 2:
                                reserved = "Sold";
                                break;
                        }
                        string[] row = { dataReader.GetInt32("id").ToString(),
                            Convert.ToString((Convert.ToDecimal(dataReader.GetDouble("net_area")) + Convert.ToDecimal(dataReader.GetDouble("balcony_area"))) / 2),
                            "#" + dataReader.GetInt32("ref").ToString(),
                            dataReader.GetInt32("floor").ToString(),
                            Convert.ToString(Math.Round(dataReader.GetDouble("rooms"),1)),
                            Convert.ToString(Math.Round(dataReader.GetDouble("net_area"),1)),
                            Convert.ToString(Math.Round(dataReader.GetDouble("balcony_area"),1)),
                            dataReader.GetString("orientation"),
                            Convert.ToString(Math.Round(dataReader.GetDouble("price"),1)) + "M",
                            reserved
                            };
                        ListViewItem listViewItem = new ListViewItem(row);
                        lvFlat.Items.Add(listViewItem);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            FlatsSelect(sql);
            sqlwhere = "SELECT * FROM `flats` WHERE reserved <> -1";
            sum = true;
        }

        private void btnSold_Click(object sender, EventArgs e)
        {
            sum = false;
            if (lvBuilding.SelectedItems.Count > 0)
            {
                FlatsSelect(sql + " WHERE reserved = 2 AND building_id = " + (lvBuilding.FocusedItem.SubItems[0].Text));
                sqlwhere = sql + " WHERE reserved = 2";
            }
            else
            {
                FlatsSelect(sql + " WHERE reserved = 2");
                sqlwhere = sql + " WHERE reserved = 2";
            }
        }

        private void btnReserved_Click(object sender, EventArgs e)
        {
            sum = false;
            if (lvBuilding.SelectedItems.Count > 0)
            {
                FlatsSelect(sql + " WHERE reserved = 1 AND building_id = " + (lvBuilding.FocusedItem.SubItems[0].Text));
                sqlwhere = sql + " WHERE reserved = 1";
            }
            else
            {
                FlatsSelect(sql + " WHERE reserved = 1");
                sqlwhere = sql + " WHERE reserved = 1";
            }
        }

        private void btnForSale_Click(object sender, EventArgs e)
        {
            sum = false;
            if (lvBuilding.SelectedItems.Count > 0)
            {
                FlatsSelect(sql + " WHERE reserved = 0 AND building_id = " + (lvBuilding.FocusedItem.SubItems[0].Text));
                sqlwhere = sql + " WHERE reserved = 0";
            }
            else
            {
                FlatsSelect(sql + " WHERE reserved = 0");
                sqlwhere = sql + " WHERE reserved = 0";
            }
        }

        private void groupProperties_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lvBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlatsSelect(sqlwhere + " AND building_id = " + (lvBuilding.FocusedItem.SubItems[0].Text));
            Program.sql.CommandText = "SELECT id, num_of_floors, name, address FROM `buildings` WHERE id = " + (lvBuilding.FocusedItem.SubItems[0].Text);
            using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    id = dataReader.GetInt32("id");
                    address = dataReader.GetString("address");
                    name = dataReader.GetString("name");
                    num_of_floors = dataReader.GetInt32("num_of_floors");
                }
            }


        }

        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            FormAddBuilding formAddBuilding = new FormAddBuilding();
            formAddBuilding.ParentForm = this;
            formAddBuilding.Show();
        }

        private void lvFlat_MouseHover(object sender, EventArgs e)
        {

        }

        private void lvFlat_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if ((this.Bounds.X + 455 + 170) < Cursor.Position.X && (this.Bounds.X + 455 + 247) > Cursor.Position.X)
            {
                Point point = lvFlat.PointToClient(Cursor.Position);
                point.X = point.X + 15;
                toolTip1.Show(e.Item.SubItems[1].Text, lvFlat, point);
            }
        }

        private void lvFlat_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvFlat.Columns[4].Index || e.Column == lvFlat.Columns[5].Index || e.Column == lvFlat.Columns[6].Index || e.Column == lvFlat.Columns[8].Index)
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }

                // Perform the sort with these new sort options.
                this.lvFlat.Sort();
            }
        }

        private void lvFlat_DoubleClick(object sender, EventArgs e)
        {
            if (sum)
            {
                sqleditflat = sql;
            }
            else if (lvBuilding.SelectedItems.Count > 0)
            {
                sqleditflat = sqlwhere + " AND building_id = " + (lvBuilding.FocusedItem.SubItems[0].Text);
            }
            else
            {
                sqleditflat = sql;
            }
            Program.sql.CommandText = "SELECT building_id FROM `flats` WHERE id = " + lvFlat.FocusedItem.SubItems[0].Text;
            try
            {
                using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        building_id = dataReader.GetInt32("building_id");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Program.sql.CommandText = "SELECT num_of_floors FROM `buildings` WHERE id = " + building_id;
            try
            {
                using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        all_floors = dataReader.GetInt32("num_of_floors");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Program.sql.CommandText = "SELECT * FROM `flats` WHERE id = " + lvFlat.FocusedItem.SubItems[0].Text;
            try
            {
                using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        FormEditFlat formEditFlat = new FormEditFlat(all_floors, dataReader.GetInt32("floor"), dataReader.GetInt32("id"), dataReader.GetInt32("building_id"), dataReader.GetInt32("ref"), dataReader.GetDecimal("rooms"), dataReader.GetString("orientation"), dataReader.GetDecimal("net_area"), dataReader.GetDecimal("balcony_area"), dataReader.GetDecimal("price"), dataReader.GetInt32("reserved"), sqleditflat);
                        formEditFlat.ParentForm = this;
                        formEditFlat.Show();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            labelSuccessExport.Text = "";
        }

        private void lvBuilding_DoubleClick(object sender, EventArgs e)
        {
            FormEditBuilding formEditBuilding = new FormEditBuilding(id, name, num_of_floors, address);
            formEditBuilding.ParentForm = this;
            formEditBuilding.ShowDialog();
        }

        private void btnAddFlat_Click(object sender, EventArgs e)
        {
            if (lvBuilding.SelectedItems.Count > 0)
            {
                FormAddFlat formAddFlat = new FormAddFlat(num_of_floors, id, sqlwhere + " AND building_id = " + (lvBuilding.FocusedItem.SubItems[0].Text));
                formAddFlat.ParentForm = this;
                formAddFlat.Show();
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Please select a building!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //Customers

        public void FlatListColumnsCustomers()
        {
            lvCustomerFlat.FullRowSelect = true;
            lvCustomerFlat.GridLines = true;
            lvCustomerFlat.View = View.Details;
            lvCustomerFlat.Columns.Add("id", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("REF", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("Floor", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("Rooms", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("Net Area", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("Balcony", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("Orientation", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("Price", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns.Add("Favourite", -2, HorizontalAlignment.Center);
            lvCustomerFlat.Columns[0].Width = 0;
            FlatsSelect(sql);
            lvCustomer.GridLines = true;
            lvCustomer.View = View.Details;
            lvCustomer.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvCustomer.Columns.Add("Email", -2, HorizontalAlignment.Center);
            lvCustomer.Columns.Add("Phone", -2, HorizontalAlignment.Center);
            lvCustomer.Columns.Add("Favourite", -2, HorizontalAlignment.Center);
        }

        //Import/Export

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(tbExport.Text + ".json"))
            {
                string LF = "\n";
                Program.sql.CommandText = "SELECT * FROM buildings";
                string outexp = "";
                try
                {

                    outexp += "{" + LF;
                    outexp += "\"buildings\": [" + LF;
                    using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            outexp += "{" + LF;
                            outexp += $"\"id\": {dataReader.GetInt32("id")}," + LF;
                            outexp += $"\"name\": \"{dataReader.GetString("name")}\"," + LF;
                            outexp += $"\"num_of_floors\": {dataReader.GetInt32("num_of_floors")}," + LF;
                            outexp += $"\"address\": \"{dataReader.GetString("address")}\"" + LF;
                            outexp += "}," + LF;
                        }
                    }
                    outexp = outexp.Substring(0, outexp.Length - 2);
                    outexp += "{" + LF;
                    outexp += "]," + LF;
                    outexp += "\"flats\": [" + LF;
                    Program.sql.CommandText = "SELECT * FROM flats";
                    using (MySqlDataReader dataReader = Program.sql.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            outexp += "{" + LF;
                            outexp += $"\"id\": {dataReader.GetInt32("id")}," + LF;
                            outexp += $"\"building_id\": {dataReader.GetInt32("building_id")}," + LF;
                            outexp += $"\"ref\": {dataReader.GetInt32("ref")}," + LF;
                            outexp += $"\"floor\": {dataReader.GetDecimal("floor")}," + LF;
                            outexp += $"\"rooms\": {dataReader.GetDecimal("rooms")}," + LF;
                            outexp += $"\"orientation\": \"{dataReader.GetString("orientation")}\"," + LF;
                            outexp += $"\"net_area\": {dataReader.GetDecimal("net_area")}," + LF;
                            outexp += $"\"balcony_area\": {dataReader.GetDecimal("balcony_area")}," + LF;
                            outexp += $"\"price\": {dataReader.GetDecimal("price")}," + LF;
                            outexp += $"\"reserved\": {dataReader.GetInt32("reserved")}" + LF;
                            outexp += "}," + LF;
                        }
                    }
                    outexp = outexp.Substring(0, outexp.Length - 2);
                    outexp += "]" + LF;
                    outexp += "}";
                    sw.WriteLine(outexp);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            tbExport.Text = "";
            labelSuccessExport.Text = "JSON file export successful.";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbImport.Text) == false)
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
                try
                {
                    MySqlConnection conn = new MySqlConnection(sb.ToString());
                    MySqlCommand truncate = new MySqlCommand("TRUNCATE TABLE buildings", conn);
                    MySqlCommand truncate2 = new MySqlCommand("TRUNCATE TABLE flats", conn);
                    truncate.Connection.Open();
                    truncate.ExecuteNonQuery();
                    truncate2.ExecuteNonQuery();
                    using (StreamReader read = new StreamReader(tbImport.Text+".json"))
                    {
                        while (!read.EndOfStream)
                        {
                            string line = read.ReadLine();
                            file += line;
                        }
                    }
                    string[] split = file.Split(']');
                    string[] charstoremove = { "flats", "{", "}", "]", "[", "buildings", "num_of_floors", "address", "name", "building_id", "ref", "floor", "rooms", "orientation", "net_area", "balcony_area", "price", "reserved", "id", Convert.ToString('"'), ": : " };
                    foreach (var item in charstoremove)
                    {
                        split[0] = split[0].Replace(item, string.Empty);
                    }
                    string[] finalsplitbuilding = split[0].Split(new string[] { ",:" }, StringSplitOptions.None);
                    for (int i = 0; i < finalsplitbuilding.Length; i += 4)
                    {

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO buildings (name, num_of_floors, address) VALUES ('" + finalsplitbuilding[i + 1].TrimStart() + "', " + finalsplitbuilding[i + 2].TrimStart() + ", '" + finalsplitbuilding[i + 3].TrimStart() + "')", conn);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (var item in charstoremove)
                    {
                        split[1] = split[1].Replace(item, string.Empty);
                    }
                    split[1] = split[1].Replace(",", String.Empty);
                    string[] finalsplitflat = split[1].Split(new string[] { ":" }, StringSplitOptions.None);
                    for (int i = 0; i < finalsplitflat.Length; i+=10)
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO flats (building_id, ref, floor, rooms, orientation, net_area, balcony_area, price, reserved) " +
                                                    "VALUES (" + finalsplitflat[i + 1].TrimStart() + ", " + finalsplitflat[i + 2].TrimStart() + ", " + finalsplitflat[i + 3].TrimStart() + ", " + finalsplitflat[i + 4].TrimStart() + ", '" + finalsplitflat[i + 5].TrimStart() + "', " + finalsplitflat[i + 6].TrimStart() + ", " + finalsplitflat[i + 7].TrimStart() + ", " + finalsplitflat[i + 8].TrimStart() + ", " + finalsplitflat[i + 9].TrimStart() + ")", conn);
                        cmd.ExecuteNonQuery();
                }
                    truncate.Connection.Close();
                    Application.Restart();
                }
                catch (IOException ex)
                {
                    DialogResult dialog = MessageBox.Show(ex.Message, "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
