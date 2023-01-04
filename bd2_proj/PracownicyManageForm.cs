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
    public partial class PracownicyManageForm : Form
    {
        private string table = "administrator_pracownik_view";
        MySqlConnection MpkBdConnection;
        int ID = 0;

        public void init(MySqlConnection MpkBdConnection)
        {
            this.MpkBdConnection = MpkBdConnection;
            updateCennikGrid();
        }


        private void updateCennikGrid()
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            ID = 0;
        }

        public PracownicyManageForm()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
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

        private int CityID()
        {
            var city = textBox4.Text;

            int id = -1;

            string cityQuery = $"SELECT id_miejscowosc FROM `mpk_bd2`.`miejscowosc` where nazwa_miejscowosci='{city}'";
            var dTable = getQueryResult(cityQuery);
            if (dTable.Rows.Count > 0)
            {
                id = Int32.Parse(dTable.Rows[0][0].ToString());
            }
            else
            {
                try
                {
                    MpkBdConnection.Open();
                    string query = $"insert into `mpk_bd2`.`miejscowosc` (nazwa_miejscowosci) values({(city == "" ? "NULL" : $"'{city}'")});";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Inserted new city Row!");        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CITY " +  ex.Message);
                }
                MpkBdConnection.Close();

                dTable = getQueryResult(cityQuery);
                if (dTable.Rows.Count > 0)
                {
                    id = Int32.Parse(dTable.Rows[0][0].ToString());
                }
            }
            return id;
        }

        private int streetID()
        {
            var city = textBox4.Text;
            var street = textBox5.Text;


            int id = -1;

            string streetQuery = $"SELECT u.id_ulica FROM `mpk_bd2`.`ulica` as u INNER JOIN miejscowosc as m ON u.id_miejscowosc=m.id_miejscowosc where u.nazwa_ulicy='{street}' and m.nazwa_miejscowosci='{city}'";
            var dTable = getQueryResult(streetQuery);
            if (dTable.Rows.Count > 0)
            {
                id = Int32.Parse(dTable.Rows[0][0].ToString());
            }
            else
            {
                var id_city = CityID();
                try
                {
                    MpkBdConnection.Open();
                    string query = $"insert into `mpk_bd2`.`ulica` (nazwa_ulicy, id_miejscowosc) values({(street == "" ? "NULL" : $"'{street}'")}, {id_city});";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Inserted new street Row!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("STREET " + ex.Message);
                }
                MpkBdConnection.Close();

                dTable = getQueryResult(streetQuery);
                if (dTable.Rows.Count > 0)
                {
                    id = Int32.Parse(dTable.Rows[0][0].ToString());
                }
            }
            return id;
        }

        private int adressID()
        {
            var city = textBox4.Text;
            var street = textBox5.Text;
            var nr = textBox6.Text;
            var subNr = textBox7.Text;


            int id = -1;
            string addressQuery = $"SELECT a.id_adres FROM `mpk_bd2`.`adres` as a INNER JOIN ulica as u ON a.id_ulica = u.id_ulica INNER JOIN miejscowosc as m ON u.id_miejscowosc=m.id_miejscowosc where a.nr_domu={nr} and a.nr_lokalu={subNr} and u.nazwa_ulicy='{street}' and m.nazwa_miejscowosci='{city}';";
            var dTable = getQueryResult(addressQuery);
            if (dTable.Rows.Count > 0)
            {
                id = Int32.Parse(dTable.Rows[0][0].ToString());
            }
            else
            {
                try
                {
                    var street_id = streetID();
                    MpkBdConnection.Open();
                    string query = $"insert into `mpk_bd2`.`adres` (nr_domu, nr_lokalu, id_ulica) values({(nr == "" ? "NULL" : $"'{nr}'")}, {(subNr == "" ? "NULL" : $"'{subNr}'")}, {street_id});";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Inserted new address Row!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ADDRESS " + ex.Message);
                }
                MpkBdConnection.Close();

                dTable = getQueryResult(addressQuery);
                if (dTable.Rows.Count > 0)
                {
                    id = Int32.Parse(dTable.Rows[0][0].ToString());
                }
            }
            return id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var address_id = adressID();

                MpkBdConnection.Open();
                string query = $"insert into `mpk_bd2`.`pracownik` (imie, nazwisko, data_urodzenia, data_zatrudnienia, pesel, id_adres) values({(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")},{(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")},{(dateTimePicker1.Text == "" ? "NULL" : $"'{dateTimePicker1.Text}'")},{(dateTimePicker2.Text == "" ? "NULL" : $"'{dateTimePicker2.Text}'")}, {(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")}, {address_id});";
                MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Inserted Row!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("INSERT " + ex.Message);
            }
            MpkBdConnection.Close();
            clearData();
            updateCennikGrid();
        }
    }
}
