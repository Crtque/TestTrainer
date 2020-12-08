namespace TrainerSpace
{
    partial class Quiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quiz));
            this.title = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoEllipsis = true;
            this.title.AutoSize = true;
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.title.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.MaximumSize = new System.Drawing.Size(760, 588);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.title.Size = new System.Drawing.Size(89, 30);
            this.title.TabIndex = 0;
            this.title.Text = "Вопрос";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Location = new System.Drawing.Point(329, 518);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(222, 45);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Следующий";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(12, 518);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(223, 45);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "Предыдущий";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(641, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(198, 45);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Выход";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(13, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 466);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // Quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Quiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тренажер";
            this.Load += new System.EventHandler(this.Quiz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
    }
}