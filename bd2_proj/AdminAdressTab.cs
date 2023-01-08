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
    public partial class AdminAdressTab : UserControl
    {
        private string table = "administrator_adresy_pracownikow_view";
        MySqlConnection MpkBdConnection;
        int ID = 0;
        long inserted_miejscowosc_id = 0;
        long inserted_ulica_id = 0;

        public void init(MySqlConnection MpkBdConnection)
        {
            this.MpkBdConnection = MpkBdConnection;
            updateAdresyGrid();
        }

        private void updateAdresyGrid()
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

        private void Insert_Click(object sender, EventArgs e)
        {
        }

        private void clearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            ID = 0;
        }


        public AdminAdressTab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string addressQuery = $"SELECT a.id_adres FROM `mpk_bd2`.`adres` as a INNER JOIN ulica as u ON a.id_ulica = u.id_ulica INNER JOIN miejscowosc as m ON u.id_miejscowosc=m.id_miejscowosc where a.nr_domu={textBox3.Text} and a.nr_lokalu={textBox4.Text} and u.nazwa_ulicy='{textBox2.Text}' and m.nazwa_miejscowosci='{textBox1.Text}';";
                var dTable3 = getQueryResult(addressQuery);
                if (dTable3.Rows.Count > 0)
                {
                    MessageBox.Show("Podany adres już istnieje!");
                    clearData();
                    updateAdresyGrid();
                    return;
                }

                try
                {
                    string cityCheckQuery = $"SELECT id_miejscowosc FROM `mpk_bd2`.`miejscowosc` where nazwa_miejscowosci='{textBox1.Text}'";
                    var dTable = getQueryResult(cityCheckQuery);
                    if(dTable.Rows.Count > 0)
                    {
                        inserted_miejscowosc_id = Int32.Parse(dTable.Rows[0][0].ToString());
                    }
                    else
                    {
                        MpkBdConnection.Open();
                        string queryMiejscowosc = $"insert into `mpk_bd2`.`miejscowosc` (nazwa_miejscowosci) values({(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")});";
                        MySqlCommand mySqlCommand = new MySqlCommand(queryMiejscowosc, MpkBdConnection);
                        mySqlCommand.ExecuteReader();
                        inserted_miejscowosc_id = mySqlCommand.LastInsertedId;
                        MpkBdConnection.Close();
                    }

                    string streetQuery = $"SELECT u.id_ulica FROM `mpk_bd2`.`ulica` as u INNER JOIN miejscowosc as m ON u.id_miejscowosc=m.id_miejscowosc where u.nazwa_ulicy='{textBox2.Text}' and m.nazwa_miejscowosci='{textBox1.Text}'";
                    var dTable2 = getQueryResult(streetQuery);
                    if (dTable2.Rows.Count > 0)
                    {
                        inserted_ulica_id = Int32.Parse(dTable2.Rows[0][0].ToString());
                    }
                    else
                    {
                        MpkBdConnection.Open();
                        string queryUlica = $"insert into `mpk_bd2`.`ulica` (nazwa_ulicy, id_miejscowosc) values({(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")},{(inserted_miejscowosc_id == 0 ? "NULL" : $"{inserted_miejscowosc_id}")});";
                        MySqlCommand mySqlCommand2 = new MySqlCommand(queryUlica, MpkBdConnection);
                        mySqlCommand2.ExecuteReader();
                        inserted_ulica_id = mySqlCommand2.LastInsertedId;
                        MpkBdConnection.Close();
                    }
                    MpkBdConnection.Open();
                    string queryAdres = $"insert into `mpk_bd2`.`adres` (id_ulica, nr_domu, nr_lokalu) values({(inserted_ulica_id == 0 ? "NULL" : $"{inserted_ulica_id}")},{(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")},{(textBox4.Text == "" ? "NULL" : $"'{textBox4.Text}'")});";
                    MySqlCommand mySqlCommand3 = new MySqlCommand(queryAdres, MpkBdConnection);
                    mySqlCommand3.ExecuteReader();
                    MessageBox.Show("Inserted Rows!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MpkBdConnection.Close();
                clearData();
                updateAdresyGrid();
            }
            else
            {
                MessageBox.Show("Proszę wypełnić poprawnie niezbędne pola!");
            }
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
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                try
                {
                MpkBdConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand($"delete from `mpk_bd2`.`adres` where id_adres={ID};", MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Row Deleted!");
                }catch(Exception ex)
                {
                    MpkBdConnection.Close();
                    string fatalQuery = $"SELECT id_pracownik FROM `mpk_bd2`.`pracownik` WHERE id_adres = {ID};";
                    var dTable = getQueryResult(fatalQuery);
                    if(dTable.Rows.Count > 0)
                    {
                        MessageBox.Show($"Podany adres jest przypisany do pracownika o ID: {dTable.Rows[0][0]}");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MpkBdConnection.Close();
                clearData();
                updateAdresyGrid();
            }
        }
    }
}
