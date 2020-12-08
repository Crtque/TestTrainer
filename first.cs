using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Helpers;

using static TrainerSpace.Functions;
namespace TrainerSpace
{

    public partial class First : Form
    {


        public First()
        {
            InitializeComponent();
        }


        private void Check()
        {
            if (StringOkay(tbName.Text) && StringOkay(tbLastName.Text) && StringOkay(tbPass1.Text) && StringOkay(tbPass2.Text))
            {
                if (tbPass1.Text.Equals(tbPass2.Text) && !IsEmpty(tbPass1.Text) && !tbLastName.Text.Equals("") && !tbName.Text.Equals(""))
                {
                    string salt = Crypto.GenerateSalt();
                    string query = $"insert into users(name,surname,login,password,admin,salt) values('{tbName.Text}', '{tbLastName.Text}', " +
                        $"'admin','{Crypto.HashPassword(tbPass1.Text + salt + GetSalt())}',2,'{salt}')";
                    Database.SendWriteQuery(query);
                    query = $"select * from users where login = 'admin'";
                    List<List<string>> result = Database.SendReadQuery(query);
                    User.SetId(Convert.ToInt32(result[0][0]));
                    User.SetName(result[0][1]);
                    User.SetSurname(result[0][2]);
                    User.SetLogin("admin");
              
                    Application.Restart();
                    
                }
                else
                {
                    if (tbLastName.Text.Equals("") || tbName.Text.Equals("") || tbPass1.Text.Equals("") || tbPass2.Text.Equals(""))
                        MessageBox.Show("Одно из полей не заполнено", "Ошибка!");
                    else if (tbPass1.Text != tbPass2.Text)
                        MessageBox.Show("Введенные пароли не совпадают", "Ошибка");
                }
            }
            else {
                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
            }
        }


        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            Check();
        }
        

    }
}
