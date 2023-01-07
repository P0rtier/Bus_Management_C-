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
    public partial class CreatePasswordForm : Form
    {
        MySqlConnection conn;
        string username;
        public void init(MySqlConnection conn, string username)
        {
            this.conn = conn; ;
            this.username = username;
        }

        public CreatePasswordForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = $"ALTER USER `{username}` IDENTIFIED BY '{textBox1.Text}';";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            this.Close();   
        }
    }
}
