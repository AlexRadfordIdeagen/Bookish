using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using Dapper;

namespace Bookish
{
    class Program
    {
        static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnection"].ConnectionString);

        static void Main(string[] args)
        {

            string SqlString = "SELECT TOP 100 [UserId],[Name] FROM [User]";
            var Users = (List<User>)db.Query<User>(SqlString);
            foreach (var user in Users)
            {
                Console.WriteLine(user.Name + " " + user.UserId);
            }

            Console.ReadLine();

        }
    }
}
