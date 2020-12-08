using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Windows.Forms;
using static TrainerSpace.Functions;
namespace TrainerSpace
{
    public partial class Auth : Form
    {
        public static string user_id,name,surname;
        public Auth()
        {
            InitializeComponent();
        }

        private void SignupBtn_Click(object sender, EventArgs e)
        {
            Signup Form = new Signup();
            Form.ShowDialog();
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void CheckLogin()
        {
            if (StringOkay(tbLogin.Text)){
                string Query = $"select password,salt from users where login ='{tbLogin.Text}'";
                List<List<string>> res = Database.SendReadQuery(Query);
                if(res.Count > 0) {
                        Console.WriteLine(Crypto.HashPassword(tbPassword.Text + res[0][1] + GetSalt()));
                    bool doesPasswordMatch = Crypto.VerifyHashedPassword(res[0][0], tbPassword.Text + res[0][1] + GetSalt());
                    if (doesPasswordMatch)
                    {
                        Query = $"select * from users where login ='{tbLogin.Text}'";
                        List<List<string>> Result = Database.SendReadQuery(Query);

                            User.SetId(Convert.ToInt32(Result[0][0]));
                            User.SetName(Result[0][1]);
                            User.SetSurname(Result[0][2]);
                        User.SetLogin(Result[0][3]);
                            Application.Restart();
                        

                    }
                    else{
                        MessageBox.Show("Неверное имя пользователя или пароль");
                    }
                }
                else {
                    MessageBox.Show("Неверное имя пользователя или пароль");
                }

            }
            else {
                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.","Ошибка");
            }
        }

    }
}
