using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace TrainerSpace
{
    class Database
    {
        static SQLiteConnection Connect = new SQLiteConnection(GetCurrentConnectionString());
        static SQLiteCommand Command = new SQLiteCommand(Connect);
        static SQLiteDataReader DataReader;


        public static void SendWriteQuery(string query)
        {
            try { 
                Connect.Open();
                Command.Connection = Connect;
                Command.CommandText = query;
                Command.ExecuteNonQuery();
                Connect.Close();
            }
            catch (SQLiteException ex){
                throw new Exception(ex.Message);
            }
}

        public static List<List<string>> SendReadQuery(string query)
        {
            List<List<string>> Result = new List<List<string>>();
            try
            {
                Connect.Open();
                Command.Connection = Connect;
                Command.CommandText = query;
                DataReader = Command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    int i = 0;
                    while (DataReader.Read())
                    {
                        Result.Add(new List<string>());
                        for (int j = 0; j < DataReader.FieldCount; j++)
                        {
                            Result[i].Add(DataReader[j].ToString());
                        }
                        i++;
                    }
                }
                DataReader.Close();
                Connect.Close();
            }
            catch (SQLiteException ex){
                throw new Exception(ex.Message);
            }
            return Result;
        }

        public static string GetCurrentConnectionString()
        {
            var Process = System.Diagnostics.Process.GetCurrentProcess();
            string ProgramPath = Process.MainModule.FileName;
            string[] PathSteps = ProgramPath.Split(@"\"[0]);
            int LengthOfPathSteps = PathSteps.Length;
            PathSteps[LengthOfPathSteps - 1] = null;
            ProgramPath = String.Join(@"\", PathSteps);
            ProgramPath = @"Data Source=" + ProgramPath + @"Database.db; Version=3;Password=12345;";
            return ProgramPath;
        }

        public static string GetCurrentDbPath()
        {
            var Process = System.Diagnostics.Process.GetCurrentProcess();
            string ProgramFullPath = Process.MainModule.FileName;
            string[] PathSteps = ProgramFullPath.Split(@"\"[0]);
            int LengthofPathSteps = PathSteps.Length;
            PathSteps[LengthofPathSteps - 1] = null;
            ProgramFullPath = String.Join(@"\", PathSteps);
            ProgramFullPath += "Database.db";
            return ProgramFullPath;
        }

        public static bool Exists()
        {
            return File.Exists(GetCurrentDbPath());
        }

        public static void CreateDb()
        {
            String Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            try { 
                if (!Exists())
                {
                    SQLiteConnection.CreateFile(GetCurrentDbPath());
                }
                SQLiteConnection Connection = new SQLiteConnection(@"Data Source=" + GetCurrentDbPath() + @"; Version=3;");
                Connection.SetPassword("12345");
                string Query = $"CREATE TABLE questions (id INTEGER PRIMARY KEY ASC AUTOINCREMENT  UNIQUE  NOT NULL,title VARCHAR NOT NULL," +
                    $"right_answers TEXT NOT NULL,subject_id INTEGER NOT NULL," +
                "type  INTEGER NOT NULL  DEFAULT(0),  answers TEXT    NOT NULL,imagename VARCHAR);";
                SendWriteQuery(Query);

                Query = $"CREATE TABLE results (id INTEGER  PRIMARY KEY ASC AUTOINCREMENT  UNIQUE  NOT NULL,right_a INTEGER  NOT NULL," +
                    $" count INTEGER NOT NULL, user_id INTEGER  NOT NULL," +
                "subject_id INTEGER NOT NULL,timestamp DATETIME DEFAULT(CURRENT_TIMESTAMP) NOT NULL,wrong      TEXT     DEFAULT (0),wrongtag      TEXT     DEFAULT (0), [full]  TEXT,[fulltag]  TEXT, checked    BOOLEAN,countoffull INT); ";
                SendWriteQuery(Query);

                Query = "CREATE TABLE subjects (id INTEGER PRIMARY KEY AUTOINCREMENT  NOT NULL  UNIQUE,  name VARCHAR NOT NULL);";
                SendWriteQuery(Query);

                Query = $"CREATE TABLE users (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,name VARCHAR NOT NULL," +
                    $"surname  VARCHAR NOT NULL,login VARCHAR NOT NULL  UNIQUE,password VARCHAR NOT NULL, admin    INTEGER DEFAULT(0) NOT NULL, salt VARCHAR UNIQUE NOT NULL);";
                SendWriteQuery(Query);
                Query = $"CREATE TABLE full_answers (id INTEGER  UNIQUE    PRIMARY KEY  AUTOINCREMENT NOT NULL, question_id INT,  user_answer TEXT,  qnum INT,result INT default(-1),result_id INT);";
                SendWriteQuery(Query);
                Query = $"CREATE TABLE properties (id INTEGER PRIMARY KEY AUTOINCREMENT " +
                    $" UNIQUE  NOT NULL,  user_id   INTEGER,  name STRING, surname  STRING, subject_name STRING,  " +
                    $"  login STRING,    admin INTEGER,    theme_id   INTEGER, " +
                    $"   subject_sel INTEGER,    first_time_started INTEGER, version STRING);";
                SendWriteQuery(Query);
                Query = $"CREATE TRIGGER upd_trig      AFTER UPDATE OF result   ON full_answers BEGIN    UPDATE results       SET checked = 1 " +
                    $"    WHERE countoffull = (   SELECT count(* )    FROM full_answers AS Count1   " +
                    $"      WHERE result_id = old.result_id AND    result > -1    )AND           id = old.result_id;                END;                ";
                SendWriteQuery(Query);
                Query = $"CREATE TRIGGER uqweqwe      AFTER UPDATE OF result   ON full_answers BEGIN    UPDATE results       SET checked = 0 " +
                   $"    WHERE countoffull != (   SELECT count(* )    FROM full_answers AS Count1   " +
                   $"      WHERE result_id = old.result_id AND    result > -1    )AND           id = old.result_id;                END;                ";
                SendWriteQuery(Query);
                Query = $"INSERT INTO properties (user_id,version) VALUES(1, '{Version}')";
                SendWriteQuery(Query);
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
