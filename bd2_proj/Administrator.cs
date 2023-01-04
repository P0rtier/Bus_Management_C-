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

        public Administrator()
        {
            InitializeComponent();

            string connection = "datasource=localhost;port=3306;username=Administrator;password=123";
            connections = new MySqlConnection(connection);
            string table = "administrator_rozklad_jazdy_administratora_view";
            string table2 = "administrator_pracownik_view";
            this.rozkladAdministratora1.init(new MySqlConnection(connection), table);
            this.pracownicyAdminTab1.init(new MySqlConnection(connection), table2);


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
    }
}
