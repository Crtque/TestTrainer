namespace TrainerSpace
{
    partial class Addquestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addquestion));
            this.NewQuestionBtn = new System.Windows.Forms.Button();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CancelBtn = new System.Windows.Forms.Button();
            this.themeLabel = new System.Windows.Forms.Label();
            this.ThemeComboBox = new System.Windows.Forms.ComboBox();
            this.NewThemeBtn = new System.Windows.Forms.Button();
            this.ThemeNameLabel = new System.Windows.Forms.Label();
            this.tbThemeName = new System.Windows.Forms.TextBox();
            this.LongRadio = new System.Windows.Forms.RadioButton();
            this.MatchRadio = new System.Windows.Forms.RadioButton();
            this.ShortRadio = new System.Windows.Forms.RadioButton();
            this.questionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewRowLLabel = new System.Windows.Forms.LinkLabel();
            this.FullRadio = new System.Windows.Forms.RadioButton();
            this.ImageRadio = new System.Windows.Forms.RadioButton();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // NewQuestionBtn
            // 
            this.NewQuestionBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewQuestionBtn.Location = new System.Drawing.Point(482, 353);
            this.NewQuestionBtn.Name = "NewQuestionBtn";
            this.NewQuestionBtn.Size = new System.Drawing.Size(221, 48);
            this.NewQuestionBtn.TabIndex = 0;
            this.NewQuestionBtn.Text = "Добавить";
            this.NewQuestionBtn.UseVisualStyleBackColor = true;
            this.NewQuestionBtn.Click += new System.EventHandler(this.NewQuestionBtn_Click);
            // 
            // tbQuestion
            // 
            this.tbQuestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbQuestion.Location = new System.Drawing.Point(89, 68);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(614, 20);
            this.tbQuestion.TabIndex = 1;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(39, 65);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(44, 13);
            this.questionLabel.TabIndex = 2;
            this.questionLabel.Text = "Вопрос";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(273, 353);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(192, 48);
            this.CancelBtn.TabIndex = 12;
            this.CancelBtn.Text = "Назад";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Location = new System.Drawing.Point(49, 35);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(34, 13);
            this.themeLabel.TabIndex = 13;
            this.themeLabel.Text = "Тема";
            // 
            // ThemeComboBox
            // 
            this.ThemeComboBox.FormattingEnabled = true;
            this.ThemeComboBox.Location = new System.Drawing.Point(89, 35);
            this.ThemeComboBox.Name = "ThemeComboBox";
            this.ThemeComboBox.Size = new System.Drawing.Size(614, 21);
            this.ThemeComboBox.TabIndex = 14;
            // 
            // NewThemeBtn
            // 
            this.NewThemeBtn.Location = new System.Drawing.Point(115, 313);
            this.NewThemeBtn.Name = "NewThemeBtn";
            this.NewThemeBtn.Size = new System.Drawing.Size(75, 23);
            this.NewThemeBtn.TabIndex = 17;
            this.NewThemeBtn.Text = "Добавить";
            this.NewThemeBtn.UseVisualStyleBackColor = true;
            this.NewThemeBtn.Click += new System.EventHandler(this.NewThemeBtn_Click);
            // 
            // ThemeNameLabel
            // 
            this.ThemeNameLabel.AutoSize = true;
            this.ThemeNameLabel.Location = new System.Drawing.Point(9, 296);
            this.ThemeNameLabel.Name = "ThemeNameLabel";
            this.ThemeNameLabel.Size = new System.Drawing.Size(87, 13);
            this.ThemeNameLabel.TabIndex = 16;
            this.ThemeNameLabel.Text = "Название темы";
            // 
            // tbThemeName
            // 
            this.tbThemeName.Location = new System.Drawing.Point(9, 315);
            this.tbThemeName.Name = "tbThemeName";
            this.tbThemeName.Size = new System.Drawing.Size(100, 20);
            this.tbThemeName.TabIndex = 15;
            // 
            // LongRadio
            // 
            this.LongRadio.AutoSize = true;
            this.LongRadio.Location = new System.Drawing.Point(260, 12);
            this.LongRadio.Name = "LongRadio";
            this.LongRadio.Size = new System.Drawing.Size(120, 17);
            this.LongRadio.TabIndex = 23;
            this.LongRadio.Text = "С полным ответом";
            this.LongRadio.UseVisualStyleBackColor = true;
            this.LongRadio.CheckedChanged += new System.EventHandler(this.LongRadio_CheckedChanged);
            // 
            // MatchRadio
            // 
            this.MatchRadio.AutoSize = true;
            this.MatchRadio.Location = new System.Drawing.Point(387, 12);
            this.MatchRadio.Name = "MatchRadio";
            this.MatchRadio.Size = new System.Drawing.Size(95, 17);
            this.MatchRadio.TabIndex = 24;
            this.MatchRadio.Text = "Соответствие";
            this.MatchRadio.UseVisualStyleBackColor = true;
            this.MatchRadio.CheckedChanged += new System.EventHandler(this.MatchRadio_CheckedChanged);
            // 
            // ShortRadio
            // 
            this.ShortRadio.AutoSize = true;
            this.ShortRadio.Checked = true;
            this.ShortRadio.Location = new System.Drawing.Point(489, 12);
            this.ShortRadio.Name = "ShortRadio";
            this.ShortRadio.Size = new System.Drawing.Size(123, 17);
            this.ShortRadio.TabIndex = 25;
            this.ShortRadio.TabStop = true;
            this.ShortRadio.Text = "С кратким ответом";
            this.ShortRadio.UseVisualStyleBackColor = true;
            this.ShortRadio.CheckedChanged += new System.EventHandler(this.ShortRadio_CheckedChanged);
            // 
            // questionsBindingSource
            // 
            this.questionsBindingSource.DataMember = "questions";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 194);
            this.panel1.TabIndex = 30;
            // 
            // NewRowLLabel
            // 
            this.NewRowLLabel.AutoSize = true;
            this.NewRowLLabel.Location = new System.Drawing.Point(636, 14);
            this.NewRowLLabel.Name = "NewRowLLabel";
            this.NewRowLLabel.Size = new System.Drawing.Size(88, 13);
            this.NewRowLLabel.TabIndex = 30;
            this.NewRowLLabel.TabStop = true;
            this.NewRowLLabel.Text = "Добавить ответ";
            this.NewRowLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NewRowLabel_LinkClicked);
            // 
            // FullRadio
            // 
            this.FullRadio.AutoSize = true;
            this.FullRadio.Location = new System.Drawing.Point(102, 12);
            this.FullRadio.Name = "FullRadio";
            this.FullRadio.Size = new System.Drawing.Size(152, 17);
            this.FullRadio.TabIndex = 31;
            this.FullRadio.Text = "С проверяемым ответом";
            this.FullRadio.UseVisualStyleBackColor = true;
            this.FullRadio.CheckedChanged += new System.EventHandler(this.FullRadio_CheckedChanged);
            // 
            // ImageRadio
            // 
            this.ImageRadio.AutoSize = true;
            this.ImageRadio.Location = new System.Drawing.Point(23, 12);
            this.ImageRadio.Name = "ImageRadio";
            this.ImageRadio.Size = new System.Drawing.Size(73, 17);
            this.ImageRadio.TabIndex = 32;
            this.ImageRadio.Text = "Картинка";
            this.ImageRadio.UseVisualStyleBackColor = true;
            this.ImageRadio.CheckedChanged += new System.EventHandler(this.ImageRadio_CheckedChanged);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // Addquestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(744, 413);
            this.Controls.Add(this.ImageRadio);
            this.Controls.Add(this.FullRadio);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.NewRowLLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.ShortRadio);
            this.Controls.Add(this.MatchRadio);
            this.Controls.Add(this.LongRadio);
            this.Controls.Add(this.NewThemeBtn);
            this.Controls.Add(this.ThemeComboBox);
            this.Controls.Add(this.themeLabel);
            this.Controls.Add(this.ThemeNameLabel);
            this.Controls.Add(this.tbThemeName);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.NewQuestionBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Addquestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление вопросов";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewQuestionBtn;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        
        private System.Windows.Forms.BindingSource questionsBindingSource;
       
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.ComboBox ThemeComboBox;
        
        private System.Windows.Forms.Button NewThemeBtn;
        private System.Windows.Forms.Label ThemeNameLabel;
        private System.Windows.Forms.TextBox tbThemeName;
        private System.Windows.Forms.RadioButton LongRadio;
        private System.Windows.Forms.RadioButton MatchRadio;
        private System.Windows.Forms.RadioButton ShortRadio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel NewRowLLabel;
        private System.Windows.Forms.RadioButton FullRadio;
        private System.Windows.Forms.RadioButton ImageRadio;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

