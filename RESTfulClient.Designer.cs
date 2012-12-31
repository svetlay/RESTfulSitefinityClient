namespace SFWinformsClient
{
    partial class RESTfulClient
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
            this.Login_button = new System.Windows.Forms.Button();
            this.Logout_button = new System.Windows.Forms.Button();
            this.ListNewsButton = new System.Windows.Forms.Button();
            this.url = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NewsList = new System.Windows.Forms.CheckedListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login_button
            // 
            this.Login_button.Location = new System.Drawing.Point(12, 12);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(78, 31);
            this.Login_button.TabIndex = 0;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Logout_button
            // 
            this.Logout_button.Enabled = false;
            this.Logout_button.Location = new System.Drawing.Point(13, 92);
            this.Logout_button.Name = "Logout_button";
            this.Logout_button.Size = new System.Drawing.Size(77, 34);
            this.Logout_button.TabIndex = 1;
            this.Logout_button.Text = "Logout";
            this.Logout_button.UseVisualStyleBackColor = true;
            this.Logout_button.Click += new System.EventHandler(this.Logout_button_Click);
            // 
            // ListNewsButton
            // 
            this.ListNewsButton.Enabled = false;
            this.ListNewsButton.Location = new System.Drawing.Point(13, 49);
            this.ListNewsButton.Name = "ListNewsButton";
            this.ListNewsButton.Size = new System.Drawing.Size(77, 37);
            this.ListNewsButton.TabIndex = 2;
            this.ListNewsButton.Text = "List Data";
            this.ListNewsButton.UseVisualStyleBackColor = true;
            this.ListNewsButton.Click += new System.EventHandler(this.ListNewsButtonClick);
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(229, 52);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(129, 20);
            this.url.TabIndex = 4;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(229, 79);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(129, 20);
            this.username.TabIndex = 5;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(229, 106);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(129, 20);
            this.password.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "All News";
            // 
            // NewsList
            // 
            this.NewsList.FormattingEnabled = true;
            this.NewsList.Location = new System.Drawing.Point(116, 152);
            this.NewsList.Name = "NewsList";
            this.NewsList.Size = new System.Drawing.Size(358, 64);
            this.NewsList.TabIndex = 13;
            this.NewsList.SelectedIndexChanged += new System.EventHandler(this.NewsList_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "(none)";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Forms Authentication",
            "Claims Authentication"});
            this.comboBox1.Location = new System.Drawing.Point(229, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.Text = "Forms Authentication";
            this.comboBox1.ValueMember = "(none)";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Authentication Mode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(226, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(248, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Sitefinity 5.0+ uses Claims Authentication by default";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(118, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 241);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 36);
            this.button1.TabIndex = 22;
            this.button1.Text = "Create new product";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(289, 250);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 20);
            this.textBox1.TabIndex = 23;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(289, 302);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 20);
            this.textBox2.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Request Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Response Data";
            // 
            // RESTfulClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 367);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.NewsList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.url);
            this.Controls.Add(this.ListNewsButton);
            this.Controls.Add(this.Logout_button);
            this.Controls.Add(this.Login_button);
            this.Name = "RESTfulClient";
            this.Text = "RESTful Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.RESTfulClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.Button Logout_button;
        private System.Windows.Forms.Button ListNewsButton;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox NewsList;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}

