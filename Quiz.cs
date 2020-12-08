using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using Trainer.Properties;

namespace TrainerSpace
{
    public partial class Quiz : Form
    {

        SystemMenuManager MenuManager;
        int Q = 1;
        int CountOfFull = 0;
        int NextNum;
        int Summe = 0;
        bool NoErrors = true;
        bool DontNeedsToBeChecked = true;
        int right, all;
        int multi = 0;
        int type;
        string[] Answers, MatchAnswers;
        string RightAnswers,WrongAnswers,WrongAnswersTag,FullAnswers,FullAnswersTag;
       
        int id;
        List<List<string>> result;
        List<TextBox> ListOfAnswersTb = new List<TextBox>();
        List<CheckBox> ListOfCheckersCb = new List<CheckBox>();
        List<RadioButton> ListOfRadiosRb = new List<RadioButton>();
        List<Label> ListOfMatchAnswersLabels = new List<Label>();
        List<Label> ListOfLabels = new List<Label>();
        PictureBox PictureFromFile = new PictureBox();

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        enum Type : int { Short = 0, Long, Match,Full,Image };

        public Quiz()
        {
            InitializeComponent();
            this.MenuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            WrongAnswers = "";

        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            string query = $"select * from questions where subject_id ={Trainer.Properties.Settings.Default.theme_id} order by id asc";
            result = Database.SendReadQuery(query);
            GetNextQuestion(0);
        }

