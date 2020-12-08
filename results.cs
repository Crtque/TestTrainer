using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TrainerSpace
{
    public partial class Results : Form
    {
        int Mark;
        double Percentage;
        double UpperPerc = 80;
        double AvgPerc = 60;
        double LowerPerc = 40;
        int RightOfFull = 0;
        SystemMenuManager MenuManager;
        int LowerBracket, UpperBracket;
        int NumberOfRecordsInResults;
        public Results()
        {

            InitializeComponent();
            LowerBracket = 0;
            UpperBracket = 4;
            GetList();
            NumberOfRecordsInResults = Count();
        }
        private int Count()
        {
            string countquery = "SELECT COUNT(*) FROM results";
            List<List<string>> count_result;
            count_result = Database.SendReadQuery(countquery);

            return Convert.ToInt32(count_result[0][0]);

        }
        private void BackBtn_Click(object sender, EventArgs e)
        {

            this.Close();

        }
        private void GetList(int lower = 0, int upper = 5)
        {

            this.MenuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            string query;
            if (User.IsAdmin() || User.IsModer())
            {
               query = $"select * from results inner join subjects on results.subject_id =" +
                    $" subjects.id inner join users on results.user_id = users.id order by results.id desc  LIMIT " + lower + "," + upper;
            }
            else{
                query = $"select * from results  inner join subjects on results.subject_id =" +
                    $" subjects.id inner join users on results.user_id = users.id where user_id={User.GetId()} and checked=1 order by results.id desc  LIMIT " + lower + "," + upper;
            }
            List<List<string>> result = Database.SendReadQuery(query);
            LowerBracket = lower;
            UpperBracket = upper;
            if (result.Count > 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    ListBox listbox = this.Controls.Find("listBox" + (i + 1).ToString(), true).FirstOrDefault() as ListBox;
                    Panel panel = this.Controls.Find("panel" + (i + 1).ToString(), true).FirstOrDefault() as Panel;
                    Panel panel1 = this.Controls.Find("FullPanel" + (i + 1).ToString(), true).FirstOrDefault() as Panel;
                    panel.Width = 142;
                    panel.Height = 178;
                    panel.Controls.Clear();
                    panel1.Controls.Clear();
                    listbox.Items.Clear();
                }
                for (int i = 0; i < (result.Count > 5 ? 5 : result.Count); i++)
                {
                    Panel panel = this.Controls.Find("panel" + (i + 1).ToString(), true).FirstOrDefault() as Panel;
                    Panel panel1 = this.Controls.Find("FullPanel" + (i + 1).ToString(), true).FirstOrDefault() as Panel;
                    ListBox listbox = this.Controls.Find("listBox" + (i + 1).ToString(), true).FirstOrDefault() as ListBox;
                    listbox.Items.Add("Тест: " + result[i][13]);
                    listbox.Items.Add("Имя: " + result[i][15]);
                    listbox.Items.Add("Фамилия: " + result[i][16]);

                    string[] w_a = result[i][6].Split(';');
                    string[] w_a_tag = result[i][7].Split(';');
                    string[] full_a = result[i][8].Split(';');
                    string[] full_a_tag = result[i][9].Split(';');
                    if (!w_a[0].Equals("0"))
                    {
                        panel.Controls.Add(new Label() { Text = "Неправильные ответы", AutoSize = true });
                        for (int j = 0; j < w_a.Length - 1; j++)
                        {

                            int x = panel.Location.X;
                            int y = panel.Location.Y;
                            LinkLabel linkLabel = new LinkLabel();
                            linkLabel.Tag = w_a[j];
                            linkLabel.Click += (s, e) =>
                            {
                                ReadQuestion form = new ReadQuestion(((LinkLabel)s).Tag.ToString());
                                form.ShowDialog();
                            };
                            linkLabel.Text = w_a_tag[j];
                            linkLabel.Location = new System.Drawing.Point(12, ((j + 1) * 25));
                            panel.Controls.Add(linkLabel);
                        }
                    }

                    if (!full_a[0].Equals(""))
                    {
                        string Query = $"Select COUNT(*) FROM full_answers WHERE result_id = {result[0][0]} AND result = 1";
                        RightOfFull = Convert.ToInt32((Database.SendReadQuery(Query))[0][0]);
                        if (User.IsAdmin()) { panel1.Controls.Add(new Label() { Text = "Ответы c проверкой", AutoSize = true }); }
                        for (int j = 0; j < full_a.Length - 1; j++)
                        {

                            int x = panel1.Location.X;
                            int y = panel1.Location.Y;
                            LinkLabel linkLabel = new LinkLabel();
                            linkLabel.Tag = full_a[j];
                            string SelectQuery = $"SELECT result FROM full_answers WHERE id={full_a[j]}";
                            int FullAnswMark = Convert.ToInt32((Database.SendReadQuery(SelectQuery))[0][0]);

                            string UpdateQuery = $"UPDATE full_answers SET result_id = {result[i][0]} WHERE id={full_a[j]}";
                            Database.SendWriteQuery(UpdateQuery);
                            linkLabel.Click += (s, e) =>
                            {
                                ReadQuestion form = new ReadQuestion(((LinkLabel)s).Tag.ToString(), true);
                                if (!(form.ShowDialog() == DialogResult.OK))
                                {
                                    GetList(lower, upper);
                                }
                            };
                            linkLabel.Text = full_a_tag[j] + (FullAnswMark > -1 ? " (Проверен)":" (Не проверен)");
                            linkLabel.Location = new System.Drawing.Point(12, ((j + 1) * 25));
                            if (User.IsAdmin()) { panel1.Controls.Add(linkLabel); }
                        }
                    }
                    Percentage = Math.Round((((Convert.ToInt32(result[i][1]) + RightOfFull) / Convert.ToDouble(result[i][2])) * 100));
                    if (Percentage > UpperPerc) { Mark = 5; }
                    else if (Percentage > AvgPerc) { Mark = 4; }
                    else if (Percentage > LowerPerc) { Mark = 3; }
                    else { Mark = 2; }
                    listbox.Items.Add("Кол-во правильных: " + (Convert.ToInt32(result[i][1]) + RightOfFull));
                    listbox.Items.Add("Общее кол-во: " + result[i][2]);
                    listbox.Items.Add(!Convert.ToBoolean(result[i][10]) ? "Не проверено" : "Проверено");
                    listbox.Items.Add(!Convert.ToBoolean(result[i][10]) ? "Предв. оценка: " + Mark.ToString() : "Оценка: " + Mark.ToString());
                }
            }
            else {
                MessageBox.Show("Не найдено ни одного результата, возможно ваш тест еще не проверен.","Ошибка");
            }
            if (lower - 5 < 0)
            {
                PrevBtn.Enabled = false;
            }
            else
            {
                PrevBtn.Enabled = true;
            }
            if (Count() > upper)
            {
                NextBtn.Enabled = true;
            }
            else
            {
                NextBtn.Enabled = false;
            }

        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            GetList(LowerBracket + 5, UpperBracket + 5);
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {

            GetList(LowerBracket - 5, UpperBracket - 5);
        }

    }
}
