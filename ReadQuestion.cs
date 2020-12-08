using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TrainerSpace
{
    public partial class ReadQuestion : Form
    {
        enum Type : int { Short = 0, Long, Match,Full, Image };
        enum Checked : int {Unchecked = -1, Wrong, Right};
        List<List<string>> result;
        List<TextBox> Answers = new List<TextBox>();
        List<TextBox> MatchAnswers = new List<TextBox>();
        List<CheckBox> Checkers = new List<CheckBox>();
        string[] RightAnswers;
        string ShortAnswers;
        string[] StrAnswers;
        string UserFullAnswer;
        int isChecked;
        int type, CountOfAnswers;
        int QuestionIdOfFull;
        TextBox question1;
        string IdStr;
        int IdInFull;
        public ReadQuestion(string id,bool Full = false)
        {

            InitializeComponent();
            IdInFull = Convert.ToInt32(id);
            unCheckedRadio.Visible = false;
            WrongRadio.Visible = false;
            RightRadio.Visible = false;
            ConfirmBtn.Visible = false;
            CountOfAnswers = 0;
            IdStr = id;
            string query;
            if (!Full)
            {
                query = "SELECT * FROM questions WHERE id=" + id;
                result = Database.SendReadQuery(query);
                unCheckedRadio.Visible = false;
                WrongRadio.Visible = false;
                RightRadio.Visible = false;
                ConfirmBtn.Visible = false;
            }
            else {
                unCheckedRadio.Visible = true;
                WrongRadio.Visible = true;
                RightRadio.Visible = true;
                ConfirmBtn.Visible = true;
                query = "SELECT * FROM full_answers WHERE id=" + id;
                result = Database.SendReadQuery(query);
                query = "SELECT * FROM questions WHERE id=" + result[0][1];
                Console.WriteLine(query);
                QuestionIdOfFull = Convert.ToInt32(result[0][1]);
                UserFullAnswer = result[0][2];
                isChecked = Convert.ToInt32(result[0][4]);
                switch (isChecked) {
                    case (int)Checked.Unchecked: unCheckedRadio.Checked = true; break;
                    case (int)Checked.Wrong: WrongRadio.Checked = true; break;
                    case (int)Checked.Right: RightRadio.Checked = true; break;

                }
                result = Database.SendReadQuery(query);
            }

           

            StrAnswers = result[0][5].Split(';');

            question1 = new TextBox() { Enabled = false, Text = result[0][1] };
            question1.Width = 650;
            question1.Location = new Point(10, 15);
            this.Controls.Add(question1);
            type = Convert.ToInt32(result[0][4]);
            if (type == (int)Type.Short)
            {
                ShortAnswers = result[0][2];
                for (int i = 0; i < StrAnswers.Length - 1; i++)
                {
                    AddRow((int)Type.Short, StrAnswers[i], i, ShortAnswers[i]);

                }
            }
            else if (type == (int)Type.Long)
            {
                RightAnswers = result[0][2].Split(';');
                for (int i = 0; i < StrAnswers.Length - 1; i++)
                {
                    AddRow((int)Type.Long, StrAnswers[i], i, '1');

                }

            }
            else if (type == (int)Type.Full)
            {
                RightAnswers = result[0][2].Split(';');
                int i;
                for (i = 0; i < StrAnswers.Length - 1; i++)
                {
                    AddRow((int)Type.Long, "Подсказка для проверяющего: "+StrAnswers[i], i, '1');
                   

                }
                AddRow((int)Type.Long, "Ответ тестируемого: " + UserFullAnswer, i, '1');
            }
            else
            {
                RightAnswers = result[0][2].Split(';');
                for (int i = 0; i < StrAnswers.Length - 1; i++)
                {
                    AddRow((int)Type.Match, StrAnswers[i], i, '1', RightAnswers[i]);

                }

            }

        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            string query = $"UPDATE full_answers SET result = {isChecked} WHERE id = {IdInFull}";
            Database.SendWriteQuery(query);
            MessageBox.Show("Вы успешно оценили ответ", "OK");
        }

        private void unCheckedRadio_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = (int)Checked.Unchecked;
        }

        private void WrongRadio_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = (int)Checked.Wrong;
        }

        private void RightRadio_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = (int)Checked.Right;
        }

        private void AddRow(int type, string text, int i, char s_a, string r_a = "")
        {
            if (type == (int)Type.Short)
            {
                Answers.Add(new TextBox() {Enabled=false, Location = new Point(10, 20 + 25 * i - panel1.VerticalScroll.Value), Text = text, Width = 600 });
                Checkers.Add(new CheckBox() { Enabled = false, Location = new Point(610, 20 + 25 * i - panel1.VerticalScroll.Value), Checked = (s_a == '1' ? true : false) });
               
              
              
                panel1.Controls.Add(Answers[i]);
                panel1.Controls.Add(Checkers[i]);
                CountOfAnswers++;
            }
            else if (type == (int)Type.Long)
            {
                Answers.Add(new TextBox() { Enabled = false, Location = new Point(10, 20 + 25 * i - panel1.VerticalScroll.Value), Text = text, Width = 600 });
                panel1.Controls.Add(Answers[i]);
                         CountOfAnswers++;
            }
            else if (type == (int)Type.Match)
            {

                Answers.Add(new TextBox() { Enabled = false, Location = new Point(10, 20 + 25 * i - panel1.VerticalScroll.Value), Text = text, Width = 325 });
                MatchAnswers.Add(new TextBox() { Enabled = false, Location = new Point(335, 20 + 25 * i - panel1.VerticalScroll.Value), Text = r_a, Width = 325 });
                
               
                panel1.Controls.Add(Answers[i]);
                panel1.Controls.Add(MatchAnswers[i]);
                CountOfAnswers++;
            }
        }

    }
}
