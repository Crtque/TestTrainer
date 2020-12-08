using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainerSpace
{
    public partial class Editadmin : Form
    {
        int CurrentUserPos = 10;
        int StepOfPos = 10;
        public int UpperBorder = 10;
        static int CountOfUsers;
        static bool EndOfList = false;
        SystemMenuManager MenuManager;
        List<List<EventHandler>> EH = new List<List<EventHandler>>();
        List<Button> DeleteButtons = new List<Button>();
        List<Button> CancelButtons = new List<Button>();
        List<Button> AdminButtons = new List<Button>();
        List<Button> DadminButtons = new List<Button>();
        List<Button> EditButtons = new List<Button>();
        List<Button> SaveButtons = new List<Button>();
        public Editadmin()
        {
            InitializeComponent();
            MenuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            GetList(this, panel1, CurrentUserPos, UpperBorder);
            if (CurrentUserPos >= Count())
            {
                nextBtn.Enabled = false;
            }

            prevBtn.Enabled = false;

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            DeleteEvents();
            if ((CurrentUserPos + UpperBorder) < Count())
            {
                UpperBorder += StepOfPos;
                GetList(this, panel1, StepOfPos, UpperBorder);
            }
            else if ((CurrentUserPos + UpperBorder) > Count())
            {
                EndOfList = true;
                nextBtn.Enabled = false;
                if (Count() - UpperBorder == 0)
                {
                    GetList(this, panel1, StepOfPos, UpperBorder);
                }
                else if (Count() - UpperBorder > 0)
                {
                    GetList(this, panel1, Count() - UpperBorder, UpperBorder + StepOfPos);
                }
                else {
                    GetList(this, panel1, Count() - UpperBorder+StepOfPos, UpperBorder + StepOfPos);
                }

            }
            else if ((StepOfPos + UpperBorder) == Count()) {
                EndOfList = true;
                UpperBorder += StepOfPos;
                nextBtn.Enabled = false;
                GetList(this, panel1, StepOfPos, UpperBorder);
            }
            prevBtn.Enabled = true;



        }
        private void adminBtn_Click(object sender, EventArgs e,Button deleteBtn,Button adminBtn,Button dadminBtn )
        {
            string Query = "UPDATE users SET admin = '1' WHERE id=" + deleteBtn.Tag.ToString();
            Database.SendWriteQuery(Query);
            adminBtn.Visible = false;
            dadminBtn.Visible = true;
        }

        private void deleteBtn_Click(object sender, EventArgs e) {

            DialogResult DeletingUserDialog = MessageBox.Show("Вы уверены, что хотите удалить этот аккаунт?", "Удаление аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DeletingUserDialog == DialogResult.Yes)
            {
                string Query = "DELETE FROM users WHERE id=" + ((Button)sender).Tag.ToString();
                Database.SendWriteQuery(Query);
                if (Count() == 0)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(new Label() { Text = "Пользователи не найдены", AutoSize = true, Location = new Point(10, 30) });
                }
                else
                {
                    if (EndOfList)
                    {
                        GetList(this, panel1, Count() - UpperBorder + StepOfPos, UpperBorder);
                    }
                    else
                    {
                        if (UpperBorder == Count())
                        {
                            GetList(this, panel1, StepOfPos, UpperBorder);
                            UpperBorder -= StepOfPos;
                            nextBtn.Enabled = false;
                            EndOfList = true;
                        }
                        else if (UpperBorder > Count())
                        {
                            GetList(this, panel1, Count() - UpperBorder + StepOfPos, UpperBorder);
                            nextBtn.Enabled = false;
                            EndOfList = true;
                        }
                        else
                        {
                            GetList(this, panel1, StepOfPos, UpperBorder);
                        }

                    }
                }
            }
        }

        private void dadminBtn_Click(object sender, EventArgs e, Button adminBtn)
        {
            DialogResult DeketingAdminStatusDialog = MessageBox.Show("Вы уверены, что хотите разжаловать администратора?", 
                "Удаление администратора", MessageBoxButtons.YesNo);
            if (DeketingAdminStatusDialog == DialogResult.Yes)
            {
                string query = "UPDATE users SET admin = '0' WHERE id=" + ((Button)sender).Tag.ToString();
                Database.SendWriteQuery(query);
                ((Button)sender).Visible = false;
                adminBtn.Visible = true;
            }
            else if (DeketingAdminStatusDialog == DialogResult.No)
            {

            }
        }

        private void editBtn_Click(object sender, EventArgs e, Button saveBtn, TextBox title, Button cancelBtn)
        {
            ((Button)sender).Enabled = ((Button)sender).Visible = false;
            saveBtn.Enabled = saveBtn.Visible = title.Enabled = cancelBtn.Enabled = cancelBtn.Visible = true;
        }

        private void saveBtn_Click(object sender, EventArgs e, Button editBtn, Button cancelBtn, TextBox title, List<List<string>> Result)
        {
            if (title.Text != "")
            {
                if (Functions.StringOkay(title.Text))
                {
                    string Query = $"SELECT * FROM users WHERE login='{title.Text}'";
                    Result = Database.SendReadQuery(Query);
                    if (Result.Count > 0)
                    {
                        MessageBox.Show("Данный логин уже занят", "Ошибка");
                    }
                    else
                    {
                        Query = $"UPDATE users SET login = '{title.Text}' WHERE id = {((Button)sender).Tag.ToString()}";
                        Database.SendWriteQuery(Query);
                        MessageBox.Show("Вы обновили логин пользователя", "Успешно");
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
        private void cancelBtn_Click(object sender, EventArgs e, TextBox title, Button saveBtn, Button editBtn)
        {
            ((Button)sender).Enabled = ((Button)sender).Visible = false;
            editBtn.Enabled = editBtn.Visible = true;
            saveBtn.Enabled = saveBtn.Visible = false;
            title.Enabled = false;
        }
        private void DeleteEvents() {
            for (int i = 0; i < DeleteButtons.Count; i++) {
                DeleteButtons[i].Click -= EH[i][0];
                AdminButtons[i].Click -=  EH[i][1];
                DadminButtons[i].Click -= EH[i][2];
                EditButtons[i].Click -= EH[i][3];
                SaveButtons[i].Click -= EH[i][4];
                CancelButtons[i].Click -= EH[i][5];
            }
            EH.Clear();
        }

        public void GetList(Form form, Panel panel, int step, int upperBorder)
        {
           DeleteEvents();
           DeleteButtons.Clear();
            AdminButtons.Clear();
            DadminButtons.Clear();
            EditButtons.Clear();
            SaveButtons.Clear();
            CancelButtons.Clear();
           panel.Controls.Clear();
            CountOfUsers = Count();
            if (CountOfUsers > 0)
            {
                string Query = $"SELECT * FROM (SELECT * FROM (SELECT * FROM users WHERE admin !='2' AND id!='{User.GetId()}'" +
                    $"order by id asc LIMIT {upperBorder.ToString()})" +
                    $" as t order by t.id desc LIMIT {step.ToString()}) as m order by m.id asc";

                List<List<string>> Result = Database.SendReadQuery(Query);
                int lCount = 0;
                int Row = 0;
                if (upperBorder == step)
                {
                    prevBtn.Enabled = false;
                }

                if (Result.Count > 0)
                {
                    int i = 0;
                    while (i < Result.Count)
                    {
                        Row++;
                        string RowNumber = Row.ToString();
                        lCount++;
                        int pos_y = 20 + 30 * (lCount - 1);
                        Button deleteBtn = Elements.AddBtn("deleteBtn" + RowNumber, "Удалить", Result[i][0], 400, pos_y, 75, 23, true, true, false, form);
                        Button editBtn = Elements.AddBtn("editBtn" + RowNumber, "Редактировать", Result[i][0], 475, pos_y, 110, 23, true, true, false, form);
                        Button saveBtn = Elements.AddBtn("saveBtn" + RowNumber, "Сохранить", Result[i][0], 584, pos_y, 75, 23, false, false, false, form);
                        Button cancelBtn = Elements.AddBtn("editBtn" + RowNumber, "Отменить", Result[i][0], 475, pos_y, 110, 23, false, false, false, form);
                        Button adminBtn = Elements.AddBtn("adminBtn" + RowNumber, "Добавить администратора", Result[i][0], 240, pos_y, 170, 23, true, true, false, form);
                        Button dadminBtn = Elements.AddBtn("adminBtn" + RowNumber, "Удалить администратора", Result[i][0], 240, pos_y, 170, 23, true, true, false, form);

                        DeleteButtons.Add(deleteBtn);
                        EditButtons.Add(editBtn);
                        SaveButtons.Add(saveBtn);
                        CancelButtons.Add(cancelBtn);
                        AdminButtons.Add(adminBtn);
                        DadminButtons.Add(dadminBtn);

                        panel.Controls.Add(deleteBtn);
                        panel.Controls.Add(editBtn);
                        panel.Controls.Add(saveBtn);
                        panel.Controls.Add(cancelBtn);
                        panel.Controls.Add(adminBtn);
                        panel.Controls.Add(dadminBtn);
                        if (Result[i][5] == "1")
                        {
                            adminBtn.Visible = false;
                            dadminBtn.Visible = true;
                        }
                        else
                        {
                            adminBtn.Visible = true;
                            dadminBtn.Visible = false;
                        }
                        if (!User.IsAdmin())
                        {
                            adminBtn.Visible = false;
                            dadminBtn.Visible = false;
                        }
                        TextBox title = Elements.AddTb("textBox" + RowNumber + "1", Result[i][3], 140, pos_y, false, false, form);
                        Label label = Elements.AddLabel("label" + RowNumber + "1", "Логин пользователя", 5, pos_y, true, false, form);
                        label.AutoSize = true;
                        panel.Controls.Add(title);
                        panel.Controls.Add(label);
                        EH.Add(new List<EventHandler>());

                        EH[i].Add(deleteBtn_Click);
                        deleteBtn.Click += EH[i][0];

                        EH[i].Add((s, e) =>
                        {
                            adminBtn_Click(s, e, deleteBtn, adminBtn, dadminBtn);
                        });
                        adminBtn.Click += EH[i][1];

                        EH[i].Add((s, e) =>
                        {
                            dadminBtn_Click(s, e, adminBtn);
                        });
                        dadminBtn.Click += EH[i][2];

                        EH[i].Add((s, e) =>
                        {
                            editBtn_Click(s, e, saveBtn, title, cancelBtn);
                        });
                        editBtn.Click += EH[i][3];

                        EH[i].Add((s, e) =>
                        {
                            saveBtn_Click(s, e, editBtn, cancelBtn, title, Result);
                        });
                        saveBtn.Click += EH[i][4];

                        EH[i].Add((s, e) =>
                        {
                            cancelBtn_Click(s, e, title, saveBtn, editBtn);
                        });
                        cancelBtn.Click += EH[i][5];

                        i++;
                    }
                }
                else
                {
                    panel.Controls.Clear();
                    panel.Controls.Add(new Label() { Text = "Пользователи не найдены", AutoSize = true, Location = new Point(10, 30) });
                    if (EndOfList)
                    {
                        upperBorder -= StepOfPos;
                        GetList(this, panel1, StepOfPos, upperBorder);
                        //deletedeol = true;
                    }
                }

            }
            else
            {
                panel.Controls.Clear();
                panel.Controls.Add(new Label() { Text = "Пользователи не найдены", AutoSize = true, Location = new Point(10, 30) });
                
            }

        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            DeleteEvents();
            if (!EndOfList)
            {
                
                UpperBorder -= StepOfPos;
                GetList(this, panel1, StepOfPos, UpperBorder);
                EndOfList = false;
                nextBtn.Enabled = true;
            }
            else
            {
                
                if (UpperBorder == Count())
                {
                    
                    UpperBorder -= StepOfPos;
                    
                    GetList(this, panel1, StepOfPos, UpperBorder);
                    EndOfList = false;
                    nextBtn.Enabled = true;
                }
                else
                {
                    if (UpperBorder > Count()) {
                        
                        UpperBorder -= StepOfPos;
                        UpperBorder -= StepOfPos;
                        GetList(this, panel1, StepOfPos, UpperBorder);
                        EndOfList = false;
                        nextBtn.Enabled = true;

                    }
                    else {
                        
                        GetList(this, panel1, StepOfPos, UpperBorder);
                        EndOfList = false;
                        nextBtn.Enabled = true;

                    }
                   
                }

            }


        }

        private int Count()
        {
            string Query = $"SELECT COUNT(*) FROM users WHERE admin !='2' AND  id !='{User.GetId()}'";
            List<List<string>> CountOfUsersResult;
            CountOfUsersResult = Database.SendReadQuery(Query);

            return Convert.ToInt32(CountOfUsersResult[0][0]);

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DeleteEvents();
            Dispose();
            Close();
        }
    }
}
