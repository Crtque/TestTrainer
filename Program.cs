using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TrainerSpace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       

        [STAThread]
        static void Main()
        {
            List<List<string>> result;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Database.Exists())
            {
                Database.CreateDb();
            }
            string query = "select * from users WHERE login = 'admin'";
            result = Database.SendReadQuery(query);
            if (result.Count == 0)
            {
                Application.Run(new First());
            }
            else
            {
                if (User.IsAuthed())
                {
                    Application.Run(new Menu());
                }
                else
                {
                    Application.Run(new Auth());
                }
            }
            
        }

       
        public static int[] Randomize(int[] input)
        {
            int[] result = input;
            int buffer;
            int i = result.Length;
            int j;
            Random rnd = new Random();
            while (i > 1)
            {
                i--;
                j = rnd.Next(0, i);  // 0 <= j <= i-1
                buffer = result[j];
                result[j] = result[i];
                result[i] = buffer;

            }
            return result;
        }

    }
}
