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
    public partial class PracownicyAdminTab : UserControl
    {

        private string table;
        private MySqlConnection mySqlConnection;
        private int pracownik_id = 0;

        public void init(MySqlConnection mySqlConnection, string table, int pracownik_id)
        {
            this.mySqlConnection = mySqlConnection;
            this.table= table;
            this.pracownik_id = pracownik_id;

            try
            {
                string Query = "select * from `mpk_bd2`.`" + table + "`";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, mySqlConnection);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateDataGrid()
        {
            try
            {
                string Query = "select * from `mpk_bd2`.`" + table + "`";

                var surname = this.textBox1.Text;
                var name = this.textBox2.Text;
                var id = this.textBox3.Text;

                int count = 0;

                if(surname.Length > 0 || name.Length > 0 || id.Length > 0)
                {
                    Query += " where";
                    if(surname.Length > 0)
                    {
                        Query += " nazwisko=\"" + surname + "\"";
                        count++;
                    }
                    if(name.Length > 0)
                    {
                        if (count > 0) Query += " and";
                        Query += " imie=\"" + name + "\"";
                        count++;
                    }
                    if(id.Length > 0)
                    {
                        if (count > 0) Query += " and";
                        Query += " id_pracownik=" + id;
                        count++;
                    }
                }

                Query += ";";
                MySqlCommand MyCommand = new MySqlCommand(Query, mySqlConnection);
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
        }


        public PracownicyAdminTab()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PracownicyAdminTab_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var manage = new PracownicyManageForm();
            manage.init(mySqlConnection, pracownik_id);
            manage.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateDataGrid();
        }
    }
}
