using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Dapper;

namespace Bookish
{
    public class BookAccessish
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnection"].ConnectionString);
        //User Access
        public List<User> GetUsers()
        {
            var SqlString = "SELECT * FROM [User]";
            var users = (List<User>)db.Query<User>(SqlString);
            return users;
        }

        public void CreateUser(string email, string id, string name)
        {
            System.Diagnostics.Debug.WriteLine("called create user");
            var users = GetUsers();
            foreach (var user in users)
            {
                if (user.Email.ToLower() == email.ToLower()) return;
            }

            const string insertQuery = @"INSERT INTO [User]([Email], [Name], [UserId]) VALUES (@Email, @Name, @UserId)";

            db.Execute(insertQuery, new User
            {
                Email = email,
                Name = name,
                UserId = id
            });
        }

        //Book Access
        public List<Book> GetBooks()
        {
            var SqlString = "SELECT * FROM [Book]";
            var books = (List<Book>)db.Query<Book>(SqlString);
            return books;
        }


        public string GetFirstDueDate(string bookId)
        {
            var SqlString = "SELECT MIN (DueDate) FROM Checkout WHERE TitleId = '" + bookId + "'";
            string date = db.Query<DateTime?>(SqlString).FirstOrDefault()?.ToShortDateString().ToString();
            return date;
        }

        public string GetFirstUserReturningBook(string bookId)
        {
            var SqlString = "SELECT TOP 1 [Name] FROM [BookishDB].[dbo].[Checkout] c" +
                " join[Book] b on c.TitleId = b.TitleId join[User] u on c.UserId = u.UserId" +
                $" where c.TitleId ='{bookId}'";
            string user = db.Query<string>(SqlString).FirstOrDefault();
            return user;
        }

        public Book GetBook(string ISBN)
        {
            var SqlString = "SELECT * FROM [Book] WHERE ISBN = '" + ISBN + "'";
            var book = (Book)db.Query<Book>(SqlString).FirstOrDefault();
            return book;
        }

        public void AddBook(Book book)
        {
            var InsertSqlString = "INSERT INTO [Book] (NoOfBooks, Author, Title, ISBN, cover) " +
                $"VALUES ('{book.NoOfBooks}', '{book.Author}', '{book.Title}', '{book.ISBN}', '{book.cover}')";
            db.Query(InsertSqlString);

        }
        //Checkout Access
        public List<Checkout> GetCheckout()
        {
            var SqlString = "SELECT * FROM [Checkout]";
            var checkouts = (List<Checkout>)db.Query<Checkout>(SqlString);
            return checkouts;
        }
        public List<DetailedCheckout> GetCheckout(string userId)
        {
            var SqlString = "SELECT[Name], DueDate, Title FROM[BookishDB].[dbo].[Checkout] c" +
                " join[Book] b on c.TitleId = b.TitleId join[User] u on c.UserId = u.UserId" +
                $" where u.UserId = '{userId}'";
            var checkouts = (List<DetailedCheckout>)db.Query<DetailedCheckout>(SqlString);

            return checkouts;
        }
        public int GetNumberOfCheckedOut(string titleId)
        {

            var SqlString = "SELECT COUNT(*) FROM [Checkout] WHERE TitleId = '" + titleId + "'";
            int result = db.Query<int>(SqlString).FirstOrDefault();

            return result;
        }

    }
}
