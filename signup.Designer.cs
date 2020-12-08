namespace TrainerSpace
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.tbPassRepeat = new System.Windows.Forms.TextBox();
            this.Password2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterBtn.Location = new System.Drawing.Point(46, 179);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(236, 40);
            this.RegisterBtn.TabIndex = 0;
            this.RegisterBtn.Text = "Зарегистрироваться";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(20, 34);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(38, 13);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Логин";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(82, 32);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(273, 20);
            this.tbLogin.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(82, 55);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(273, 20);
            this.tbPassword.TabIndex = 2;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(20, 58);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(45, 13);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Пароль";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(82, 104);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(273, 20);
            this.tbSurname.TabIndex = 4;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(20, 107);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(56, 13);
            this.LastNameLabel.TabIndex = 5;
            this.LastNameLabel.Text = "Фамилия";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(82, 126);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(273, 20);
            this.tbName.TabIndex = 5;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(20, 133);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Имя";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(300, 179);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(89, 40);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // tbPassRepeat
            // 
            this.tbPassRepeat.Location = new System.Drawing.Point(130, 80);
            this.tbPassRepeat.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassRepeat.Name = "tbPassRepeat";
            this.tbPassRepeat.PasswordChar = '•';
            this.tbPassRepeat.Size = new System.Drawing.Size(225, 20);
            this.tbPassRepeat.TabIndex = 3;
            // 
            // Password2Label
            // 
            this.Password2Label.AutoSize = true;
            this.Password2Label.Location = new System.Drawing.Point(20, 83);
            this.Password2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Password2Label.Name = "Password2Label";
            this.Password2Label.Size = new System.Drawing.Size(100, 13);
            this.Password2Label.TabIndex = 11;
            this.Password2Label.Text = "Повторите пароль";
            // 
            // Signup
            // 
            this.AcceptButton = this.RegisterBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(400, 229);
            this.Controls.Add(this.Password2Label);
            this.Controls.Add(this.tbPassRepeat);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.RegisterBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox tbPassRepeat;
        private System.Windows.Forms.Label Password2Label;
    }
}