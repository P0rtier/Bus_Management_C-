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

        public void init(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                string query = $"SET ROLE brygadzista_role;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            this.rozkladAdministratora1.init(connection, "brygadzista_rozklad_jazdy_administratora_view");
            this.rozkladBrygadzisty1.init(connection, "brygadzista_rozklad_jazdy_brygadzisty_view");
            this.brygady1.init(connection, "Brygadzista_brygada_view");
            this.pojazdy1.init(connection, "pojazd");
        }


        public Brygadzista()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
