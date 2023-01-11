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
    public partial class Administrator : Form
    {
        MySqlConnection connections;


        public void init(MySqlConnection connection, int pracownik_id)
        {
            this.connections = connection;

            string table = "administrator_rozklad_jazdy_administratora_view";
            string table2 = "administrator_pracownik_view";
            this.rozkladAdministratora1.init(connections, table);
            this.pracownicyAdminTab1.init(connections, table2, pracownik_id);
            this.adminAdressTab1.init(connections);
            this.adminManageBusLineTab1.init(connections);
            this.adminManageBusStopTab1.init(connections);
        }

        public Administrator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void rozkladAdministratora1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cennikManagement = new CennikManageForm();
            cennikManagement.init(connections);
            cennikManagement.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Administrator_Load(object sender, EventArgs e)
        {

        }
    }
}
