using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainerSpace
{
    public partial class Editheme : Form
    {
        SystemMenuManager MenuManager;
        public Editheme()
        {
            InitializeComponent();
            this.MenuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            GetList(this, panel1);
        }
        List<List<EventHandler>> EH = new List<List<EventHandler>>();
        List<Button> DeleteButtons = new List<Button>();
        List<Button> CancelButtons = new List<Button>();
        List<Button> EditButtons = new List<Button>();
        List<Button> SaveButtons = new List<Button>();
        private void deleteBtn_Click(object sender, EventArgs e, Form form, Panel panel)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить тему?", "Удаление темы", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string Query = "DELETE FROM questions WHERE subject_id=" + ((Button)sender).Tag.ToString();
                Database.SendWriteQuery(Query);
                Query = "DELETE FROM subjects WHERE id=" + ((Button)sender).Tag.ToString();
                Database.SendWriteQuery(Query);
                GetList(form, panel);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        private void editBtn_Click(object sender, EventArgs e, TextBox title, Button saveBtn, Button cancelBtn)
        {
            ((Button)sender).Enabled = ((Button)sender).Visible = false;
            saveBtn.Enabled = saveBtn.Visible = title.Enabled = cancelBtn.Enabled = cancelBtn.Visible = true;
        }

        private void DeleteEvents()
        {
            for (int i = 0; i < DeleteButtons.Count; i++)
            {
                DeleteButtons[i].Click -= EH[i][0];
                EditButtons[i].Click -= EH[i][1];
                SaveButtons[i].Click -= EH[i][2];
                CancelButtons[i].Click -= EH[i][3];
            }
            EH.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e, TextBox title, Button editBtn, Button cancelBtn, List<List<string>> Result)
        {
            if (title.Text != "")
            {
                if (Functions.StringOkay(title.Text))
                {
                    string query = $"SELECT * FROM subjects WHERE name='{title.Text}'";
                    Result = Database.SendReadQuery(query);
                    if (Result.Count > 0)
                    {
                        MessageBox.Show("Вопрос с таким же названием уже создан", "Ошибка");
                    }
                    else
                    {

                        query = $"UPDATE subjects SET name = '{title.Text}' WHERE id =" + ((Button)sender).Tag.ToString();
                        Database.SendWriteQuery(query);
                        MessageBox.Show("Вы обновили название темы", "Успешно");
                        editBtn.Enabled = editBtn.Visible = true;
                        cancelBtn.Enabled = cancelBtn.Visible = title.Enabled = ((Button)sender).Enabled = ((Button)sender).Visible = false;


                    }
                }
                else
                {
                    MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Данное поле не может быть пустым", "Ошибка");
            }

        }
        private void cancelBtn_Click(object sender, EventArgs e, TextBox title, Button editBtn, Button saveBtn)
        {
            ((Button)sender).Enabled = ((Button)sender).Visible = false;
            editBtn.Enabled = editBtn.Visible = true;
            saveBtn.Enabled = saveBtn.Visible = false;
            title.Enabled = false;
        }
        public  void GetList(Form form, Panel panel)
        {
            DeleteEvents();
            DeleteButtons.Clear();
            EditButtons.Clear();
            SaveButtons.Clear();
            CancelButtons.Clear();
            panel.Controls.Clear();

            form.Location = new Point((Screen.PrimaryScreen.Bounds.Width - form.Width) / 2,
            (Screen.PrimaryScreen.Bounds.Height - form.Height) / 2);

            string Selectquery = "select * from subjects order by id asc";
            List<List<string>> Result = Database.SendReadQuery(Selectquery);
            int lCount = 0;
            int Row = 0;
            if (Result.Count > 0)
            {
                int i = 0;
                while (i < Result.Count)
                {
                    Row++;
                    string r_num = Row.ToString();
                    lCount++;
                    int pos_y = 15 + 30 * (lCount - 1);
                    Button deleteBtn = Elements.AddBtn("deleteBtn" + r_num, "Удалить", Result[i][0], 510, pos_y - panel.VerticalScroll.Value, 75, 23, true, true, false, form);
                    Button editBtn = Elements.AddBtn("editBtn" + r_num, "Редактировать", Result[i][0], 580, pos_y - panel.VerticalScroll.Value, 110, 23, true, true, false, form);
                    Button saveBtn = Elements.AddBtn("saveBtn" + r_num, "Сохранить", Result[i][0], 690, pos_y - panel.VerticalScroll.Value, 75, 23, false, false, false, form);
                    Button cancelBtn = Elements.AddBtn("editBtn" + r_num, "Отменить", Result[i][0], 580, pos_y - panel.VerticalScroll.Value, 110, 23, false, false, false, form);

                    TextBox title = Elements.AddTb("textBox" + r_num + "1", Result[i][1], 10, pos_y - panel.VerticalScroll.Value, false, false, form);
                    title.Width = 480;

                    DeleteButtons.Add(deleteBtn);
                    EditButtons.Add(editBtn);
                    SaveButtons.Add(saveBtn);
                    CancelButtons.Add(cancelBtn);

                    panel.Controls.Add(deleteBtn);
                    panel.Controls.Add(editBtn);
                    panel.Controls.Add(saveBtn);
                    panel.Controls.Add(cancelBtn);
                    panel.Controls.Add(title);

                    EH.Add(new List<EventHandler>());

                    EH[i].Add((s, e) =>
                    {
                        deleteBtn_Click(s, e, form, panel);
                    });
                    deleteBtn.Click += EH[i][0];

                    EH[i].Add((s, e) =>
                    {
                        editBtn_Click(s, e, title, saveBtn, cancelBtn);
                    });
                    editBtn.Click += EH[i][1];

                    EH[i].Add((s, e) =>
                    {
                        saveBtn_Click(s, e, title, editBtn, cancelBtn, Result);
                    });
                    saveBtn.Click += EH[i][2];

                    EH[i].Add((s, e) =>
                    {
                        cancelBtn_Click(s, e, title, editBtn, saveBtn);
                    });
                    cancelBtn.Click += EH[i][3];

                    i++;
                }
            }
            else
            {
                panel.Controls.Add(new Label() { Text = "Не добавлено ни одной темы", AutoSize = true, Location = new Point(10, 30) });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteEvents();
            this.Close();
        }
    }
}
