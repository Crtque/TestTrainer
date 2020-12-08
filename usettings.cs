using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using static TrainerSpace.Functions;

namespace TrainerSpace
{
    public partial class Usettings : Form
    {
        List<List<string>> Result;
        public Usettings()
        {
            InitializeComponent();
            if (!User.IsAdmin())
            {
                FullResetBtn.Visible = FullResetBtn.Enabled = false;
            }
            string Query = $"select * from users where login = '{User.GetLogin()}'";
            Result = Database.SendReadQuery(Query);
            nametxtbx.Text = Result[0][1];
            nametxtbx.Enabled = false;
            Query = $"select * from users where login = '{User.GetLogin()}'";
            Result = Database.SendReadQuery(Query);
            surnametxtbx.Text = Result[0][2];
            surnametxtbx.Enabled = false;
            label5.Text = "Текущая версия: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void EditPassBtn_Click(object sender, EventArgs e)
        {
            if (passtxtbx.Text.Equals(passtxtbx2.Text))
            {
                if (StringOkay(passtxtbx.Text))
                {
                    string Query = $"UPDATE users SET password = '{Hash(passtxtbx.Text)}' where login= '{User.GetLogin()}'";
                    Database.SendWriteQuery(Query);
                    MessageBox.Show("Успешная смена пароля", "Все хорошо");
                    User.LogOut();
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                }

            }
            else
            {
                MessageBox.Show("Введенные пароли не совпадают", "Ошибка");
            }
        }

        private void SaveNameBtn_Click(object sender, EventArgs e)
        {
            editnameBtn.Visible = editnameBtn.Enabled = true;
            savenameBtn.Visible = savenameBtn.Enabled = false;
            nametxtbx.Enabled = false;
            if (!User.GetName().Equals(nametxtbx.Text))
            {
                if (StringOkay(nametxtbx.Text))
                {
                    string Query = $"UPDATE users SET name = '{nametxtbx.Text}' where login='{User.GetLogin()}'";
                    Database.SendWriteQuery(Query);
                    User.SetName(nametxtbx.Text);
                    MessageBox.Show($"Имя пользователя было изменено на '{nametxtbx.Text}'. Необхоимо заново пройти авторизацию.", "Успешно!");
                    User.LogOut();
                    Application.Restart();
                }
                else
                {
                    editnameBtn.Visible = editnameBtn.Enabled = false;
                    savenameBtn.Visible = savenameBtn.Enabled = true;
                    nametxtbx.Enabled = true;
                    MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                }

            }
           
        }

       
        private void EditNameBtn_Click(object sender, EventArgs e)
        {
            editnameBtn.Visible = editnameBtn.Enabled = false;
            savenameBtn.Visible = savenameBtn.Enabled = true;
            nametxtbx.Enabled = true;
        }

        private void EditsurnameBtn_Click(object sender, EventArgs e)
        {
            editsurnameBtn.Visible = editsurnameBtn.Enabled = false;
            savesurnameBtn.Visible = savesurnameBtn.Enabled = true;
            surnametxtbx.Enabled = true;
        }

        private void SavesurnameBtn_Click(object sender, EventArgs e)
        {
            editsurnameBtn.Visible = editsurnameBtn.Enabled = true;
            savesurnameBtn.Visible = savesurnameBtn.Enabled = false;
            surnametxtbx.Enabled = false;
            if (!User.GetSurname().Equals(surnametxtbx.Text))
            {
                if (StringOkay(surnametxtbx.Text))
                {
                    string Query = $"UPDATE users SET surname ='{surnametxtbx.Text}' where login='{User.GetLogin()}'";

                    Database.SendWriteQuery(Query);
                    User.SetSurname(surnametxtbx.Text);
                    MessageBox.Show($"Имя пользователя было изменено на '{surnametxtbx.Text}'. Необхоимо заново пройти авторизацию.", "Успешно!");
                    User.LogOut();
                    Application.Restart();
                }
                else
                {
                    editsurnameBtn.Visible = editsurnameBtn.Enabled = false;
                    savesurnameBtn.Visible = savesurnameBtn.Enabled = true;
                    surnametxtbx.Enabled = true;
                    MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                }
            } 
        }

        private void FullResetBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вся информация из базы данных будет удалена", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string query = "DROP TABLE users;DROP TABLE questions;DROP TABLE results;DROP TABLE subjects";
                Database.SendWriteQuery(query);
                Database.CreateDb();
                Trainer.Properties.Settings.Default.Reset();
                Application.Restart();
            }
            
           
        }


        private void BtnCheckUpdates_Click(object sender, EventArgs e)
        {
            DialogResult Result = CheckUpdates();
            if (Result == DialogResult.Yes) {
                if (File.Exists("launcher.update")) { File.Delete("launcher.update"); }
                try {
                    var Client = new WebClient();
                    Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                    Client.DownloadFileAsync(new Uri(Trainer.Properties.Settings.Default.domain + "Train Social.exe"), "trainer.update");
                   
                } catch (Exception Exp) {
                    Console.WriteLine(Exp.Message);
                }
            }

        }
        public DialogResult CheckUpdates()
        {
            Version ThisVersion = Assembly.GetExecutingAssembly().GetName().Version;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Trainer.Properties.Settings.Default.domain + "version.xml");
                Version RemoteVersion = new Version(doc.GetElementsByTagName("myprogram")[0].InnerText);
                if (RemoteVersion > ThisVersion)
                {
                    return MessageBox.Show("Установить?", "Обнаружена новая версия", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("У вас установлена последняя версия", "Новая версия не обнаружена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return DialogResult.No;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return DialogResult.No;
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                progressBar1.Value = e.ProgressPercentage;
            }
            catch (Exception) { }
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Trainer.Properties.Settings.Default.domain + "version.xml");
                String Summ = doc.GetElementsByTagName("md5")[0].InnerText.ToString();
                if (!Checksumm("trainer.update", Summ))
                {
                    MessageBox.Show("Ошибка скачивания файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists("Trainer.bak")) {
                        File.Delete("Trainer.bak");
                    }
                    File.Move("Trainer.exe", "Trainer.bak");
                    File.Move("trainer.update", "Trainer.exe");
                    string query = $"UPDATE properties set version='{doc.GetElementsByTagName("myprogram")[0].InnerText}' WHERE id=1";
                    Database.SendReadQuery(query);
                    Application.Restart();
                }
     
            }
            catch (Exception) { }
        }

        private bool Checksumm(String filename, String summ)
        {
            using (FileStream fs = File.OpenRead(filename))
            {
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSumm = md5.ComputeHash(fileData);
                return BitConverter.ToString(checkSumm).Replace("-", String.Empty) == (summ).ToUpper();
            }
        }

    }
}
