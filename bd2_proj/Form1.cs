namespace bd2_proj
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var admin = new Administrator();
            admin.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var admin = new Brygadzista();
            admin.Show();
        }

        private void KierowcaBtn_Click(object sender, EventArgs e)
        {
            var admin = new Kierowca();
            admin.Show();
        }
    }
}