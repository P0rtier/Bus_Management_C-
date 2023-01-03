using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bd2_proj
{
    public partial class RozkladAdministratora : UserControl
    {
        private string table;
        private MySqlConnection mySqlConnection;
        
        public void init(MySqlConnection mySqlConnection, string table)
        {
            this.mySqlConnection = mySqlConnection;
            this.table = table;

            try
            {
                string query = "select * from `mpk_bd2`.`" + table + "`";
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
            updateComboBox(this.comboBox1, "nazwa_przystanek");
            updateComboBox(this.comboBox2, "nr_linii");
        }

        private void updateDataGrid()
        {
            try
            {
                string query = "select * from `mpk_bd2`.`" + table + "`";

                var stop = this.comboBox1.Text;
                var line = this.comboBox2.Text;
                var date = this.dateTimePicker1;

                int count = 0;

                if(stop.Length > 0 || line.Length > 0 || date.Text.Length > 0)
                {
                    query += " where ";
                    if (stop.Length > 0)
                    {
                        query += "nazwa_przystanek=\"" + stop + "\"";
                        count++;
                    }
                    if (line.Length > 0)
                    {
                        if (count > 0) query += " and ";
                        query += "nr_linii=" + line;
                        count++;
                    }
                    if (date.Text.Length > 0)
                    {
                        if (count > 0) query += " and ";
                        query += "data_odjazdu >= '" + date.Text + "'";
                        count++;
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

        public RozkladAdministratora()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDataGrid();
        }
    }
}
