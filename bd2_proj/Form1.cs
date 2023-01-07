using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace bd2_proj
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private MySqlConnection createConnection(string username, string password)
        {
            string connection_string = $"datasource=localhost;port=3306;database=mpk_bd2;username={username};password={password}";
            return new MySqlConnection(connection_string);
        }

        private void launchAdminForm(MySqlConnection connection)
        {
            var admin = new Administrator();
            admin.init(connection);
            admin.Show();
        }

        private void launchBrygadzistaForm(MySqlConnection connection)
        {
            var brygadzista = new Brygadzista();
            brygadzista.init(connection);
            brygadzista.Show();
        }

        private void launchKierowcaForm(MySqlConnection connection)
        {
            var kierowca = new Kierowca();
            kierowca.init(connection);
            kierowca.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            launchAdminForm(createConnection("Administrator", "123"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            launchBrygadzistaForm(createConnection("Brygadzista", "123"));
        }

        private void KierowcaBtn_Click(object sender, EventArgs e)
        {
            launchKierowcaForm(createConnection("Kierowca", "123"));
        }

        private void kierowcaLoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var username = textBox1.Text;
                var password = textBox2.Text;
                var connection = createConnection(username, password);
                var id = Convert.ToInt32(username);
                if (Roles.kierowcaID(connection, id) == -1)
                {
                    MessageBox.Show("u¿ytkownik o podanym loginie nie jest kierowc¹");
                    return;
                }
                launchKierowcaForm(connection);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("b³¹d logowania");
            }
        }

        private void brygadzistaLoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var username = textBox1.Text;
                var password = textBox2.Text;
                var connection = createConnection(username, password);
                var id = Convert.ToInt32(username);
                if (Roles.brygadzistaID(connection, id) == -1)
                {
                    MessageBox.Show("u¿ytkownik o podanym loginie nie jest brygadzist¹");
                    return;
                }
                launchBrygadzistaForm(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("b³¹d logowania");
            }
        }

        private void administratorLoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var username = textBox1.Text;
                var password = textBox2.Text;
                var connection = createConnection(username, password);
                var id = Convert.ToInt32(username);
                if (Roles.administratorID(connection, id) == -1)
                {
                    MessageBox.Show("u¿ytkownik o podanym loginie nie jest administratorem");
                    return;
                }
                launchAdminForm(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("b³¹d logowania");
            }
        }
    }
}