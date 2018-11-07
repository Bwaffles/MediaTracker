using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public class Test
    {
        public SQLiteConnection m_dbConnection;

        public Test()
        {
            m_dbConnection = new SQLiteConnection(@"C:/Users/Thana/Downloads/Movies");
        }

        //public void ExecuteNonQuery(string sql)
        //{
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    command.ExecuteNonQuery();
        //}
    }
}