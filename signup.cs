using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Windows.Forms;
using static TrainerSpace.Functions;

namespace TrainerSpace
{
    public partial class Signup : Form
    {

        SystemMenuManager menuManager;
        public Signup()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (StringOkay(tbLogin.Text) && StringOkay(tbPassword.Text) && StringOkay(tbName.Text) 
                && StringOkay(tbSurname.Text) && StringOkay(tbPassRepeat.Text))
            {
                if (!tbLogin.Text.Equals("") && !tbPassword.Text.Equals("") && !tbName.Text.Equals("") && !tbSurname.Text.Equals(""))
                {
                    string selectquery = $"select * from users where login = '{tbLogin.Text}'";
                    List<List<string>> result = Database.SendReadQuery(selectquery);
                    if (tbLogin.Text.Equals("admin"))
                    {
                        MessageBox.Show("Нельзя зарегистрировать пользователя с логином 'admin'", "Ошибка!");
                    }
                    else if (!tbPassword.Text.Equals(tbPassRepeat.Text))
                    {
                        MessageBox.Show("Введённые пароли не совпадают", "Ошибка!");
                    }
                    else if (result.Count == 0)
                    {

                        string salt = Crypto.GenerateSalt();
                        string query = $"insert into users(login,password,surname,name,salt)" +
                            $" values('{tbLogin.Text}','{Crypto.HashPassword(tbPassword.Text + salt + GetSalt())}','{tbSurname.Text}','{tbName.Text}','{salt}')";
                        Database.SendWriteQuery(query);
                        query = $"select * from users where login = '{tbLogin.Text}'";
                        result = Database.SendReadQuery(query);
                        User.SetId(Convert.ToInt32(result[0][0]));
                        User.SetName(result[0][1]);
                        User.SetSurname(result[0][2]);
                        User.SetLogin(result[0][3]);
                 
                        Application.Restart();


                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже зарегистрирован!", "Ок");
                    }
                }
                else
                {
                    MessageBox.Show("Одно из полей не заполнено!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

    }
}
