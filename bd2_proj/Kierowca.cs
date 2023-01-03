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
    public partial class Kierowca : Form
    {
        public Kierowca()
        {
            InitializeComponent();

            string connection = "datasource=localhost;port=3306;username=Kierowca;password=123";
            string table = "kierowca_rozklad_jazdy_administratora_view";
            this.rozkladAdministratora1.init(new MySqlConnection(connection), table);
        }
    }
}
