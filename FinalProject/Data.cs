using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using LiteDB;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.SQLite;
namespace FinalProject
{
    public class Cards
    {
        public int id { get; set; }
        public int od { get; set; }
        public int alies { get; set; }
        public int setcode { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int level { get; set; }
        public int race { get; set; }
        public int attribute { get; set; }
        public int category { get; set; }

        public string[] name { get; set; }
        public string[] desc { get; set; }

    }


    public class MainDB
    {
       public static string DB ()
        {
            string sqlfile = "Data Source=cards.cdb;";
            using (SQLiteConnection connection = new SQLiteConnection(sqlfile))
            using (SQLiteCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"SELECT `_rowid_`,* FROM `texts` ORDER BY `id` ASC LIMIT 5;";
                connection.Open();
                SQLiteDataReader r = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                while (r.Read())
                {
                    dt.Load(r);
                    return "ID " + dt.Rows[0][1];
                }

                connection.Close();

                return "A";
            }
        }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
    }
    

}
