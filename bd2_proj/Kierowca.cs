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
using MySqlX.XDevAPI.Relational;

namespace bd2_proj
{
    public partial class Kierowca : Form
    {
        MySqlConnection connection;

        public void init(MySqlConnection connection)
        {
            this.connection = connection;

            this.rozkladAdministratora1.init(connection, "kierowca_rozklad_jazdy_administratora_view");

            updateBrygadaDataGrid();
            updateBrygadzistaTimetableDataGrid();
        }

        public Kierowca()
        {
            InitializeComponent();
        }

        private void updateBrygadaDataGrid()
        {
            updateDataGrid(dataGridView1, "kierowca_brygada_view");
        }

        private void updateBrygadzistaTimetableDataGrid()
        {
            updateDataGrid(dataGridView3, "kierowca_rozklad_jazdy_brygadzisty_view");
        }

        private void updateDataGrid(DataGridView dgrid, string table)
        {
            try
            {
                string query = "select * from `mpk_bd2`.`" + table + "`";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();
                mySqlAdapter.Fill(dTable);
                dgrid.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
