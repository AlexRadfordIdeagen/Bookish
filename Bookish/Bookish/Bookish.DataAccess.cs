using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Dapper;

namespace Bookish
{
    class Bookish
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnection"].ConnectionString);

        public List<User> GetUsers()
        {
            var SqlString = "SELECT * [UserId],[Name] FROM [User]";
            var users = (List<User>)db.Query<User>(SqlString);
            return users;
        }
        public List<Book> GetBooks()
        {
            var SqlString = "SELECT * [TitleId],[Title],[Author],[NoOfBooks],[ISBN] FROM [Books]";
            var books = (List<Book>)db.Query<User>(SqlString);
            return books;
        }
        public List<Checkout> GetCheckout()
        {
            var SqlString = "SELECT * [UserId],[TitleId],[ChouckoutId] FROM [User]";
            var checkouts = (List<Checkout>)db.Query<User>(SqlString);
            return checkouts;
        }

    }
}
