namespace TrainerSpace
{
    partial class ReadQuestion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.unCheckedRadio = new System.Windows.Forms.RadioButton();
            this.WrongRadio = new System.Windows.Forms.RadioButton();
            this.RightRadio = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.RightRadio);
            this.panel1.Controls.Add(this.WrongRadio);
            this.panel1.Controls.Add(this.unCheckedRadio);
            this.panel1.Controls.Add(this.ConfirmBtn);
            this.panel1.Location = new System.Drawing.Point(13, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 362);
            this.panel1.TabIndex = 0;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(14, 309);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(125, 23);
            this.ConfirmBtn.TabIndex = 0;
            this.ConfirmBtn.Text = "Оценить";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // unCheckedRadio
            // 
            this.unCheckedRadio.AutoSize = true;
            this.unCheckedRadio.Location = new System.Drawing.Point(14, 240);
            this.unCheckedRadio.Name = "unCheckedRadio";
            this.unCheckedRadio.Size = new System.Drawing.Size(96, 17);
            this.unCheckedRadio.TabIndex = 1;
            this.unCheckedRadio.TabStop = true;
            this.unCheckedRadio.Text = "Не проверено";
            this.unCheckedRadio.UseVisualStyleBackColor = true;
            this.unCheckedRadio.CheckedChanged += new System.EventHandler(this.unCheckedRadio_CheckedChanged);
            // 
            // WrongRadio
            // 
            this.WrongRadio.AutoSize = true;
            this.WrongRadio.Location = new System.Drawing.Point(14, 263);
            this.WrongRadio.Name = "WrongRadio";
            this.WrongRadio.Size = new System.Drawing.Size(132, 17);
            this.WrongRadio.TabIndex = 2;
            this.WrongRadio.TabStop = true;
            this.WrongRadio.Text = "Неправильный ответ";
            this.WrongRadio.UseVisualStyleBackColor = true;
            this.WrongRadio.CheckedChanged += new System.EventHandler(this.WrongRadio_CheckedChanged);
            // 
            // RightRadio
            // 
            this.RightRadio.AutoSize = true;
            this.RightRadio.Location = new System.Drawing.Point(14, 286);
            this.RightRadio.Name = "RightRadio";
            this.RightRadio.Size = new System.Drawing.Size(120, 17);
            this.RightRadio.TabIndex = 3;
            this.RightRadio.TabStop = true;
            this.RightRadio.Text = "Правильный ответ";
            this.RightRadio.UseVisualStyleBackColor = true;
            this.RightRadio.CheckedChanged += new System.EventHandler(this.RightRadio_CheckedChanged);
            // 
            // ReadQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 439);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadQuestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О вопросе";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.RadioButton RightRadio;
        private System.Windows.Forms.RadioButton WrongRadio;
        private System.Windows.Forms.RadioButton unCheckedRadio;
    }
}