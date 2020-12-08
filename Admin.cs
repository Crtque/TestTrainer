using System;
using System.Windows.Forms;

namespace TrainerSpace
{
    public partial class Admin : Form
    {
        SystemMenuManager MenuManager;
        public Admin()
        {
            InitializeComponent();
            this.MenuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            
        }


        private void AddQuestionBtn_Click(object sender, EventArgs e)
        {
            Addquestion form = new Addquestion();
            form.ShowDialog();
            
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ResultsBtn_Click(object sender, EventArgs e)
        {
            Results form = new Results();
            form.ShowDialog();
           
        }

        private void EditQuestionBtn_Click(object sender, EventArgs e)
        {
            Editquestion form = new Editquestion();
            form.Owner = this;
            form.ShowDialog();
            
        }

        private void AddThemeBtn_Click(object sender, EventArgs e)
        {
            Editheme form = new Editheme();
            form.ShowDialog();
           
        }

        private void AddAdminBtn_Click(object sender, EventArgs e)
        {
            Editadmin form = new Editadmin();
            form.ShowDialog();

        }
    }
}
