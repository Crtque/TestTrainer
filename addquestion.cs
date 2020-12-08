using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static TrainerSpace.Functions;

namespace TrainerSpace
{
    public partial class Addquestion : Form
    {
       List<EventHandler> EH = new List<EventHandler>();

        List<List<string>> RightAnswerComboBox = new List<List<string>>();
        List<TextBox> AnswerField = new List<TextBox>();
        List<TextBox> MatchAnsweField = new List<TextBox>();
        List<Button> DeleteButton = new List<Button>();
        Button BrowseImageButton = new Button();
        string FinalAnswerString;
        bool ErrorFlag;
        string ImagePath = "";
        bool CheckersSelected = false;
        List<CheckBox> RightAnswersChecker = new List<CheckBox>();
        int CountOfAnswers = 0;
        int MarginN = 25;
        enum AnswerType : int { Short = 0, Long, Match,Full,Image };
        enum ErrorType : int { EmptyTheme = 0, EmptyQuestion };

        SystemMenuManager MenuManager;
        int Type = (int)AnswerType.Short;
        string RightAnswers;

        public Addquestion()
        {
            InitializeComponent();
            SetShort();

            ThemeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.MenuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
        }

        private void NewQuestionBtn_Click(object sender, EventArgs e)
        {
            ErrorFlag = false;
            CheckersSelected = false;
            if ((CountOfAnswers > 1 && ((Type == (int)AnswerType.Short) || (Type == (int)AnswerType.Match))) || ((CountOfAnswers >= 1) && ((Type== (int)AnswerType.Long) || (Type == (int)AnswerType.Image))) || ((CountOfAnswers == 1) && Type == (int)AnswerType.Full))
            {
                if (Type == (int)AnswerType.Short)
                {
                    RightAnswers = FinalAnswerString = "";
                    for (int i = 0; i < CountOfAnswers; i++)
                    {
                        if (RightAnswersChecker[i].Visible)
                        {
                            if (RightAnswersChecker[i].Checked) CheckersSelected = true;
                            RightAnswers += (RightAnswersChecker[i].Checked ? "1" : "0");
                            FinalAnswerString += AnswerField[i].Text + ";";
                            if (AnswerField[i].Text.Equals(""))
                            {
                                ErrorFlag = true;
                                MessageBox.Show("Вы не заполнили один из ответов", "Ошибка");
                                break;

                            }
                            if (!StringOkay(AnswerField[i].Text))
                            {
                                ErrorFlag = true;
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                                break;
                            }
                        }
                    }
                }
                else if ((Type == (int)AnswerType.Long) || (Type == (int)AnswerType.Full) || (Type == (int)AnswerType.Image))
                {
                    RightAnswers = FinalAnswerString = "";
                    for (int i = 0; i < CountOfAnswers; i++)
                    {
                        if (AnswerField[i].Visible)
                        {
                            RightAnswers += AnswerField[i].Text + ";";
                            FinalAnswerString += AnswerField[i].Text + ";";
                            if (AnswerField[i].Text.Equals(""))
                            {
                                ErrorFlag = true;
                                MessageBox.Show("Вы не заполнили один из ответов", "Ошибка");
                                break;

                            }
                            if (!StringOkay(AnswerField[i].Text))
                            {
                                ErrorFlag = true;
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                                break;
                            }
                        }
                    }
                }
                else if (Type == (int)AnswerType.Match)
                {
                    RightAnswers = FinalAnswerString = "";
                    for (int i = 0; i < CountOfAnswers; i++)
                    {
                        if (AnswerField[i].Visible)
                        {
                            FinalAnswerString += AnswerField[i].Text + ";";
                            RightAnswers += MatchAnsweField[i].Text + ";";
                            if (AnswerField[i].Text.Equals("") || MatchAnsweField[i].Text.Equals(""))
                            {
                                ErrorFlag = true;
                                MessageBox.Show("Вы не заполнили один из ответов", "Ошибка");
                                break;

                            }
                            if (!StringOkay(AnswerField[i].Text) || !StringOkay(MatchAnsweField[i].Text))
                            {
                                ErrorFlag = true;
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                                break;
                            }
                        }
                    }
                }

                if (!tbQuestion.Text.Equals(""))
                {
                    if ((ErrorFlag != true) && (Type == (int)AnswerType.Short))
                    {
                        if (CheckersSelected == true)
                        {

                            if (ThemeComboBox.SelectedIndex == -1)
                            {
                                MessageBox.Show("Вы не выбрали тему", "Неудача!");
                            }
                            else
                            {
                                if (StringOkay(tbQuestion.Text))
                                {
                                    int Id = Convert.ToInt32(RightAnswerComboBox[ThemeComboBox.SelectedIndex][0]);
                                    string Query = $"insert into questions(title,answers,right_answers,subject_id,type)" +
                                        $" values('{tbQuestion.Text}','{FinalAnswerString}','{RightAnswers}',{(Id)},{Type})";
                                    Database.SendWriteQuery(Query);
                                    MessageBox.Show("Вы добавили новый вопрос", "Успешно!");
                                    tbQuestion.Text = "";
                                    SetShort();
                                }
                                else
                                {
                                    MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы не отметили ни одного правильного ответа", "Ошибка");
                        }
                    }
                    else if ((ErrorFlag != true) && ((Type == (int)AnswerType.Long) || (Type == (int)AnswerType.Full) || (Type == (int)AnswerType.Image)))
                    {
                        if (ThemeComboBox.SelectedIndex == -1)
                        {
                            MessageBox.Show("Вы не выбрали тему", "Неудача!");
                        }
                        else
                        {
                            if (StringOkay(tbQuestion.Text))
                            {
                                if (Type == (int)AnswerType.Image)
                                {
                                    if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\images\")) {
                                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\images\");
                                    }
                                    if (File.Exists(ImagePath))
                                    {
                                        int Last = (ImagePath.Split(@"\"[0])).Length;
                                        if (!File.Exists(@"images\" + (ImagePath.Split(@"\"[0]))[Last - 1]))
                                        {
                                            File.Copy(ImagePath, @"images\" + (ImagePath.Split(@"\"[0]))[Last - 1]);
                                            int id = Convert.ToInt32(RightAnswerComboBox[ThemeComboBox.SelectedIndex][0]);
                                            string query = $"insert into questions(title,answers,right_answers,subject_id,type,imagename)" +
                                                $" values('{tbQuestion.Text}','{FinalAnswerString}','{RightAnswers}',{(id)},{Type},'{(ImagePath.Split(@"\"[0]))[Last - 1]}')";
                                            Database.SendWriteQuery(query);
                                            MessageBox.Show("Вы добавили новый вопрос", "Успешно!");
                                            tbQuestion.Text = "";
                                            SetImage();

                                        }
                                        else
                                        {
                                            File.Copy(ImagePath, @"images\" + "(1)" + (ImagePath.Split(@"\"[0]))[Last - 1]);
                                            int id = Convert.ToInt32(RightAnswerComboBox[ThemeComboBox.SelectedIndex][0]);
                                            string query = $"insert into questions(title,answers,right_answers,subject_id,type,imagename)" +
                                                $" values('{tbQuestion.Text}','{FinalAnswerString}','{RightAnswers}',{(id)},{Type},'{"(1)" + (ImagePath.Split(@"\"[0]))[Last - 1] }')";
                                            Database.SendWriteQuery(query);
                                            MessageBox.Show("Вы добавили новый вопрос", "Успешно!");
                                            tbQuestion.Text = "";
                                            if (Type == (int)AnswerType.Image)
                                            {
                                                SetImage();
                                            }
                                            else
                                            {
                                                SetLong();
                                            }
                                        }


                                    }
                                    else
                                    {
                                        MessageBox.Show("Данное изображение не существует, либо вы забыли его выбрать", "Ошибка");
                                    }
                                }
                                else if (Type == (int)AnswerType.Long)
                                {
                                    int id = Convert.ToInt32(RightAnswerComboBox[ThemeComboBox.SelectedIndex][0]);
                                    string query = $"insert into questions(title,answers,right_answers,subject_id,type,imagename)" +
                                        $" values('{tbQuestion.Text}','{FinalAnswerString}','{RightAnswers}',{(id)},{Type},'')";
                                    Database.SendWriteQuery(query);
                                    MessageBox.Show("Вы добавили новый вопрос", "Успешно!");
                                    tbQuestion.Text = "";
                                    SetLong();
                                }
                                else {
                                    int id = Convert.ToInt32(RightAnswerComboBox[ThemeComboBox.SelectedIndex][0]);
                                    string query = $"insert into questions(title,answers,right_answers,subject_id,type,imagename)" +
                                        $" values('{tbQuestion.Text}','{FinalAnswerString}','{RightAnswers}',{(id)},{Type},'')";
                                    Database.SendWriteQuery(query);
                                    MessageBox.Show("Вы добавили новый вопрос", "Успешно!");
                                    tbQuestion.Text = "";
                                    SetFull();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                            }
                        }

                    }
                    else if (Type == (int)AnswerType.Match && (ErrorFlag != true))
                    {
                        if (ThemeComboBox.SelectedIndex == -1)
                        {
                            MessageBox.Show("Вы не выбрали тему", "Неудача!");
                        }
                        else
                        {
                            if (StringOkay(tbQuestion.Text))
                            {
                                int Id = Convert.ToInt32(RightAnswerComboBox[ThemeComboBox.SelectedIndex][0]);
                                string Query = $"insert into questions(title,answers,right_answers,subject_id,type)" +
                                    $" values('{tbQuestion.Text}','{FinalAnswerString}','{RightAnswers}',{(Id)},{Type})";
                                Database.SendWriteQuery(Query);
                                MessageBox.Show("Вы добавили новый вопрос", "Успешно!");
                                tbQuestion.Text = "";
                                SetMatch();
                            }
                            else
                            {
                                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
                            }
                        }
                    }
                }
                else { MessageBox.Show("Вы не указали название вопроса", "Ошибка"); }
            }
            else {
                MessageBox.Show("Неверное количество возможных ответов\nТребуется как минимум:\n2 для заданий с кратким ответом / соответствие\n1 для задания с полным ответом\n1 для задания с проверяемым ответом\nили задания с изображением", "Ошибка");
            }
        }


        private void Admin_Load(object sender, EventArgs e)
        {


            string Query = "select * from subjects order by id asc";
            RightAnswerComboBox = Database.SendReadQuery(Query);

            if (RightAnswerComboBox.Count > 0)
            {
                int i = 0;
                while (i < RightAnswerComboBox.Count)
                {
                    ThemeComboBox.Items.Add(RightAnswerComboBox[i][1]);
                    i++;
                }


            }


        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DeleteEvents();
            this.Close();
        }


        private void NewThemeBtn_Click(object sender, EventArgs e)
        {
            if (StringOkay(tbThemeName.Text))
            {
                string Query = $"insert into subjects(name) values('{tbThemeName.Text}')";
                Database.SendWriteQuery(Query);
                Query = "select  * from subjects order by id desc limit 0,1";
                List<List<string>> Result = Database.SendReadQuery(Query);
                RightAnswerComboBox.Add(new List<string>());
                RightAnswerComboBox[RightAnswerComboBox.Count - 1].Add(Result[0][0]);
                RightAnswerComboBox[RightAnswerComboBox.Count - 1].Add(Result[0][1]);
                tbThemeName.Text = "";
                ThemeComboBox.Items.Add(Result[0][1]);
                    ThemeComboBox.SelectedIndex = ThemeComboBox.Items.Count - 1;
                MessageBox.Show("Вы добавили новую тему. Данная тема выбрана в качестве редактируемой.", "Успешно!");
            }
            else
            {
                MessageBox.Show("Строка содержит недопустимые символы: / , ; ' \" ! или др.", "Ошибка");
            }
        }



        private void LongRadio_CheckedChanged(object sender, EventArgs e)
        {
            
            SetLong();
        }

        private void ShortRadio_CheckedChanged(object sender, EventArgs e)
        {
           
            SetShort();
        }

        private void MatchRadio_CheckedChanged(object sender, EventArgs e)
        {
           
            SetMatch();
        }

        private void FullRadio_CheckedChanged(object sender, EventArgs e)
        {
            SetFull();
        }

        private void ImageRadio_CheckedChanged(object sender, EventArgs e)
        {
            SetImage();
        }

        private void DeleteEvents() {
           
                for (int i = 0; i < CountOfAnswers; i++)
                {
                DeleteButton[i].Click -= EH[i];
                }
            BrowseImageButton.Click -= BrowseImageBtn_Click;
            EH.Clear();
          
        }
        private void SetShort()
        {
            DeleteEvents();
            CountOfAnswers = 0;
            Type = (int)AnswerType.Short;
            AnswerField.Clear();
            RightAnswersChecker.Clear();
            DeleteButton.Clear();
            ImagePath = "";
            panel1.Controls.Clear();
            panel1.Controls.Add(new Label() { Text = "Правильные ответы", Location = new Point(9, 11), AutoSize = true });
            AddRow();
            AddRow();

        }
        private void SetLong()
        {
            DeleteEvents();
            CountOfAnswers = 0;
            Type = (int)AnswerType.Long;
            AnswerField.Clear();
            DeleteButton.Clear();
            ImagePath = "";
            panel1.Controls.Clear();
            AddRow();

        }
        private void SetFull()
        {
            DeleteEvents();
            CountOfAnswers = 0;
            Type = (int)AnswerType.Full;
            AnswerField.Clear();
            DeleteButton.Clear();
            panel1.Controls.Clear();
            ImagePath = "";
            AddRow();

        }

        private void SetImage()
        {
            DeleteEvents();
            CountOfAnswers = 0;
            Type = (int)AnswerType.Image;
            AnswerField.Clear();
            DeleteButton.Clear();
            ImagePath = "";
            panel1.Controls.Clear();
            AddRow();

        }

        private void SetMatch()
        {
            DeleteEvents();
            CountOfAnswers = 0;
            DeleteButton.Clear();
            MatchAnsweField.Clear();
            AnswerField.Clear();
            Type = (int)AnswerType.Match;
            panel1.Controls.Clear();
            ImagePath = "";
            AddRow();
            AddRow();


        }

        private void NewRowLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((Type == (int)AnswerType.Full) && (CountOfAnswers == 1)) {
                MessageBox.Show("Для данного типа задания доступен только один ответ", "Ошибка");
            }
            else if (CountOfAnswers > 10) {
                MessageBox.Show("Слишком много ответов","Ошибка");
            }
            else {
                AddRow();
            }
            
        }

        private void AddRow()
        {
            int AnswerFieldWidth = 270;
            int AnswerFieldHeight = 20;
            int AnswerFieldX = 139;
            int AnswerFieldYGap = 40;
            int RightAnswerCheckerX = 53;
            int DeleteAnswerButtonX = 415;
            if (Type == (int)AnswerType.Short)
            {
                AnswerField.Add(new TextBox());
                AnswerField[CountOfAnswers].Location = new Point(AnswerFieldX, AnswerFieldYGap + CountOfAnswers * MarginN - panel1.VerticalScroll.Value);
                AnswerField[CountOfAnswers].Width = AnswerFieldWidth;
                AnswerField[CountOfAnswers].Height = AnswerFieldHeight;

                RightAnswersChecker.Add(new CheckBox());
                RightAnswersChecker[CountOfAnswers].Location = new Point(RightAnswerCheckerX, AnswerFieldYGap + CountOfAnswers * MarginN - panel1.VerticalScroll.Value);

                DeleteButton.Add(new Button());
                DeleteButton[CountOfAnswers].Location = new Point(DeleteAnswerButtonX, AnswerFieldYGap + CountOfAnswers * MarginN - panel1.VerticalScroll.Value);
                DeleteButton[CountOfAnswers].Text = "Удалить";
                DeleteButton[CountOfAnswers].Tag = CountOfAnswers;

                EH.Add((s, e) =>
                {
                    int tag = Convert.ToInt32(((Button)s).Tag);
                    AnswerField[tag].Visible = false;
                    DeleteButton[tag].Visible = false;
                    RightAnswersChecker[tag].Visible = false;

                    for (int i = tag + 1; i < CountOfAnswers; i++)
                    {
                        AnswerField[i].Location = new Point(AnswerField[i].Location.X, AnswerField[i].Location.Y - MarginN);
                        DeleteButton[i].Location = new Point(DeleteButton[i].Location.X, DeleteButton[i].Location.Y - MarginN);
                        DeleteButton[i].Tag = Convert.ToInt32(DeleteButton[i].Tag) - 1;
                        RightAnswersChecker[i].Location = new Point(RightAnswersChecker[i].Location.X, RightAnswersChecker[i].Location.Y - MarginN);
                    }
                    AnswerField.RemoveAt(tag);
                    RightAnswersChecker.RemoveAt(tag);
                    DeleteButton.RemoveAt(tag);
                    CountOfAnswers--;
                });
                DeleteButton[CountOfAnswers].Click += EH[CountOfAnswers];

                this.panel1.Controls.Add(AnswerField[CountOfAnswers]);
                this.panel1.Controls.Add(RightAnswersChecker[CountOfAnswers]);
                this.panel1.Controls.Add(DeleteButton[CountOfAnswers]);
                CountOfAnswers++;
            }
            else if (Type == (int)AnswerType.Match)
            {
                int AnswerFieldWidthWithGap = 275;
                int FirstXPos = 50;
                AnswerField.Add(new TextBox());
                MatchAnsweField.Add(new TextBox());
                AnswerField[CountOfAnswers].Location = new Point(FirstXPos, AnswerFieldYGap + CountOfAnswers * MarginN - panel1.VerticalScroll.Value);
                AnswerField[CountOfAnswers].Width = MatchAnsweField[CountOfAnswers].Width = AnswerFieldWidth;
                AnswerField[CountOfAnswers].Height = MatchAnsweField[CountOfAnswers].Height = AnswerFieldHeight;
                MatchAnsweField[CountOfAnswers].Location = new Point(FirstXPos + AnswerFieldWidthWithGap, AnswerFieldYGap + CountOfAnswers * MarginN - panel1.VerticalScroll.Value);
                DeleteButton.Add(new Button());
                DeleteButton[CountOfAnswers].Location = new Point(FirstXPos + 2 * AnswerFieldWidthWithGap, AnswerFieldYGap + CountOfAnswers * MarginN - panel1.VerticalScroll.Value);
                DeleteButton[CountOfAnswers].Text = "Удалить";
                DeleteButton[CountOfAnswers].Tag = CountOfAnswers;

                EH.Add((s, e) =>
                {
                    int DeleteBtnTag = Convert.ToInt32(((Button)s).Tag);
                    AnswerField[DeleteBtnTag].Visible = false;
                    DeleteButton[DeleteBtnTag].Visible = false;
                    MatchAnsweField[DeleteBtnTag].Visible = false;

                    for (int i = DeleteBtnTag + 1; i < CountOfAnswers; i++)
                    {
                        AnswerField[i].Location = new Point(AnswerField[i].Location.X, AnswerField[i].Location.Y - MarginN);
                        MatchAnsweField[i].Location = new Point(MatchAnsweField[i].Location.X, MatchAnsweField[i].Location.Y - MarginN);
                        DeleteButton[i].Location = new Point(DeleteButton[i].Location.X, DeleteButton[i].Location.Y - MarginN);
                        DeleteButton[i].Tag = Convert.ToInt32(DeleteButton[i].Tag) - 1;

                    }
                    AnswerField.RemoveAt(DeleteBtnTag);
                    MatchAnsweField.RemoveAt(DeleteBtnTag);
                    DeleteButton.RemoveAt(DeleteBtnTag);
                    CountOfAnswers--;
                });
                DeleteButton[CountOfAnswers].Click += EH[CountOfAnswers];

                this.panel1.Controls.Add(DeleteButton[CountOfAnswers]);
                this.panel1.Controls.Add(AnswerField[CountOfAnswers]);
                this.panel1.Controls.Add(MatchAnsweField[CountOfAnswers]);
                CountOfAnswers++;

            }
            else if ((Type == (int)AnswerType.Long) || (Type == (int)AnswerType.Full) || (Type == (int)AnswerType.Image))
            {
                if (Type == (int)AnswerType.Image) {
                    BrowseImageButton.Location = new Point(1, 30);
                    BrowseImageButton.Width = 100;
                    BrowseImageButton.Height = 40;
                    BrowseImageButton.Text = "Выбрать картинку";
                    BrowseImageButton.Click += BrowseImageBtn_Click;
                    this.panel1.Controls.Add(BrowseImageButton);
                }
                AnswerField.Add(new TextBox());
                AnswerField[CountOfAnswers].Location = new Point(AnswerFieldX, AnswerFieldYGap + CountOfAnswers * 25 - panel1.VerticalScroll.Value);
                AnswerField[CountOfAnswers].Width = AnswerFieldWidth;
                AnswerField[CountOfAnswers].Height = AnswerFieldHeight;

                DeleteButton.Add(new Button());
                DeleteButton[CountOfAnswers].Location = new Point(DeleteAnswerButtonX, AnswerFieldYGap + CountOfAnswers * MarginN - panel1.VerticalScroll.Value);
                DeleteButton[CountOfAnswers].Text = "Удалить";
                DeleteButton[CountOfAnswers].Tag = CountOfAnswers;
                EH.Add((s, e) =>
                {
                    int DeleteBtnTag = Convert.ToInt32(((Button)s).Tag);
                    AnswerField[DeleteBtnTag].Visible = false;
                    DeleteButton[DeleteBtnTag].Visible = false;


                    for (int i = DeleteBtnTag + 1; i < CountOfAnswers; i++)
                    {
                        AnswerField[i].Location = new Point(AnswerField[i].Location.X, AnswerField[i].Location.Y - MarginN);
                        DeleteButton[i].Location = new Point(DeleteButton[i].Location.X, DeleteButton[i].Location.Y - MarginN);
                        DeleteButton[i].Tag = Convert.ToInt32(DeleteButton[i].Tag) - 1;
                    }
                    AnswerField.RemoveAt(DeleteBtnTag);
                    DeleteButton.RemoveAt(DeleteBtnTag);
                    CountOfAnswers--;
                });
                DeleteButton[CountOfAnswers].Click += EH[CountOfAnswers];
                
                this.panel1.Controls.Add(DeleteButton[CountOfAnswers]);
                this.panel1.Controls.Add(AnswerField[CountOfAnswers]);
                CountOfAnswers++;

            }
        }

        private void BrowseImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            // chose the images type
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                ImagePath = opf.FileName;
            }
        }
    }
}
