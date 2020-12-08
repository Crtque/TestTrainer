using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TrainerSpace
{
    public partial class QuestionInfo : Form
    {
        enum Type : int { Short = 0, Long, Match };
        List<List<string>> result;
        List<EventHandler> EH = new List<EventHandler>();
        List<TextBox> Answers = new List<TextBox>();
        List<TextBox> MatchAnswers = new List<TextBox>();
        List<Button> DeleteButtons = new List<Button>();
        List<CheckBox> Checkers = new List<CheckBox>();
        string[] RightAnswers;
        string ShortAnswers, CheckedAnswers;
        string[] StrAnswers;
        int MarginN = 25;
        int type, CountOfAnswers;
        TextBox question1;
        string IdStr;
        bool EmptyField = false;
        bool EmptyCheckers = false;
        bool BadWord = false;
        public QuestionInfo(string id)
        {

            InitializeComponent();
            CountOfAnswers = 0;
            IdStr = id;
            string query = "SELECT * FROM questions WHERE id=" + id;
            result = Database.SendReadQuery(query);

            StrAnswers = result[0][5].Split(';');

            question1 = new TextBox() { Text = result[0][1] };
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
            else
            {
                RightAnswers = result[0][2].Split(';');
                for (int i = 0; i < StrAnswers.Length - 1; i++)
                {
                    AddRow((int)Type.Match, StrAnswers[i], i, '1', RightAnswers[i]);

                }

            }

        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DeleteEvents();
            this.Close();
        }

        private void DeleteEvents()
        {

            for (int i = 0; i < CountOfAnswers; i++)
            {
                DeleteButtons[i].Click -= EH[i];
            }
            EH.Clear();

        }

        private void AddRowLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AddRow(type, "", CountOfAnswers, '0');
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            EmptyField = false;
            EmptyCheckers = true;
            BadWord = false;
            if (!question1.Text.Equals("") && Functions.StringOkay(question1.Text))
            {
                if (type == (int)Type.Short)
                {
                    if (CountOfAnswers > 1)
                    {
                        ShortAnswers = CheckedAnswers = "";
                        for (int i = 0; i < Answers.Count; i++)
                        {

                            if (Answers[i].Text.Equals(""))
                            {
                                EmptyField = true;
                                break;
                            }
                            if (Checkers[i].Checked)
                            {
                                EmptyCheckers = false;
                            }
                            if (!Functions.StringOkay(Answers[i].Text))
                            {
                                BadWord = true;
                                break;
                            }

                            ShortAnswers += Answers[i].Text + ";";
                            CheckedAnswers += (Checkers[i].Checked ? "1" : "0");
                        }
                        if (EmptyField == false && EmptyCheckers == false && BadWord == false)
                        {
                            string query = $"UPDATE questions SET title='{question1.Text}' ,right_answers='{CheckedAnswers}'," +
                                $"answers='{ShortAnswers}' WHERE id =" + IdStr;
                            Database.SendWriteQuery(query);
                            MessageBox.Show("Вы обновили вопрос", "Успешно!");
                        }
                        else
                        {
                            if (EmptyField)
                            {
                                MessageBox.Show("Вы не заполнили одно из полей", "Ошибка!");
                            }
                            if (EmptyCheckers)
                            {
                                MessageBox.Show("Вы не выбрали ни одного правильного ответа", "Ошибка!");
                            }
                            if (BadWord)
                            {
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ответов должно быть как минимум 2", "Ошибка!");
                    }
                }
                else if (type == (int)Type.Long)
                {
                    if (CountOfAnswers > 0)
                    {
                        ShortAnswers = "";
                        for (int i = 0; i < Answers.Count; i++)
                        {
                            if (Answers[i].Text.Equals(""))
                            {
                                EmptyField = true;
                            }
                            if (!Functions.StringOkay(Answers[i].Text))
                            {
                                BadWord = true;
                                break;
                            }
                            ShortAnswers += Answers[i].Text + ";";
                        }
                        if (!EmptyField && !BadWord)
                        {
                            string query = $"UPDATE questions SET title='{question1.Text}' ,right_answers='{CheckedAnswers}'," +
                                $"answers='{ShortAnswers}' WHERE id =" + IdStr;
                            Database.SendWriteQuery(query);
                            MessageBox.Show("Вы обновили вопрос", "Успешно!");
                        }
                        else
                        {
                            if (BadWord)
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                            if (EmptyField)
                                MessageBox.Show("Одно из полей не заполнено", "Ошибка!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ответ должен быть как минимум 1", "Ошибка!");
                    }
                }
                else
                {
                    if (CountOfAnswers > 1)
                    {
                        ShortAnswers = CheckedAnswers = "";
                        for (int i = 0; i < Answers.Count; i++)
                        {
                            if (Answers[i].Text.Equals("") || MatchAnswers[i].Text.Equals(""))
                            {
                                EmptyField = true;
                            }
                            if (!Functions.StringOkay(Answers[i].Text) || !Functions.StringOkay(MatchAnswers[i].Text))
                            {
                                BadWord = true;
                                break;
                            }
                            ShortAnswers += Answers[i].Text + ";";
                            CheckedAnswers += MatchAnswers[i].Text + ";";
                        }
                        if (!EmptyField && !BadWord)
                        {
                            string query = $"UPDATE questions SET title='{question1.Text}' ,right_answers='{ CheckedAnswers} '," +
                                $"answers='{ShortAnswers}' WHERE id =" + IdStr;
                            Database.SendWriteQuery(query);
                            MessageBox.Show("Вы обновили вопрос", "Успешно!");
                        }
                        else
                        {
                            if (EmptyField)
                                MessageBox.Show("Одно из полей не заполнено", "Ошибка");
                            if (BadWord)
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");

                        }
                    }
                    else {
                        MessageBox.Show("Ответов должно быть как минимум 2", "Ошибка!");

                    }
                }
            }
            else
            {
                if (question1.Text.Equals(""))
                    MessageBox.Show("Вы не заполнили поле вопроса", "Ошибка!");
                if (!Functions.StringOkay(question1.Text))
                    MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
            }
        }

        private void AddRow(int type, string text, int i, char IsAnswerShouldBeRight, string MatchedAnswer = "")
        {
            if (type == (int)Type.Short)
            {
                Answers.Add(new TextBox() { Location = new Point(10, 20 + 25 * i - panel1.VerticalScroll.Value), Text = text, Width = 600 });
                Checkers.Add(new CheckBox() { Location = new Point(610, 20 + 25 * i - panel1.VerticalScroll.Value), Checked = (IsAnswerShouldBeRight == '1' ? true : false) });
                DeleteButtons.Add(new Button() { Location = new Point(625, 20 + 25 * i - panel1.VerticalScroll.Value), Tag = i, Text = "Удалить" });
                EH.Add((s, e) =>
                {
                    DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить вопрос?", "Удаление вопроса", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int tag = Convert.ToInt32(((Button)s).Tag);
                        Answers[tag].Visible = false;
                        DeleteButtons[tag].Visible = false;
                        Checkers[tag].Visible = false;

                        for (int j = tag + 1; j < CountOfAnswers; j++)
                        {
                            Answers[j].Location = new Point(Answers[j].Location.X, Answers[j].Location.Y - MarginN);
                            DeleteButtons[j].Location = new Point(DeleteButtons[j].Location.X, DeleteButtons[j].Location.Y - MarginN);
                            DeleteButtons[j].Tag = Convert.ToInt32(DeleteButtons[j].Tag) - 1;
                            Checkers[j].Location = new Point(Checkers[j].Location.X, Checkers[j].Location.Y - MarginN);
                        }
                        Answers.RemoveAt(tag);
                        Checkers.RemoveAt(tag);
                        
                        DeleteButtons.RemoveAt(tag);
                        CountOfAnswers--;
                        ((Button)s).Click -= EH[i];
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }

                });
                DeleteButtons[i].Click += EH[i];
                panel1.Controls.Add(DeleteButtons[i]);
                panel1.Controls.Add(Answers[i]);
                panel1.Controls.Add(Checkers[i]);
                CountOfAnswers++;
            }
            else if (type == (int)Type.Long)
            {
                Answers.Add(new TextBox() { Location = new Point(10, 20 + 25 * i - panel1.VerticalScroll.Value), Text = text, Width = 600 });
                DeleteButtons.Add(new Button() { Location = new Point(625, 20 + 25 * i - panel1.VerticalScroll.Value), Tag = i, Text = "Удалить" });
                EH.Add((s, e) =>
                {
                    int tag = Convert.ToInt32(((Button)s).Tag);
                    Answers[tag].Visible = false;
                    DeleteButtons[tag].Visible = false;

                    for (int j = tag + 1; j < CountOfAnswers; j++)
                    {
                        Answers[j].Location = new Point(Answers[j].Location.X, Answers[j].Location.Y - MarginN);
                        DeleteButtons[j].Location = new Point(DeleteButtons[j].Location.X, DeleteButtons[j].Location.Y - MarginN);
                        DeleteButtons[j].Tag = Convert.ToInt32(DeleteButtons[j].Tag) - 1;

                    }
                    Answers.RemoveAt(tag);
                    
                    DeleteButtons.RemoveAt(tag);
                    CountOfAnswers--;
                    ((Button)s).Click -= EH[i];
                });
                DeleteButtons[i].Click += EH[i];
                panel1.Controls.Add(DeleteButtons[i]);
                panel1.Controls.Add(Answers[i]);
                CountOfAnswers++;
            }
            else if (type == (int)Type.Match)
            {

                Answers.Add(new TextBox() { Location = new Point(10, 20 + 25 * i - panel1.VerticalScroll.Value), Text = text, Width = 325 });
                MatchAnswers.Add(new TextBox() { Location = new Point(335, 20 + 25 * i - panel1.VerticalScroll.Value), Text = MatchedAnswer, Width = 325 });
                DeleteButtons.Add(new Button() { Location = new Point(675, 20 + 25 * i - panel1.VerticalScroll.Value), Tag = i, Text = "Удалить" });
                EH.Add((s, e) =>
                {
                    int tag = Convert.ToInt32(((Button)s).Tag);
                    Answers[tag].Visible = false;
                    DeleteButtons[tag].Visible = false;
                    MatchAnswers[tag].Visible = false;

                    for (int j = tag + 1; j < CountOfAnswers; j++)
                    {
                        Answers[j].Location = new Point(Answers[j].Location.X, Answers[j].Location.Y - MarginN);
                        MatchAnswers[j].Location = new Point(MatchAnswers[j].Location.X, MatchAnswers[j].Location.Y - MarginN);
                        DeleteButtons[j].Location = new Point(DeleteButtons[j].Location.X, DeleteButtons[j].Location.Y - MarginN);
                        DeleteButtons[j].Tag = Convert.ToInt32(DeleteButtons[j].Tag) - 1;

                    }
                    Answers.RemoveAt(tag);
                    MatchAnswers.RemoveAt(tag);
                    DeleteButtons.RemoveAt(tag);
                    CountOfAnswers--;
                    ((Button)s).Click -= EH[i];
                });

                DeleteButtons[i].Click += EH[i];
                panel1.Controls.Add(DeleteButtons[i]);
                panel1.Controls.Add(Answers[i]);
                panel1.Controls.Add(MatchAnswers[i]);
                CountOfAnswers++;
            }
        }

    }
}
