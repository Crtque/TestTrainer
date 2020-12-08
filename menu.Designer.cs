namespace TrainerSpace
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnAdminpanel = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.ThemesCombo = new System.Windows.Forms.ComboBox();
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCheckstat = new System.Windows.Forms.Button();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.themeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 188);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(316, 58);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Старт";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 380);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(316, 58);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(12, 316);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(316, 58);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Выход из аккаунта";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnAdminpanel
            // 
            this.btnAdminpanel.Enabled = false;
            this.btnAdminpanel.Location = new System.Drawing.Point(13, 252);
            this.btnAdminpanel.Name = "btnAdminpanel";
            this.btnAdminpanel.Size = new System.Drawing.Size(315, 58);
            this.btnAdminpanel.TabIndex = 3;
            this.btnAdminpanel.Text = "Панель администратора";
            this.btnAdminpanel.UseVisualStyleBackColor = true;
            this.btnAdminpanel.Click += new System.EventHandler(this.btnAdminpanel_Click);
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(195, 13);
            this.lbUser.MaximumSize = new System.Drawing.Size(83, 100);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(83, 13);
            this.lbUser.TabIndex = 5;
            this.lbUser.Text = "Пользователь:";
            // 
            // ThemesCombo
            // 
            this.ThemesCombo.FormattingEnabled = true;
            this.ThemesCombo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ThemesCombo.Location = new System.Drawing.Point(13, 131);
            this.ThemesCombo.Name = "ThemesCombo";
            this.ThemesCombo.Size = new System.Drawing.Size(315, 21);
            this.ThemesCombo.TabIndex = 6;
            this.ThemesCombo.SelectedIndexChanged += new System.EventHandler(this.ThemesCombo_SelectedIndexChanged);
            // 
            // btnCheckstat
            // 
            this.btnCheckstat.Location = new System.Drawing.Point(13, 252);
            this.btnCheckstat.Name = "btnCheckstat";
            this.btnCheckstat.Size = new System.Drawing.Size(315, 58);
            this.btnCheckstat.TabIndex = 7;
            this.btnCheckstat.Text = "Мои результаты";
            this.btnCheckstat.UseVisualStyleBackColor = true;
            this.btnCheckstat.Click += new System.EventHandler(this.btnCheckstat_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Location = new System.Drawing.Point(12, 68);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(160, 49);
            this.AboutBtn.TabIndex = 9;
            this.AboutBtn.Text = "Справка";
            this.AboutBtn.UseVisualStyleBackColor = true;
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(13, 13);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(2);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(159, 49);
            this.SettingsButton.TabIndex = 10;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Location = new System.Drawing.Point(220, 115);
            this.themeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(84, 13);
            this.themeLabel.TabIndex = 11;
            this.themeLabel.Text = "Выберите тему";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 450);
            this.Controls.Add(this.themeLabel);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.AboutBtn);
            this.Controls.Add(this.btnCheckstat);
            this.Controls.Add(this.ThemesCombo);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.btnAdminpanel);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тренажер";
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnAdminpanel;
        private System.Windows.Forms.Label lbUser;

        private System.Windows.Forms.BindingSource subjectsBindingSource;
    
        private System.Windows.Forms.Button btnCheckstat;
        private System.Windows.Forms.Button AboutBtn;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ComboBox ThemesCombo;
        private System.Windows.Forms.Label themeLabel;
    }
}