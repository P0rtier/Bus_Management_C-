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

//        string query = $"insert into `mpk_bd2`.`cennik` (cena, rodzaj, typ_przejazdu, id_administrator) values('{dataGridView1.Rows[e.RowIndex].Cells["cena"].Value}','{dataGridView1.Rows[e.RowIndex].Cells["rodzaj"].Value}','{dataGridView1.Rows[e.RowIndex].Cells["typ_przejazdu"].Value}','{dataGridView1.Rows[e.RowIndex].Cells["id_administrator"].Value}');";
//        string query = $"update `mpk_bd2`.`cennik` set cena = '{dataGridView1.Rows[e.RowIndex].Cells["cena"].Value}', rodzaj='{dataGridView1.Rows[e.RowIndex].Cells["rodzaj"].Value}', typ_przejazdu='{dataGridView1.Rows[e.RowIndex].Cells["typ_przejazdu"].Value}', id_administrator='{dataGridView1.Rows[e.RowIndex].Cells["id_administrator"].Value}';";





namespace bd2_proj
{
    public partial class CennikManageForm : Form
    {
        private string table = "cennik";
        MySqlConnection MpkBdConnection;
        int ID = 0;

        public void init(MySqlConnection MpkBdConnection)
        {
            this.MpkBdConnection= MpkBdConnection;
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


        public CennikManageForm()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                MpkBdConnection.Open();
                string query = $"insert into `mpk_bd2`.`cennik` (cena, rodzaj, typ_przejazdu, id_administrator) values({(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")},{(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")},{(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")},{(textBox4.Text == "" ? "NULL" : $"'{textBox4.Text}'")});";
                MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Inserted Row!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MpkBdConnection.Close();
            clearData();
            updateCennikGrid();
        }

        private void clearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            ID = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                MpkBdConnection.Open();
                string query = $"update `mpk_bd2`.`cennik` set cena={(textBox1.Text == "" ? "NULL" : $"'{textBox1.Text}'")}, rodzaj={(textBox2.Text == "" ? "NULL" : $"'{textBox2.Text}'")}, typ_przejazdu={(textBox3.Text == "" ? "NULL" : $"'{textBox3.Text}'")}, id_administrator={(textBox4.Text == "" ? "NULL" : $"'{textBox4.Text}'")} WHERE id_cennik={ID};";
                MySqlCommand mySqlCommand = new MySqlCommand(query, MpkBdConnection);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Updated Row!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MpkBdConnection.Close();
            clearData();
            updateCennikGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                try
                {
                    MpkBdConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand($"delete from `mpk_bd2`.`cennik` where id_cennik={ID};", MpkBdConnection);
                    mySqlCommand.ExecuteReader();
                    MessageBox.Show("Row Deleted!");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MpkBdConnection.Close();
                clearData();
                updateCennikGrid();
            }
        }
    }
}
