using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace MVVM_Trial.src.model
{
    public class SqliteDataAccess
    {
        public static List<PersonModel> LoadPeople()
        {
            // Connect to SQLite
            // Will close the connection to the DB in a fail-safe manner
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //SqlCommand sqlcmd = new SqlCommand("select * from Person");
                string sqlcmd = "select * from Person";

                var output = cnn.Query<PersonModel>(sqlcmd, new DynamicParameters());
                return output.ToList();
            }

            // DB is closed!
        }


        public static void SavePerson(PersonModel person)
        {
            // Connect to SQLite
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Parameterized string
                string sqlcmd = "insert into Person (FirstName, LastName) values (@FirstName, @LastName)";
                cnn.Execute(sqlcmd, person);
            }

            // DB is closed!
        }


        private static string LoadConnectionString(string id = "DefaultDB")
        {
            // Go to App.config and look for the id of DefaultDB
            // and return the ConnectionString
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
