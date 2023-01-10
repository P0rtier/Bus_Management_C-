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
    public partial class brygady : UserControl
    {
        private string table;
        private MySqlConnection mySqlConnection;
        public void init(MySqlConnection mySqlConnection, string table)
        {
            this.mySqlConnection = mySqlConnection;
            this.table = table;

            updateComboBoxes();
        }

        private void updateComboBox(ComboBox cbox, string fieldName)
        {
            try
            {
                string query = "select " + fieldName + " from `mpk_bd2`.`" + table + "` group by " + fieldName + ";";
                MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();
                mySqlAdapter.Fill(dTable);
                cbox.DataSource = dTable;
                cbox.DisplayMember = fieldName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void updateComboBoxes()
        {
            updateComboBox(this.comboBox1, "id_brygada");
        }

        private void updateDataGrid()
        {
            try
            {
                string query = "select * from `mpk_bd2`.`" + table + "`";

                var brygada = this.comboBox1.Text;

                if (brygada.Length > 0)
                {
                    query += " where ";
                    if (brygada.Length > 0)
                    {
                        query += "id_brygada=" + brygada;
                    }
                }

                query += ";";
                MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();
                mySqlAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public brygady()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var manage = new BrygadaManageForm();
            manage.init(mySqlConnection);
            manage.Show();
        }
    }
}
