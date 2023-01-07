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
            this.brygadzistaBtn = new System.Windows.Forms.Button();
            this.KierowcaBtn = new System.Windows.Forms.Button();
            this.kierowcaLoginBtn = new System.Windows.Forms.Button();
            this.brygadzistaLoginBtn = new System.Windows.Forms.Button();
            this.administratorLoginBtn = new System.Windows.Forms.Button();
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
            // kierowcaLoginBtn
            // 
            this.kierowcaLoginBtn.Location = new System.Drawing.Point(63, 72);
            this.kierowcaLoginBtn.Name = "kierowcaLoginBtn";
            this.kierowcaLoginBtn.Size = new System.Drawing.Size(154, 23);
            this.kierowcaLoginBtn.TabIndex = 8;
            this.kierowcaLoginBtn.Text = "zaloguj jako kierowca";
            this.kierowcaLoginBtn.UseVisualStyleBackColor = true;
            this.kierowcaLoginBtn.Click += new System.EventHandler(this.kierowcaLoginBtn_Click);
            // 
            // brygadzistaLoginBtn
            // 
            this.brygadzistaLoginBtn.Location = new System.Drawing.Point(63, 101);
            this.brygadzistaLoginBtn.Name = "brygadzistaLoginBtn";
            this.brygadzistaLoginBtn.Size = new System.Drawing.Size(154, 23);
            this.brygadzistaLoginBtn.TabIndex = 9;
            this.brygadzistaLoginBtn.Text = "zaloguj jako brygadzista";
            this.brygadzistaLoginBtn.UseVisualStyleBackColor = true;
            this.brygadzistaLoginBtn.Click += new System.EventHandler(this.brygadzistaLoginBtn_Click);
            // 
            // administratorLoginBtn
            // 
            this.administratorLoginBtn.Location = new System.Drawing.Point(63, 130);
            this.administratorLoginBtn.Name = "administratorLoginBtn";
            this.administratorLoginBtn.Size = new System.Drawing.Size(154, 23);
            this.administratorLoginBtn.TabIndex = 10;
            this.administratorLoginBtn.Text = "zaloguj jako administrator";
            this.administratorLoginBtn.UseVisualStyleBackColor = true;
            this.administratorLoginBtn.Click += new System.EventHandler(this.administratorLoginBtn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.administratorLoginBtn);
            this.Controls.Add(this.brygadzistaLoginBtn);
            this.Controls.Add(this.kierowcaLoginBtn);
            this.Controls.Add(this.KierowcaBtn);
            this.Controls.Add(this.brygadzistaBtn);
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
        private Button brygadzistaBtn;
        private Button KierowcaBtn;
        private Button kierowcaLoginBtn;
        private Button brygadzistaLoginBtn;
        private Button administratorLoginBtn;
    }
}