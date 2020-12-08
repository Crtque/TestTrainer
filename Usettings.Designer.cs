namespace TrainerSpace
{
    partial class Usettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.passtxtbx = new System.Windows.Forms.TextBox();
            this.editpassBtn = new System.Windows.Forms.Button();
            this.savenameBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxtbx = new System.Windows.Forms.TextBox();
            this.editnameBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.surnametxtbx = new System.Windows.Forms.TextBox();
            this.savesurnameBtn = new System.Windows.Forms.Button();
            this.editsurnameBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.passtxtbx2 = new System.Windows.Forms.TextBox();
            this.FullResetBtn = new System.Windows.Forms.Button();
            this.BtnCheckUpdates = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сменить пароль";
            // 
            // passtxtbx
            // 
            this.passtxtbx.Location = new System.Drawing.Point(131, 73);
            this.passtxtbx.Margin = new System.Windows.Forms.Padding(2);
            this.passtxtbx.Name = "passtxtbx";
            this.passtxtbx.PasswordChar = '•';
            this.passtxtbx.Size = new System.Drawing.Size(99, 20);
            this.passtxtbx.TabIndex = 1;
            // 
            // editpassBtn
            // 
            this.editpassBtn.Location = new System.Drawing.Point(253, 87);
            this.editpassBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editpassBtn.Name = "editpassBtn";
            this.editpassBtn.Size = new System.Drawing.Size(92, 21);
            this.editpassBtn.TabIndex = 3;
            this.editpassBtn.Text = "Изменить";
            this.editpassBtn.UseVisualStyleBackColor = true;
            this.editpassBtn.Click += new System.EventHandler(this.EditPassBtn_Click);
            // 
            // savenameBtn
            // 
            this.savenameBtn.Enabled = false;
            this.savenameBtn.Location = new System.Drawing.Point(253, 136);
            this.savenameBtn.Margin = new System.Windows.Forms.Padding(2);
            this.savenameBtn.Name = "savenameBtn";
            this.savenameBtn.Size = new System.Drawing.Size(92, 21);
            this.savenameBtn.TabIndex = 4;
            this.savenameBtn.Text = "Сохранить";
            this.savenameBtn.UseVisualStyleBackColor = true;
            this.savenameBtn.Visible = false;
            this.savenameBtn.Click += new System.EventHandler(this.SaveNameBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сменить имя";
            // 
            // nametxtbx
            // 
            this.nametxtbx.Location = new System.Drawing.Point(131, 140);
            this.nametxtbx.Margin = new System.Windows.Forms.Padding(2);
            this.nametxtbx.Name = "nametxtbx";
            this.nametxtbx.Size = new System.Drawing.Size(99, 20);
            this.nametxtbx.TabIndex = 3;
            // 
            // editnameBtn
            // 
            this.editnameBtn.Location = new System.Drawing.Point(253, 137);
            this.editnameBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editnameBtn.Name = "editnameBtn";
            this.editnameBtn.Size = new System.Drawing.Size(92, 21);
            this.editnameBtn.TabIndex = 7;
            this.editnameBtn.Text = "Изменить";
            this.editnameBtn.UseVisualStyleBackColor = true;
            this.editnameBtn.Click += new System.EventHandler(this.EditNameBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Сменить фамилию";
            // 
            // surnametxtbx
            // 
            this.surnametxtbx.Location = new System.Drawing.Point(131, 179);
            this.surnametxtbx.Margin = new System.Windows.Forms.Padding(2);
            this.surnametxtbx.Name = "surnametxtbx";
            this.surnametxtbx.Size = new System.Drawing.Size(99, 20);
            this.surnametxtbx.TabIndex = 4;
            // 
            // savesurnameBtn
            // 
            this.savesurnameBtn.Enabled = false;
            this.savesurnameBtn.Location = new System.Drawing.Point(253, 179);
            this.savesurnameBtn.Margin = new System.Windows.Forms.Padding(2);
            this.savesurnameBtn.Name = "savesurnameBtn";
            this.savesurnameBtn.Size = new System.Drawing.Size(92, 21);
            this.savesurnameBtn.TabIndex = 10;
            this.savesurnameBtn.Text = "Сохранить";
            this.savesurnameBtn.UseVisualStyleBackColor = true;
            this.savesurnameBtn.Visible = false;
            this.savesurnameBtn.Click += new System.EventHandler(this.SavesurnameBtn_Click);
            // 
            // editsurnameBtn
            // 
            this.editsurnameBtn.Location = new System.Drawing.Point(253, 179);
            this.editsurnameBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editsurnameBtn.Name = "editsurnameBtn";
            this.editsurnameBtn.Size = new System.Drawing.Size(92, 21);
            this.editsurnameBtn.TabIndex = 11;
            this.editsurnameBtn.Text = "Изменить";
            this.editsurnameBtn.UseVisualStyleBackColor = true;
            this.editsurnameBtn.Click += new System.EventHandler(this.EditsurnameBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Подтвердите пароль";
            // 
            // passtxtbx2
            // 
            this.passtxtbx2.Location = new System.Drawing.Point(131, 103);
            this.passtxtbx2.Margin = new System.Windows.Forms.Padding(2);
            this.passtxtbx2.Name = "passtxtbx2";
            this.passtxtbx2.PasswordChar = '•';
            this.passtxtbx2.Size = new System.Drawing.Size(99, 20);
            this.passtxtbx2.TabIndex = 2;
            // 
            // FullResetBtn
            // 
            this.FullResetBtn.Location = new System.Drawing.Point(11, 11);
            this.FullResetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.FullResetBtn.Name = "FullResetBtn";
            this.FullResetBtn.Size = new System.Drawing.Size(180, 51);
            this.FullResetBtn.TabIndex = 14;
            this.FullResetBtn.Text = "ПОЛНЫЙ сброс всех настроек";
            this.FullResetBtn.UseVisualStyleBackColor = true;
            this.FullResetBtn.Click += new System.EventHandler(this.FullResetBtn_Click);
            // 
            // BtnCheckUpdates
            // 
            this.BtnCheckUpdates.Location = new System.Drawing.Point(18, 217);
            this.BtnCheckUpdates.Name = "BtnCheckUpdates";
            this.BtnCheckUpdates.Size = new System.Drawing.Size(172, 48);
            this.BtnCheckUpdates.TabIndex = 15;
            this.BtnCheckUpdates.Text = "Проверить обновления";
            this.BtnCheckUpdates.UseVisualStyleBackColor = true;
            this.BtnCheckUpdates.Click += new System.EventHandler(this.BtnCheckUpdates_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(197, 217);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(190, 48);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "label5";
            // 
            // Usettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 285);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnCheckUpdates);
            this.Controls.Add(this.FullResetBtn);
            this.Controls.Add(this.passtxtbx2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.editsurnameBtn);
            this.Controls.Add(this.savesurnameBtn);
            this.Controls.Add(this.surnametxtbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.editnameBtn);
            this.Controls.Add(this.nametxtbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.savenameBtn);
            this.Controls.Add(this.editpassBtn);
            this.Controls.Add(this.passtxtbx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Usettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passtxtbx;
        private System.Windows.Forms.Button editpassBtn;
        private System.Windows.Forms.Button savenameBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxtbx;
        private System.Windows.Forms.Button editnameBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox surnametxtbx;
        private System.Windows.Forms.Button savesurnameBtn;
        private System.Windows.Forms.Button editsurnameBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passtxtbx2;
        private System.Windows.Forms.Button FullResetBtn;
        private System.Windows.Forms.Button BtnCheckUpdates;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
    }
}