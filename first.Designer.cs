namespace TrainerSpace
{
    partial class First
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.Pass1Label = new System.Windows.Forms.Label();
            this.tbPass1 = new System.Windows.Forms.TextBox();
            this.tbPass2 = new System.Windows.Forms.TextBox();
            this.Pass2Label = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(13, 205);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(259, 44);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Подтвердить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // Pass1Label
            // 
            this.Pass1Label.AutoSize = true;
            this.Pass1Label.Location = new System.Drawing.Point(104, 108);
            this.Pass1Label.Name = "Pass1Label";
            this.Pass1Label.Size = new System.Drawing.Size(88, 13);
            this.Pass1Label.TabIndex = 1;
            this.Pass1Label.Text = "Введите пароль";
            // 
            // tbPass1
            // 
            this.tbPass1.Location = new System.Drawing.Point(16, 124);
            this.tbPass1.Name = "tbPass1";
            this.tbPass1.PasswordChar = '•';
            this.tbPass1.Size = new System.Drawing.Size(256, 20);
            this.tbPass1.TabIndex = 3;
            // 
            // tbPass2
            // 
            this.tbPass2.Location = new System.Drawing.Point(16, 163);
            this.tbPass2.Name = "tbPass2";
            this.tbPass2.PasswordChar = '•';
            this.tbPass2.Size = new System.Drawing.Size(256, 20);
            this.tbPass2.TabIndex = 4;
            // 
            // Pass2Label
            // 
            this.Pass2Label.AutoSize = true;
            this.Pass2Label.Location = new System.Drawing.Point(92, 147);
            this.Pass2Label.Name = "Pass2Label";
            this.Pass2Label.Size = new System.Drawing.Size(112, 13);
            this.Pass2Label.TabIndex = 4;
            this.Pass2Label.Text = "Подтвердите пароль";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(111, 10);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(72, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Введите имя";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(16, 26);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(256, 20);
            this.tbName.TabIndex = 1;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(101, 50);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(100, 13);
            this.LastNameLabel.TabIndex = 7;
            this.LastNameLabel.Text = "Введите фамилию";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(16, 65);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(256, 20);
            this.tbLastName.TabIndex = 2;
            // 
            // First
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Pass2Label);
            this.Controls.Add(this.tbPass2);
            this.Controls.Add(this.tbPass1);
            this.Controls.Add(this.Pass1Label);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "First";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация администратора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label Pass1Label;
        private System.Windows.Forms.TextBox tbPass1;
        private System.Windows.Forms.TextBox tbPass2;
        private System.Windows.Forms.Label Pass2Label;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox tbLastName;
    }
}