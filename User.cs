using System;

namespace TrainerSpace
{
    class User
    {
        public static bool IsAdmin() {

            return Database.SendReadQuery("SELECT * FROM users WHERE id=" + GetId())[0][5].Equals("2");
        }

        public static bool IsModer()
        {
            return Database.SendReadQuery("SELECT * FROM users WHERE id=" + GetId())[0][5].Equals("1");
        }

    

        public static bool IsAuthed()
        {
            string query = $"select user_id from properties where id=1";
            return Convert.ToInt32(Database.SendReadQuery(query)[0][0])!=0;
        }

        public static int GetId() {
            string query = $"select user_id from properties where id=1";
           return Convert.ToInt32(Database.SendReadQuery(query)[0][0]);
        }

        public static void SetId(int id)
        {
            string query = $"update properties set user_id={id} where id=1";
            Database.SendWriteQuery(query);
        }

        public static string GetName()
        {
            string query = $"select name from properties where id=1";
            return Database.SendReadQuery(query)[0][0];
        }

        public static void SetName(string name)
        {
            string query = $"update properties set name='{name}' where id=1";
            Database.SendWriteQuery(query);
        }

        public static string GetSurname()
        {
            string query = $"select surname from properties where id=1";
            return Database.SendReadQuery(query)[0][0];
        }

        public static void SetSurname(string sname)
        {
            string query = $"update properties set surname='{sname}' where id=1";
            Database.SendWriteQuery(query);
        }

        public static string GetLogin()
        {
            string query = $"select login from properties where id=1";
            return Database.SendReadQuery(query)[0][0];
        }

        public static void SetLogin(string login)
        {
            string query = $"update properties set login='{login}' where id=1";
            Database.SendWriteQuery(query);
        }

        public static void LogOut() {
            string query = $"update properties set surname='',name='',user_id=0,login='' where id=1";
            Database.SendWriteQuery(query);
        }

    }
}
