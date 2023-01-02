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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.RozkladJazdy = new System.Windows.Forms.TabPage();
            this.Pracownicy = new System.Windows.Forms.TabPage();
            this.Cennik = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.RozkladJazdy);
            this.tabControl1.Controls.Add(this.Pracownicy);
            this.tabControl1.Controls.Add(this.Cennik);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // RozkladJazdy
            // 
            this.RozkladJazdy.Location = new System.Drawing.Point(4, 24);
            this.RozkladJazdy.Name = "RozkladJazdy";
            this.RozkladJazdy.Padding = new System.Windows.Forms.Padding(3);
            this.RozkladJazdy.Size = new System.Drawing.Size(792, 420);
            this.RozkladJazdy.TabIndex = 0;
            this.RozkladJazdy.Text = "Rozkład Jazdy";
            this.RozkladJazdy.UseVisualStyleBackColor = true;
            // 
            // Pracownicy
            // 
            this.Pracownicy.Location = new System.Drawing.Point(4, 24);
            this.Pracownicy.Name = "Pracownicy";
            this.Pracownicy.Padding = new System.Windows.Forms.Padding(3);
            this.Pracownicy.Size = new System.Drawing.Size(792, 420);
            this.Pracownicy.TabIndex = 1;
            this.Pracownicy.Text = "Pracownicy";
            this.Pracownicy.UseVisualStyleBackColor = true;
            // 
            // Cennik
            // 
            this.Cennik.Location = new System.Drawing.Point(4, 24);
            this.Cennik.Name = "Cennik";
            this.Cennik.Padding = new System.Windows.Forms.Padding(3);
            this.Cennik.Size = new System.Drawing.Size(792, 420);
            this.Cennik.TabIndex = 2;
            this.Cennik.Text = "Cennik";
            this.Cennik.UseVisualStyleBackColor = true;
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Administrator";
            this.Text = "Administrator";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage RozkladJazdy;
        private TabPage Pracownicy;
        private TabPage Cennik;
    }
}