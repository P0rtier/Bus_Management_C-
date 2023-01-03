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

    public partial class CennikTab : UserControl
    {
        private string connection = "datasource=localhost;port=3306;username=Administrator;password=123";
        private string table = "cennik";

        private void updateCennikGrid()
        {
            try
            {
                string Query = "select * from `mpk_bd2`.`" + table + "`";
                MySqlConnection MpkBdConnection = new MySqlConnection(connection);
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
        }

        public CennikTab()
        {
            InitializeComponent();
            updateCennikGrid();
        }
    }
}