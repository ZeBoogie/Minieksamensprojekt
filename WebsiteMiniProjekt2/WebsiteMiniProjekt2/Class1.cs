using Microsoft.Data.Sqlite;

namespace WebsiteMiniProjekt2
{
    public class Database
    {
        public SqliteConnection myConnecntion;

        public Database() 
        {
            myConnecntion = new SqliteConnection
                ("Data Source=C:\\Users\\Jonat\\Documents\\HCØ\\3.G\\Teknik - DDU\\databaser\\mydatabase.sqlite");
        }

    }
}
