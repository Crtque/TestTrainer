using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainerSpace
{
    public partial class Menu : Form
    {
        List<List<string>> ListOfComboBoxItems = new List<List<string>>();
        SystemMenuManager menuManager;
        List<List<string>> result = new List<List<string>>();
        public Menu()
        {
       
            InitializeComponent();
            ThemesCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            
            if (ListOfComboBoxItems.Count == 0)
            {
                ThemesCombo.Enabled = false;
            }

            lbUser.Text = $"Пользователь:{User.GetSurname()} {User.GetName()},\n ID: {User.GetId().ToString()}";
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed); //прячем крестик от юзера
            if (User.IsAdmin() || User.IsModer())
            {
                btnAdminpanel.Enabled = true;
                btnCheckstat.Enabled = btnCheckstat.Visible = false;
            }
            else
            {
                btnAdminpanel.Enabled = btnAdminpanel.Visible = false;
                btnCheckstat.Enabled = btnCheckstat.Visible = true;
            }

            
            string Query = "select * from subjects order by id asc";
            ListOfComboBoxItems = Database.SendReadQuery(Query);

            if (ListOfComboBoxItems.Count > 0)
            {
                ThemesCombo.Enabled = true;
                int i = 0;
                while (i < ListOfComboBoxItems.Count)
                {
                    ThemesCombo.Items.Add(ListOfComboBoxItems[i][1]);
                    i++;
                }
            }
        }

        private void btnAdminpanel_Click(object sender, EventArgs e)
        {
            Admin form = new Admin();
            
            if (!(form.ShowDialog() == DialogResult.OK))
            {
                string Query = "select * from subjects order by id asc";
                ListOfComboBoxItems = Database.SendReadQuery(Query);

                if (ListOfComboBoxItems.Count > 0)
                {
                    ThemesCombo.Enabled = true;
                    ThemesCombo.Items.Clear();
                    int i = 0;
                    while (i < ListOfComboBoxItems.Count)
                    {
                        ThemesCombo.Items.Add(ListOfComboBoxItems[i][1]);
                        i++;
                    }
                }
                else {
                    ThemesCombo.Items.Clear();
                    ThemesCombo.Enabled = false;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string query = $"select * from questions WHERE subject_id ='{Trainer.Properties.Settings.Default.theme_id}' order by id asc";
            result = Database.SendReadQuery(query);
         
            if (ThemesCombo.SelectedIndex == -1) {
                MessageBox.Show("Вы не выбрали предмет", "Ошибка!"); }
            else if (result.Count == 0) {
                MessageBox.Show("Не найдено вопросов по данной теме", "Ошибка!");
            }
            else
            {
                Quiz form = new Quiz();
                form.ShowDialog();
            }
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            User.LogOut();
            Application.Restart();
        }

        private void ThemesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trainer.Properties.Settings.Default.theme_id = Convert.ToInt32(ListOfComboBoxItems[ThemesCombo.SelectedIndex][0]);
            Trainer.Properties.Settings.Default.subject_sel = ThemesCombo.SelectedIndex;
            Trainer.Properties.Settings.Default.Save();
                        
        }

        private void btnCheckstat_Click(object sender, EventArgs e)
        {
            Results form = new Results();
            form.ShowDialog();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            Productinfo form = new Productinfo();
            form.ShowDialog();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Usettings form = new Usettings();
            form.Owner = this;
            form.ShowDialog();
        }

    }
}
