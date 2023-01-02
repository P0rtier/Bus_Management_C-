namespace bd2_proj
{
    partial class login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.administratorBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.brygadzistaBtn = new System.Windows.Forms.Button();
            this.KierowcaBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // administratorBtn
            // 
            this.administratorBtn.Location = new System.Drawing.Point(629, 415);
            this.administratorBtn.Name = "administratorBtn";
            this.administratorBtn.Size = new System.Drawing.Size(159, 23);
            this.administratorBtn.TabIndex = 0;
            this.administratorBtn.Text = "okno administratora";
            this.administratorBtn.UseVisualStyleBackColor = true;
            this.administratorBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(63, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 23);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "hasło";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "zaloguj";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // brygadzistaBtn
            // 
            this.brygadzistaBtn.Location = new System.Drawing.Point(483, 415);
            this.brygadzistaBtn.Name = "brygadzistaBtn";
            this.brygadzistaBtn.Size = new System.Drawing.Size(131, 23);
            this.brygadzistaBtn.TabIndex = 6;
            this.brygadzistaBtn.Text = "okno brygadzisty";
            this.brygadzistaBtn.UseVisualStyleBackColor = true;
            this.brygadzistaBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // KierowcaBtn
            // 
            this.KierowcaBtn.Location = new System.Drawing.Point(314, 415);
            this.KierowcaBtn.Name = "KierowcaBtn";
            this.KierowcaBtn.Size = new System.Drawing.Size(152, 23);
            this.KierowcaBtn.TabIndex = 7;
            this.KierowcaBtn.Text = "okno kierowcy";
            this.KierowcaBtn.UseVisualStyleBackColor = true;
            this.KierowcaBtn.Click += new System.EventHandler(this.KierowcaBtn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.KierowcaBtn);
            this.Controls.Add(this.brygadzistaBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.administratorBtn);
            this.Name = "login";
            this.Text = "logowanie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button administratorBtn;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button brygadzistaBtn;
        private Button KierowcaBtn;
    }
}