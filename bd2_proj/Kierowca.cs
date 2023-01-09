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
        int pracownik_id = 0;

        public void init(MySqlConnection connection, int pracownik_id)
        {
            this.connection = connection;
            this.pracownik_id = pracownik_id;

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
            try
            {
                string query = $"select * from `mpk_bd2`.`kierowca_brygada_view` where id_brygada = (select id_brygada from `mpk_bd2`.`kierowca_brygada_view` where id_pracownik={pracownik_id});";
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
        }

        private void updateBrygadzistaTimetableDataGrid()
        {
            try
            {
                string query = $"select * from `mpk_bd2`.`kierowca_rozklad_jazdy_brygadzisty_view` where id_kierowca = {Roles.kierowcaID(connection, pracownik_id)} and godzina_startu_kierowcy >= '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();
                mySqlAdapter.Fill(dTable);
                dataGridView3.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
