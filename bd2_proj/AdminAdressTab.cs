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
                try
                {
                    MpkBdConnection.Open();
                    string queryMiejscowosc = $"insert into `mpk_bd2`.`miejscowosc` (nazwa_miejscowosci) values({(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")});";
                    MySqlCommand mySqlCommand = new MySqlCommand(queryMiejscowosc, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    inserted_miejscowosc_id = mySqlCommand.LastInsertedId;
                    MessageBox.Show("Miejscowosc id=" + inserted_miejscowosc_id);
                    MpkBdConnection.Close();

                    MpkBdConnection.Open();
                    string queryUlica = $"insert into `mpk_bd2`.`ulica` (nazwa_ulicy, id_miejscowosc) values({(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")},{(inserted_miejscowosc_id == 0 ? "NULL" : $"{inserted_miejscowosc_id}")});";
                    MySqlCommand mySqlCommand2 = new MySqlCommand(queryUlica, MpkBdConnection);
                    mySqlCommand2.ExecuteReader();
                    inserted_ulica_id = mySqlCommand2.LastInsertedId;
                    MessageBox.Show("Ulica id=" + inserted_ulica_id);
                    MpkBdConnection.Close();


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
    }
}
