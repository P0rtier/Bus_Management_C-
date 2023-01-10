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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bd2_proj
{
    public partial class BrygadaManageForm : Form
    {
        MySqlConnection connection;
        int ID = 0;

        public void init(MySqlConnection connection)
        {
            this.connection = connection;
            updateGrid();
            updateComboBox();

            if(dataGridView1.RowCount > 0)
            {
                ID = Roles.kierowcaID(connection, Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value.ToString()));

                comboBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
        }
        public BrygadaManageForm()
        {
            InitializeComponent();
        }

        private void updateComboBox()
        {
            try
            {
                string query = "select id_brygada from `mpk_bd2`.`brygada`;";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();
                mySqlAdapter.Fill(dTable);
                comboBox1.DataSource = dTable;
                comboBox1.DisplayMember = "id_brygada";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void updateGrid()
        {
            try
            {
                string query = "select * from `mpk_bd2`.`brygadzista_brygada_view`";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
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
            connection.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Roles.kierowcaID(connection, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));

            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = $"update `mpk_bd2`.`kierowca` set id_brygada = {Int32.Parse(comboBox1.Text)} where id_kierowca={ID}";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            updateGrid();
        }

    }
}
