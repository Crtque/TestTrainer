namespace TrainerSpace
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.questionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AddQuestionBtn = new System.Windows.Forms.Button();
            this.EditQuestionBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ResultsBtn = new System.Windows.Forms.Button();
            this.AddThemeBtn = new System.Windows.Forms.Button();
            this.AddAdminBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AddQuestionBtn
            // 
            this.AddQuestionBtn.Location = new System.Drawing.Point(13, 12);
            this.AddQuestionBtn.Name = "AddQuestionBtn";
            this.AddQuestionBtn.Size = new System.Drawing.Size(345, 45);
            this.AddQuestionBtn.TabIndex = 1;
            this.AddQuestionBtn.Text = "Добавить вопрос / тему";
            this.AddQuestionBtn.UseVisualStyleBackColor = true;
            this.AddQuestionBtn.Click += new System.EventHandler(this.AddQuestionBtn_Click);
            // 
            // EditQuestionBtn
            // 
            this.EditQuestionBtn.Location = new System.Drawing.Point(364, 12);
            this.EditQuestionBtn.Name = "EditQuestionBtn";
            this.EditQuestionBtn.Size = new System.Drawing.Size(319, 45);
            this.EditQuestionBtn.TabIndex = 2;
            this.EditQuestionBtn.Text = "Редактировать / удалить вопросы";
            this.EditQuestionBtn.UseVisualStyleBackColor = true;
            this.EditQuestionBtn.Click += new System.EventHandler(this.EditQuestionBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(13, 398);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(336, 32);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Назад";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(355, 397);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(328, 32);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Выход";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ResultsBtn
            // 
            this.ResultsBtn.Location = new System.Drawing.Point(364, 63);
            this.ResultsBtn.Name = "ResultsBtn";
            this.ResultsBtn.Size = new System.Drawing.Size(319, 49);
            this.ResultsBtn.TabIndex = 5;
            this.ResultsBtn.Text = "Результаты";
            this.ResultsBtn.UseVisualStyleBackColor = true;
            this.ResultsBtn.Click += new System.EventHandler(this.ResultsBtn_Click);
            // 
            // AddThemeBtn
            // 
            this.AddThemeBtn.Location = new System.Drawing.Point(13, 63);
            this.AddThemeBtn.Name = "AddThemeBtn";
            this.AddThemeBtn.Size = new System.Drawing.Size(345, 49);
            this.AddThemeBtn.TabIndex = 6;
            this.AddThemeBtn.Text = "Редактировать / удалить тему";
            this.AddThemeBtn.UseVisualStyleBackColor = true;
            this.AddThemeBtn.Click += new System.EventHandler(this.AddThemeBtn_Click);
            // 
            // AddAdminBtn
            // 
            this.AddAdminBtn.Location = new System.Drawing.Point(13, 116);
            this.AddAdminBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddAdminBtn.Name = "AddAdminBtn";
            this.AddAdminBtn.Size = new System.Drawing.Size(670, 44);
            this.AddAdminBtn.TabIndex = 8;
            this.AddAdminBtn.Text = "Добавить/удалить администратора";
            this.AddAdminBtn.UseVisualStyleBackColor = true;
            this.AddAdminBtn.Click += new System.EventHandler(this.AddAdminBtn_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 442);
            this.Controls.Add(this.AddAdminBtn);
            this.Controls.Add(this.AddThemeBtn);
            this.Controls.Add(this.ResultsBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.EditQuestionBtn);
            this.Controls.Add(this.AddQuestionBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource questionsBindingSource;
        private System.Windows.Forms.Button AddQuestionBtn;
        private System.Windows.Forms.Button EditQuestionBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ResultsBtn;
 
        private System.Windows.Forms.Button AddThemeBtn;
        private System.Windows.Forms.Button AddAdminBtn;
    }
}