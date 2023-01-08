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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace bd2_proj
{
    public partial class PracownicyManageForm : Form
    {
        private string table = "administrator_pracownik_view";
        MySqlConnection MpkBdConnection;
        int ID = 0;
        int ID_kierowca = 0;
        int ID_brygadzista = 0;
        int ID_administrator = 0;

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
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

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
            var address_id = adressID();

            var id_query = $"select id_pracownik from `mpk_bd2`.`pracownik` where imie={(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")} and nazwisko={(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")} and pesel={(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")} and id_adres={address_id};";
            var res = getQueryResult(id_query);

            if (res.Rows.Count > 0)
            {
                MessageBox.Show("ten pracownik już istnieje");
                return;
            }

            try
            {
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

            res = getQueryResult(id_query);

            if (res.Rows.Count > 0)
            {
                var id_pracownik = Int32.Parse(res.Rows[0][0].ToString());

                try
                {
                    MpkBdConnection.Open();
                    string query = $"CREATE USER `{id_pracownik}` IDENTIFIED BY '123';";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MpkBdConnection.Close();

                var passwordForm = new CreatePasswordForm();
                passwordForm.init(MpkBdConnection, $"{id_pracownik}");
                passwordForm.Show();

                if (checkBox1.Checked)
                {
                    Roles.addRole(MpkBdConnection, "kierowca", id_pracownik);
                }

                if (checkBox2.Checked)
                {
                    Roles.addRole(MpkBdConnection, "brygadzista", id_pracownik);
                }

                if (checkBox3.Checked)
                {
                    Roles.addRole(MpkBdConnection, "administrator", id_pracownik);
                }
            }

            clearData();
            updateCennikGrid();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            ID_kierowca = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString().Length > 0 ? Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString()) : 0;
            ID_brygadzista = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString().Length > 0 ? Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString()) : 0;
            ID_administrator = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString().Length > 0 ? Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString()) : 0;

            checkBox1.Checked = ID_kierowca > 0;
            checkBox2.Checked = ID_brygadzista > 0;
            checkBox3.Checked = ID_administrator > 0;

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();


        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                var address_id = adressID();

                MpkBdConnection.Open();
                string query = $"update `mpk_bd2`.`pracownik` set imie = {(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")}, nazwisko= {(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")}, data_urodzenia= {(dateTimePicker1.Text == "" ? "NULL" : $"'{dateTimePicker1.Text}'")}, data_zatrudnienia = {(dateTimePicker2.Text == "" ? "NULL" : $"'{dateTimePicker2.Text}'")}, pesel= {(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")}, id_adres= {address_id} where id_pracownik={ID}";
                MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Updated Row!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MpkBdConnection.Close();

            var setRole = (string role, int id, bool set) =>
            {
                if (set) Roles.addRole(MpkBdConnection, role, id);
                else Roles.removeRole(MpkBdConnection, role, id);
            };

            setRole("kierowca", ID, checkBox1.Checked);
            setRole("brygadzista", ID, checkBox2.Checked);
            setRole("administrator", ID, checkBox3.Checked);

            clearData();
            updateCennikGrid();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                Roles.removeRole(MpkBdConnection, "kierowca", ID);
                Roles.removeRole(MpkBdConnection, "brygadzista", ID);
                Roles.removeRole(MpkBdConnection, "administrator", ID);

                try
                {
                    MpkBdConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand($"delete from `mpk_bd2`.`pracownik` where id_pracownik={ID};", MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Row Deleted!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MpkBdConnection.Close();
                clearData();
                updateCennikGrid();
            }
            else
            {
                MessageBox.Show("Wybierz rekord!");
            }
        }
    }
}
