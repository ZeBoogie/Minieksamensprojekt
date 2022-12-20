using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PP_AddIn___minieks
{
    public class Database
    {
        public SqliteConnection myConnection;

        public Database()
        {
            myConnection = new SqliteConnection
                ("Data Source=C:\\Users\\Jonat\\Documents\\HCØ\\3.G\\Teknik - DDU\\databaser\\mydatabase.sqlite");
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
