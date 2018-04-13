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
    class BookAccessish
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnection"].ConnectionString);

        public List<User> GetUsers()
        {
            var SqlString = "SELECT * FROM [User]";
            var users = (List<User>)db.Query<User>(SqlString);
            return users;
        }
        public List<Book> GetBooks()
        {
            var SqlString = "SELECT * FROM [Book]";
            var books = (List<Book>)db.Query<Book>(SqlString);
            return books;
        }
        public List<Checkout> GetCheckout()
        {
            var SqlString = "SELECT * FROM [Checkout]";
            var checkouts = (List<Checkout>)db.Query<Checkout>(SqlString);
            return checkouts;
        }

    }
}
