namespace TrainerSpace
{
    partial class QuestionInfo
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddRowLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(585, 415);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(670, 415);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(22, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 364);
            this.panel1.TabIndex = 2;
            // 
            // AddRowLabel
            // 
            this.AddRowLabel.AutoSize = true;
            this.AddRowLabel.Location = new System.Drawing.Point(667, 18);
            this.AddRowLabel.Name = "AddRowLabel";
            this.AddRowLabel.Size = new System.Drawing.Size(88, 13);
            this.AddRowLabel.TabIndex = 3;
            this.AddRowLabel.TabStop = true;
            this.AddRowLabel.Text = "Добавить ответ";
            this.AddRowLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddRowLabel_LinkClicked);
            // 
            // QuestionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddRowLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "QuestionInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование вопроса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel AddRowLabel;
    }
}