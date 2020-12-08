namespace TrainerSpace
{
    partial class Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SignupBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(13, 15);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(38, 13);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Логин";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(13, 41);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(45, 13);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Пароль";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(69, 12);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(203, 20);
            this.tbLogin.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(69, 38);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(203, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBtn.Location = new System.Drawing.Point(155, 64);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(117, 47);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Авторизоваться";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // SignupBtn
            // 
            this.SignupBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignupBtn.Location = new System.Drawing.Point(12, 64);
            this.SignupBtn.Name = "SignupBtn";
            this.SignupBtn.Size = new System.Drawing.Size(137, 47);
            this.SignupBtn.TabIndex = 5;
            this.SignupBtn.Text = "Зарегистрироваться";
            this.SignupBtn.UseVisualStyleBackColor = true;
            this.SignupBtn.Click += new System.EventHandler(this.SignupBtn_Click);
            // 
            // Auth
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 122);
            this.Controls.Add(this.SignupBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.LoginLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button SignupBtn;
    }
}