namespace bd2_proj
{
    partial class Administrator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Adresy = new System.Windows.Forms.TabPage();
            this.adminAdressTab1 = new bd2_proj.AdminAdressTab();
            this.Cennik = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.cennikTab1 = new bd2_proj.CennikTab();
            this.Pracownicy = new System.Windows.Forms.TabPage();
            this.pracownicyAdminTab1 = new bd2_proj.PracownicyAdminTab();
            this.RozkladJazdy = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.rozkladAdministratora1 = new bd2_proj.RozkladAdministratora();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Adresy.SuspendLayout();
            this.Cennik.SuspendLayout();
            this.Pracownicy.SuspendLayout();
            this.RozkladJazdy.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Adresy
            // 
            this.Adresy.Controls.Add(this.adminAdressTab1);
            this.Adresy.Location = new System.Drawing.Point(4, 24);
            this.Adresy.Name = "Adresy";
            this.Adresy.Padding = new System.Windows.Forms.Padding(3);
            this.Adresy.Size = new System.Drawing.Size(871, 438);
            this.Adresy.TabIndex = 3;
            this.Adresy.Text = "Adresy";
            this.Adresy.UseVisualStyleBackColor = true;
            // 
            // adminAdressTab1
            // 
            this.adminAdressTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminAdressTab1.Location = new System.Drawing.Point(0, 0);
            this.adminAdressTab1.Name = "adminAdressTab1";
            this.adminAdressTab1.Size = new System.Drawing.Size(871, 438);
            this.adminAdressTab1.TabIndex = 0;
            // 
            // Cennik
            // 
            this.Cennik.Controls.Add(this.button2);
            this.Cennik.Controls.Add(this.cennikTab1);
            this.Cennik.Location = new System.Drawing.Point(4, 24);
            this.Cennik.Name = "Cennik";
            this.Cennik.Padding = new System.Windows.Forms.Padding(3);
            this.Cennik.Size = new System.Drawing.Size(792, 420);
            this.Cennik.TabIndex = 2;
            this.Cennik.Text = "Cennik";
            this.Cennik.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(0, 389);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(792, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Zarządzaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cennikTab1
            // 
            this.cennikTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cennikTab1.Location = new System.Drawing.Point(0, 0);
            this.cennikTab1.Name = "cennikTab1";
            this.cennikTab1.Size = new System.Drawing.Size(792, 383);
            this.cennikTab1.TabIndex = 0;
            // 
            // Pracownicy
            // 
            this.Pracownicy.Controls.Add(this.pracownicyAdminTab1);
            this.Pracownicy.Location = new System.Drawing.Point(4, 24);
            this.Pracownicy.Name = "Pracownicy";
            this.Pracownicy.Padding = new System.Windows.Forms.Padding(3);
            this.Pracownicy.Size = new System.Drawing.Size(792, 420);
            this.Pracownicy.TabIndex = 1;
            this.Pracownicy.Text = "Pracownicy";
            this.Pracownicy.UseVisualStyleBackColor = true;
            // 
            // pracownicyAdminTab1
            // 
            this.pracownicyAdminTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pracownicyAdminTab1.Location = new System.Drawing.Point(0, 0);
            this.pracownicyAdminTab1.Name = "pracownicyAdminTab1";
            this.pracownicyAdminTab1.Size = new System.Drawing.Size(792, 420);
            this.pracownicyAdminTab1.TabIndex = 0;
            // 
            // RozkladJazdy
            // 
            this.RozkladJazdy.Controls.Add(this.button1);
            this.RozkladJazdy.Controls.Add(this.rozkladAdministratora1);
            this.RozkladJazdy.Location = new System.Drawing.Point(4, 24);
            this.RozkladJazdy.Name = "RozkladJazdy";
            this.RozkladJazdy.Padding = new System.Windows.Forms.Padding(3);
            this.RozkladJazdy.Size = new System.Drawing.Size(792, 420);
            this.RozkladJazdy.TabIndex = 0;
            this.RozkladJazdy.Text = "Rozkład Jazdy";
            this.RozkladJazdy.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Zarządzaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rozkladAdministratora1
            // 
            this.rozkladAdministratora1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rozkladAdministratora1.Location = new System.Drawing.Point(0, 0);
            this.rozkladAdministratora1.Name = "rozkladAdministratora1";
            this.rozkladAdministratora1.Size = new System.Drawing.Size(789, 420);
            this.rozkladAdministratora1.TabIndex = 0;
            this.rozkladAdministratora1.Load += new System.EventHandler(this.rozkladAdministratora1_Load);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.RozkladJazdy);
            this.tabControl1.Controls.Add(this.Pracownicy);
            this.tabControl1.Controls.Add(this.Cennik);
            this.tabControl1.Controls.Add(this.Adresy);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(879, 466);
            this.tabControl1.TabIndex = 0;
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 468);
            this.Controls.Add(this.tabControl1);
            this.Name = "Administrator";
            this.Text = "Administrator";
            this.Load += new System.EventHandler(this.Administrator_Load);
            this.Adresy.ResumeLayout(false);
            this.Cennik.ResumeLayout(false);
            this.Pracownicy.ResumeLayout(false);
            this.RozkladJazdy.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage Adresy;
        private TabPage Cennik;
        private Button button2;
        private CennikTab cennikTab1;
        private TabPage Pracownicy;
        private PracownicyAdminTab pracownicyAdminTab1;
        private TabPage RozkladJazdy;
        private Button button1;
        private RozkladAdministratora rozkladAdministratora1;
        private TabControl tabControl1;
        private AdminAdressTab adminAdressTab1;
    }
}