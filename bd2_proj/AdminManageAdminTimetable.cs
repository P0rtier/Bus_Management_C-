using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class AdminManageAdminTimetable : Form
    {
        private string table = "administrator_rozklad_jazdy_administratora_view";
        MySqlConnection MpkBdConnection;
        int ID = 0;
        int loggedAdminId = 0;

        public AdminManageAdminTimetable()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        public void init(MySqlConnection MpkBdConnection, int adminId)
        {
            this.MpkBdConnection = MpkBdConnection;
            this.loggedAdminId = adminId;
            updateLaGrid();

        }
        private void clearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";

            ID = 0;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string checkBuStopValidation = $"SELECT id_przystanek FROM `mpk_bd2`.`przystanek` WHERE id_przystanek = {textBox2.Text};";
            string checkLineValidation = $"SELECT id_linia_autobusowa FROM `mpk_bd2`.`linia_autobusowa` WHERE id_linia_autobusowa = {textBox1.Text};";
            var dTable1 = getQueryResult(checkLineValidation);
            if (dTable1.Rows.Count == 0)
            {
                MessageBox.Show($"Brak linii o podanym numerze: {textBox1.Text}");
                clearData();
                updateLaGrid();
                return;
            }
            var dTable2 = getQueryResult(checkBuStopValidation);
            if (dTable2.Rows.Count == 0)
            {
                MessageBox.Show($"Brak przystanku o podanym id: {textBox2.Text}");
                clearData();
                updateLaGrid();
                return;
            }
            try
            {
                MpkBdConnection.Open();
                string query = $"insert into `mpk_bd2`.`rozklad_jazdy_administratora` (id_przystanek, nr_linii, id_administrator, data_odjazdu) values({(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")}, {(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")}, {(loggedAdminId == 0 ? "NULL" : $"'{loggedAdminId}'")}, {(dateTimePicker1.Text == "" ? "NULL" : $"'{dateTimePicker1.Text}'")});";
                MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Inserted row!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MpkBdConnection.Close();
            clearData();
            updateLaGrid();
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string elem = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string checkBuStopId = $"SELECT id_przystanek FROM `mpk_bd2`.`przystanek` WHERE nazwa_przystanek = '{elem}';";
            var dTable = getQueryResult(checkBuStopId);
            int busStopId = -1;
            if(dTable.Rows.Count < 1)
            {
                MessageBox.Show($"Brak takiego przystanku!");
                return;
            }
            busStopId = Int32.Parse(dTable.Rows[0][0].ToString());

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = busStopId.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            string getId = $"SELECT id_rozklad_jazdy_admin FROM `mpk_bd2`.`rozklad_jazdy_administratora` WHERE id_przystanek = {busStopId} AND nr_linii = '{textBox1.Text}' AND data_odjazdu = '{dateTimePicker1.Text}';";
            var dTable2 = getQueryResult(getId);
            if(dTable.Rows.Count < 1)
            {
                MessageBox.Show($"Brak Id rozkladu Admina!");
            }

            ID = Int32.Parse(dTable2.Rows[0][0].ToString());
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                try
                {
                    string query = $"update `mpk_bd2`.`rozklad_jazdy_administratora` set nr_linii={(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")}, id_przystanek={(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")}, data_odjazdu={(dateTimePicker1.Text == "" ? "NULL" : $"'{dateTimePicker1.Text}'")} WHERE id_rozklad_jazdy_admin = {ID};";
                    MpkBdConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Updated row!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MpkBdConnection.Close();
                clearData();
                updateLaGrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                try
                {
                    MpkBdConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand($"delete from `mpk_bd2`.`rozklad_jazdy_administratora` where id_rozklad_jazdy_admin={ID};", MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Row Deleted!");
                }
                catch (Exception ex)
                {
                    string getBrygadzistaRozklad = $"SELECT id_rozklad_jazdy_brygadzisty FROM `mpk_bd2`.`rozklad_jazdy_brygadzisty` WHERE id_rozklad_admin={ID}";
                    var dTable = getQueryResult(getBrygadzistaRozklad);
                    if(dTable.Rows.Count > 1)
                    {
                        MessageBox.Show($"Wybrany rekord Rozkladu jazdy administratora o id: {ID} jest wykorzystywany w rozkladzie jazdy brygadzisty w wielu rekordach!");
                    }
                    else if(dTable.Rows.Count == 1)
                    {
                        int number = Int32.Parse(dTable.Rows[0][0].ToString());
                        MessageBox.Show($"Wybrany rekord Rozkladu jazdy administratora o id: {ID} jest wykorzystywany w rozkladzie jazdy brygadzisty o id: {number}");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
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
    }
}
