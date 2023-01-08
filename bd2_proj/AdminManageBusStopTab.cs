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

namespace bd2_proj
{
    public partial class AdminManageBusStopTab : UserControl
    {
        private string table = "przystanek";
        MySqlConnection MpkBdConnection;
        int ID = 0;

        public void init(MySqlConnection MpkBdConnection)
        {
            this.MpkBdConnection = MpkBdConnection;
            updateLaGrid();
        }

        private void updateLaGrid()
        {
            try
            {
                string Query = "select * from `mpk_bd2`.`" + table + "`";
                MpkBdConnection.Open();
                MySqlCommand MyCommand = new MySqlCommand(Query, MpkBdConnection);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MpkBdConnection.Close();
        }

        private void clearData()
        {
            textBox2.Text = "";
            textBox3.Text = "";

            ID = 0;
        }

        private DataTable getQueryResult(string query)
        {
            DataTable dTable = new DataTable();
            try
            {
                MpkBdConnection.Open();
                MySqlCommand MyCommand = new MySqlCommand(query, MpkBdConnection);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                dTable = new DataTable();
                MyAdapter.Fill(dTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MpkBdConnection.Close();
            return dTable;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            string getLineQuery = $"SELECT id_przystanek FROM `mpk_bd2`.`przystanek` WHERE nazwa_przystanek={textBox2.Text};";
            var dTable = getQueryResult(getLineQuery);
            if (dTable.Rows.Count > 0)
            {
                MessageBox.Show($"Przystanek o nazwie {textBox2.Text} już istnieje!");
                clearData();
                updateLaGrid();
                return;
            }

            try
            {
                MpkBdConnection.Open();
                string query = $"insert into `mpk_bd2`.`przystanek` (nazwa_przystanek, id_adres) values({(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")}, {(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")});";
                MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Inserted row!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MpkBdConnection.Close();
            clearData();
            updateLaGrid();
        }

        public AdminManageBusStopTab()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                try
                {
                    string query = $"update `mpk_bd2`.`przystanek` set nazwa_przystanek={(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")}, id_adres={(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")};";
                    MpkBdConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Updated row!");
                }
                catch (Exception ex)
                {
                    MpkBdConnection.Close();
                    if (checkIfBusStopIsUsedInAdminTimetable()) return;
                    else MessageBox.Show(ex.Message);
                }
                MpkBdConnection.Close();
                clearData();
                updateLaGrid();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                try
                {
                    MpkBdConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand($"delete from `mpk_bd2`.`przystanek` where id_przystanek={ID};", MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Row Deleted!");
                }
                catch (Exception ex)
                {
                    if (checkIfBusStopIsUsedInAdminTimetable()) return;
                    else MessageBox.Show(ex.Message);
                }
                MpkBdConnection.Close();
                clearData();
                updateLaGrid();
            }
            else
            {
                MessageBox.Show("Wybierz rekord!");
            }
        }

        private bool checkIfBusStopIsUsedInAdminTimetable()
        {
            string fatalQueryAdmin = $"SELECT id_rozklad_jazdy_admin FROM `mpk_bd2`.`rozklad_jazdy_administratora` WHERE id_przystanek = {ID};";
            var dTableFatalQuery = getQueryResult(fatalQueryAdmin);
            if (dTableFatalQuery.Rows.Count > 0)
            {
                MessageBox.Show($"Podany przystanek jest już używany w rozkładzie jazdy administratora!");
                clearData();
                updateLaGrid();
                return true;
            }
            return false;
        }
    }
}
