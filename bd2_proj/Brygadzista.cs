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
    public partial class Brygadzista : Form
    {
        public Brygadzista()
        {
            InitializeComponent();

            var connection = new MySqlConnection("datasource=localhost;port=3306;username=Brygadzista;password=123");
            this.rozkladAdministratora1.init(connection, "brygadzista_rozklad_jazdy_administratora_view");
            this.rozkladBrygadzisty1.init(connection, "brygadzista_rozklad_jazdy_brygadzisty_view");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