        private void GetNextQuestion(int num)
        {

            if (result.Count > 0)
            {

                if (num < result.Count)
                {
                    id = Convert.ToInt32(result[num][0]);
                    //Если задание с кратким выбором ответа
                    if (result[num][4].Equals(((int)Type.Short).ToString()))
                    {
                        Random rnd = new Random();
                        int[] positions = new int[result[num][2].Length];
                        int[] normal_pos = new int[result[num][2].Length];
                        int[] tabs = new int[result[num][2].Length];
                        for (int i = 0; i < positions.Length; i++)
                        {

                            positions[i] = (panel1.Height) / result[num][2].Length * (i);
                            tabs[i] = 22 + i;
                        }
                        positions = Program.Randomize(positions);
                        tabs = Program.Randomize(tabs);

                        type = (int)Type.Short;

                        RightAnswers = result[num][2];
                        Answers = result[num][5].Split(';');
                        title.Text = result[num][1];
                        for (int i = 0; i < RightAnswers.Length; i++)
                        {
                            ListOfAnswersTb.Add(new TextBox() { Text = Answers[i], Location = new Point(10, positions[i]), Enabled = true,ReadOnly=true,BackColor=Color.White });
                            ListOfAnswersTb[i].Width = 650;

                            panel1.Controls.Add(ListOfAnswersTb[i]);
                        }

                        int summ = 0;
                        for (int i = 0; i < result[num][2].Length; i++)
                        {
                            summ += Convert.ToInt32(result[num][2][i].ToString());
                        }
                        //Если ответов больше одного
                        if (summ > 1)
                        {
                            for (int i = 0; i < RightAnswers.Length; i++)
                            {
                                CheckBox c = new CheckBox() { Checked = false, Location = new Point(665, positions[i]) };
                                c.CheckedChanged += (s, e) =>
                                {
                                    if (((CheckBox)s).Checked == true)
                                    {
                                        Summe++;
                                    }
                                    else { Summe--; }

                                };
                                ListOfCheckersCb.Add(c);
                                panel1.Controls.Add(ListOfCheckersCb[i]);
                            }
                            multi = 1;
                        }
                        else
                        {
                            for (int i = 0; i < RightAnswers.Length; i++)
                            {
                                RadioButton r = new RadioButton() { Checked = false, Location = new Point(665, positions[i]) };
                                r.CheckedChanged += (s, e) =>
                                {
                                    if (((RadioButton)s).Checked == true)
                                    {
                                        Summe++;
                                    }
                                    else { Summe--; }

                                };
                                ListOfRadiosRb.Add(r);
                                panel1.Controls.Add(ListOfRadiosRb[i]);
                            }
                            multi = 0;
                        }
                    }
                    //Задание с полным ответом
                    else if (result[num][4].Equals(((int)Type.Long).ToString()))
                    {
                        type = (int)Type.Long;
                        RightAnswers = result[num][2];

                        title.Text = result[num][1];
                        ListOfAnswersTb.Add(new TextBox() { Text = "", Location = new Point(10, 30) });
                        panel1.Controls.Add(ListOfAnswersTb[0]);
                        Answers = RightAnswers.Split(';');
                    }
                    // Задание на соответствие
                    else if (result[num][4].Equals(((int)Type.Match).ToString()))
                    {
                        Random rnd = new Random();
                        int[] positions = new int[result[num][2].Split(';').Length - 1];
                        int[] normal_pos = new int[result[num][2].Split(';').Length - 1];
                        int[] tabs = new int[result[num][2].Split(';').Length - 1];
                        for (int i = 0; i < positions.Length; i++)
                        {

                            positions[i] = panel1.Height / result[num][2].Split(';').Length * (i + 1);
                            normal_pos[i] = panel1.Height / result[num][2].Split(';').Length * (i + 1);
                            tabs[i] = 22 + i;
                        }
                        positions = Program.Randomize(positions);
                        tabs = Program.Randomize(tabs);
                        type = (int)Type.Match;
                        Answers = result[num][5].Split(';');
                        MatchAnswers = result[num][2].Split(';');
                        for (int i = 0; i < Answers.Length - 1; i++)
                        {

                            ListOfLabels.Add(new Label() { Text = (i + 1).ToString() + " " + Answers[i], Location = new Point(10, normal_pos[i]) });
                            ListOfMatchAnswersLabels.Add(new Label() { Text = MatchAnswers[i], Location = new Point(200, positions[i] + 15) });
                            ListOfAnswersTb.Add(new TextBox() { TabIndex = tabs[i], Location = new Point(300, positions[i] + 15) });
                            panel1.Controls.Add(ListOfLabels[i]);
                            panel1.Controls.Add(ListOfMatchAnswersLabels[i]);
                            panel1.Controls.Add(ListOfAnswersTb[i]);
                        }

                        title.Text = result[num][1];

                    }
                    //Полный
                    else if (result[num][4].Equals(((int)Type.Full).ToString()))
                    {
                        type = (int)Type.Full;
                        RightAnswers = result[num][2];

                        title.Text = result[num][1];
                        ListOfAnswersTb.Add(new TextBox() { Text = "", Location = new Point(10, 30) });
                        panel1.Controls.Add(ListOfAnswersTb[0]);

                    }
                    //Картинка
                    else if (result[num][4].Equals(((int)Type.Image).ToString()))
                    {
                        type = (int)Type.Long;
                        RightAnswers = result[num][2];
                        if (File.Exists(Directory.GetCurrentDirectory() + @"\images\" + result[num][6]))
                        {
                            PictureFromFile.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\images\" + result[num][6]);
                        }
                        else {
                            PictureFromFile.Image = Resources.EmptyPic;
                        }
                        PictureFromFile.Location = new Point(1,1);
                        PictureFromFile.Width = 400;
                        PictureFromFile.Height = 400;
                        PictureFromFile.SizeMode = PictureBoxSizeMode.Zoom;
                        title.Text = result[num][1];
                        ListOfAnswersTb.Add(new TextBox() { Text = "", Location = new Point(10, 410) });
                        panel1.Controls.Add(PictureFromFile);
                        panel1.Controls.Add(ListOfAnswersTb[0]);
                        Answers = RightAnswers.Split(';');
                    }
                }
                else
                {
                    double percentage = 0;
                    percentage = Math.Round((double)((double)right / (double)all) * 100);
                    if (DontNeedsToBeChecked)
                    {
                        MessageBox.Show("Это был последний вопрос! Ваш результат: правильно " + percentage + "%", "Результат");
                    }
                    else {
                        MessageBox.Show("Это был последний вопрос! Результаты будут доступны после проверки", "Результат");
                    }
                    string query = $"insert into results(right_a,count,user_id,subject_id,wrong,wrongtag,full,fulltag,checked,countoffull) " +
                        $"values({right},{all},{User.GetId()},{Trainer.Properties.Settings.Default.theme_id},'"+(WrongAnswers.Equals("")?"0":WrongAnswers)+$"','{WrongAnswersTag}','{FullAnswers}','{FullAnswersTag}',{DontNeedsToBeChecked},{CountOfFull})";
                    Database.SendWriteQuery(query);
                    this.Close();
                    Q--;
                }


            }
            NextNum = num + 1;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            string right_answers = "";
            if (type == (int)Type.Short)
            {
                if (Summe > 0)
                {
                    if (multi == 0)
                    {
                        for (int i = 0; i < ListOfRadiosRb.Count; i++)
                        {
                            right_answers += (ListOfRadiosRb[i].Checked ? "1" : "0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ListOfCheckersCb.Count; i++)
                        {
                            right_answers += (ListOfCheckersCb[i].Checked ? "1" : "0");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали ни одного ответа", "Ошибка");
                    NoErrors = false;
                }
            }
            else if ((type == (int)Type.Long) || (type == (int)Type.Image))
            {
                if (!ListOfAnswersTb[0].Text.Equals("") && Functions.StringOkay(ListOfAnswersTb[0].Text))
                {
                    for (int i = 0; i < Answers.Length - 1; i++)
                    {
                        if (Answers[i].ToLower().Equals(ListOfAnswersTb[0].Text.ToLower()))
                        {
                            right_answers = RightAnswers;
                            break;
                        }
                    }
                }
                else
                {
                    if(ListOfAnswersTb[0].Text.Equals(""))
                        MessageBox.Show("Поле не заполнено", "Ошибка");
                    if(!Functions.StringOkay(ListOfAnswersTb[0].Text))
                        MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                    NoErrors = false;
                }

            }
            else if (type == (int)Type.Match)
            {
                RightAnswers = "";
                for (int i = 0; i < ListOfAnswersTb.Count; i++)
                {
                    if (!ListOfAnswersTb[i].Text.Equals("") && Functions.StringOkay(ListOfAnswersTb[i].Text))
                    {
                        right_answers += ListOfAnswersTb[i].Text;
                        RightAnswers += (i + 1).ToString();
                    }
                    else
                    {
                        NoErrors = false;
                    }

                }
            }
            else if (type == (int)Type.Full)
            {
                if (!ListOfAnswersTb[0].Text.Equals("") && Functions.StringOkay(ListOfAnswersTb[0].Text))
                {
                    DontNeedsToBeChecked = false;
                    CountOfFull++;
                }
                else
                {
                    if (ListOfAnswersTb[0].Text.Equals(""))
                        MessageBox.Show("Поле не заполнено", "Ошибка");
                    if (!Functions.StringOkay(ListOfAnswersTb[0].Text))
                        MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                    NoErrors = false;
                }
            }
            
            if (NoErrors)
            {

                if (type==(int)Type.Full) {

                    string Query = $"INSERT INTO full_answers (question_id,user_answer,qnum) VALUES({id.ToString()},'{ListOfAnswersTb[0].Text}',{all+1})";
                    Database.SendWriteQuery(Query);
                    Query = "SELECT id FROM full_answers ORDER BY id DESC LIMIT 1;";
                    FullAnswers += (Database.SendReadQuery(Query))[0][0] + ";";
                    FullAnswersTag += all + 1 + ";";
                    all++;
                }
                else if (((RightAnswers == right_answers) && (!right_answers.Equals(""))) || ((type == (int)Type.Match) && (right_answers == RightAnswers)))
                {
                    right++;
                    all++;


                }
                else
                {
                    WrongAnswers += id.ToString() + ";";
                    WrongAnswersTag += all + 1 + ";";
                    all++;

                }

                Q++;
                ListOfRadiosRb.Clear();
                ListOfCheckersCb.Clear();
                ListOfMatchAnswersLabels.Clear();
                ListOfLabels.Clear();

                ListOfAnswersTb.Clear();
                panel1.Controls.Clear();
                GetNextQuestion(NextNum);
            }
            else if (type == (int)Type.Match) {
                MessageBox.Show("Одно из полей не заполнено или строка содержит недопустимые символы", "Ошибка");
            }
            NoErrors = true;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }


    }
}
