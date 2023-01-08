using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bd2_proj
{
    public partial class AdminManageBusLineTab : UserControl
    {
        private string table = "linia_autobusowa";
        MySqlConnection MpkBdConnection;
        int ID = 0;


        public void init(MySqlConnection MpkBdConnection)
        {
            this.MpkBdConnection = MpkBdConnection;
            updateLaGrid();
        }

        public AdminManageBusLineTab()
        {
            InitializeComponent();
        }

        private void AdminManageBusLineTab_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            textBox1.Text = "";
            textBox2.Text = "";

            ID = 0;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            string getLineQuery = $"SELECT id_linia_autobusowa FROM `mpk_bd2`.`linia_autobusowa` WHERE id_linia_autobusowa={textBox1.Text};";
            var dTable = getQueryResult(getLineQuery);
            if(dTable.Rows.Count > 0)
            {
                MessageBox.Show($"Linia o numerze {textBox1.Text} już istnieje!");
                clearData();
                updateLaGrid();
                return;
            }
            try
            {
                MpkBdConnection.Open();
                string query = $"insert into `mpk_bd2`.`linia_autobusowa` (id_linia_autobusowa, typ_linii) values({(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")}, {(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")});";
                MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Inserted row!");
            }catch(Exception ex)
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
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                try
                {
                    string query = $"update `mpk_bd2`.`linia_autobusowa` set id_linia_autobusowa={(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")}, typ_linii={(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")};";
                    MpkBdConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Updated row!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    MySqlCommand mySqlCommand = new MySqlCommand($"delete from `mpk_bd2`.`linia_autobusowa` where id_linia_autobusowa={ID};", MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Row Deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
