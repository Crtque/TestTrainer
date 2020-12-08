namespace TrainerSpace
{
    partial class Editadmin
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
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(24, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 431);
            this.panel1.TabIndex = 0;
            // 
            // prevBtn
            // 
            this.prevBtn.Enabled = false;
            this.prevBtn.Location = new System.Drawing.Point(383, 504);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(180, 51);
            this.prevBtn.TabIndex = 1;
            this.prevBtn.Text = "Предыдущая страница";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(585, 504);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(180, 51);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = "Следующая страница";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(35, 504);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(180, 51);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Выход";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Editadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 591);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Editadmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить/удалить администратора";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}