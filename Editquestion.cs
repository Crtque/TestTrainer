using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainerSpace
{
    public partial class Editquestion : Form
    {
        private Panel panel1;
        SystemMenuManager MenuManager;
        public Editquestion()
        {
            InitializeComponent();
            //-100 flag
            this.MenuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            CreateCombo(-100, 1, this,panel1);
        }
        List<List<EventHandler>> EH = new List<List<EventHandler>>();
        List<Button> DeleteButtons = new List<Button>();
        private Button button1;
        List<Button> EditButtons = new List<Button>();
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(13, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 498);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Editquestion
            // 
            this.ClientSize = new System.Drawing.Size(814, 583);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Editquestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование вопросов";
            this.ResumeLayout(false);

        }
        private void DeleteEvents()
        {
            for (int i = 0; i < DeleteButtons.Count; i++)
            {
                DeleteButtons[i].Click -= EH[i][0];
                EditButtons[i].Click -= EH[i][1];
            }
            EH.Clear();
        }
        private void deleteBtn_Click(object sender, EventArgs e, Form form, Panel panel, int subj_id, int selectedind)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить вопрос?", "Удаление вопроса", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "DELETE FROM questions WHERE id=" + ((Button)sender).Tag.ToString();
                Database.SendWriteQuery(query);
                CreateCombo(selectedind, subj_id, form, panel);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void editBtn_Click(object sender, EventArgs e, Form form)
        {
            QuestionInfo f = new QuestionInfo(((Button)sender).Tag.ToString());
            f.Owner = form;
            f.ShowDialog();
        }
        public void GetListOfQuestions(int selectedind, int subj_id, Form form, Panel panel)
        {
            DeleteEvents();
            DeleteButtons.Clear();
            EditButtons.Clear();
            form.Location = new Point((Screen.PrimaryScreen.Bounds.Width - form.Width) / 2,
            (Screen.PrimaryScreen.Bounds.Height - form.Height) / 2);
            string selectquery = $"select * from questions where subject_id ='{subj_id}' order by id asc";
            List<List<string>> result = Database.SendReadQuery(selectquery);
            int lCount = 0;
            int row = 0;

            if (result.Count > 0)
            {
                int i = 0;
                while (i < result.Count)
                {
                    int type = Convert.ToInt32(result[i][4]);
                    row++;
                    string r_num = row.ToString();
                    lCount++;
                    int pos_y = 15 + 30 * (lCount - 1);
                    Button deleteBtn = Elements.AddBtn("deleteBtn" + r_num, "Удалить", result[i][0], 510, pos_y, 75, 23, true, true, false, form);
                    Button editBtn = Elements.AddBtn("editBtn" + r_num, "Редактировать", result[i][0], 580, pos_y, 110, 23, true, true, false, form);

                    TextBox question = Elements.AddTb("textBox" + r_num + "1", result[i][1], 10, pos_y, false, false, form);
                    question.Width = 480;
                    panel.Controls.Add(deleteBtn);
                    panel.Controls.Add(editBtn);
                    panel.Controls.Add(question);

                    DeleteButtons.Add(deleteBtn);
                    EditButtons.Add(editBtn);
                    EH.Add(new List<EventHandler>());
                    EH[i].Add((s, e) =>
                    {
                        deleteBtn_Click(s, e, form, panel, subj_id, selectedind);
                    });
                    deleteBtn.Click += EH[i][0];

                    EH[i].Add((s, e) =>
                    {
                        editBtn_Click(s, e, form);
                    });
                    editBtn.Click += EH[i][1];


                    i++;
                }
            }
            else
            {
                panel.Controls.Add(new Label() { Text = "Нет вопросов по данной теме", AutoSize = true, Location = new Point(10, 30) });
            }

        }

        public void CreateCombo(int select, int subj_id, Form form, Panel panel)
        {
            List<List<string>> ListOfCombo = new List<List<string>>();
            panel.Controls.Clear();
            if (select != -100)
                GetListOfQuestions(select, subj_id, form, panel);

            string query = "select * from subjects order by id asc";
            ListOfCombo = Database.SendReadQuery(query);

            ComboBox cmbx = new ComboBox
            {
                Location = new Point(600, 5)
            };

            cmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            if (ListOfCombo.Count == 0)
            {
                cmbx.Enabled = false;
            }
            if (ListOfCombo.Count > 0)
            {
                cmbx.Enabled = true;
                int i = 0;
                while (i < ListOfCombo.Count)
                {
                    cmbx.Items.Add(ListOfCombo[i][1]);
                    i++;
                }


            }
            if (select == -100)   //-100 flag
            {
                cmbx.Text = "Выберите тему";
            }
            else
            {
                cmbx.SelectedIndex = select;
            }
            int selected, sel_subj;
            EventHandler SelectedIndexHandler = null;
            SelectedIndexHandler = (s, f) =>
            {
                selected = cmbx.SelectedIndex;
                panel.Controls.Clear();
                sel_subj = Convert.ToInt32(ListOfCombo[cmbx.SelectedIndex][0]);
                GetListOfQuestions(selected, sel_subj, form, panel);
                CreateCombo(selected, sel_subj, form, panel);
            };
            cmbx.SelectedIndexChanged += SelectedIndexHandler;
            form.Controls.Add(cmbx);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteEvents();
            this.Close();
        }
    }


}
