using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Dapper;

namespace Bookish
{
    class Buksh
    {
        private bool Running = true;
        private BookAccessish _dataAccess = new BookAccessish();
        static void Main(string[] args)
        {
            var aBookish = new Buksh();
            aBookish.Init();
        }

        public void Init()
        {
            while (Running == true)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Bookish..");
                Console.WriteLine();
                Console.WriteLine("Please Enter a command to continue..");
                var command = Console.ReadLine();
                Run(command);
            }
        }

        public void Run(string command)
        {
            Console.WriteLine();

            if (command.ToLower() == "get users" || command.ToLower() == "getusers" || command.ToLower() == "gu" || command.ToLower() == "g u")
            {
                var userList = _dataAccess.GetUsers();
                foreach (var user in userList)
                {
                    Console.WriteLine("UserId : " + user.UserId);
                    Console.WriteLine("Name : " + user.Name);
                    Console.WriteLine("Email : " + user.Email);
                    Console.WriteLine(":::::::::::::::::::::::::");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadLine();
                return;
            }
            if (command.ToLower() == "get book" || command.ToLower() == "getbook" || command.ToLower() == "gb" || command.ToLower() == "g b")
            {
                var bookList = _dataAccess.GetBooks();
                foreach (var book in bookList)
                {
                    Console.WriteLine("TitileId : " + book.TitleId);
                    Console.WriteLine("Title : " + book.Title);
                    Console.WriteLine("Author : " + book.Author);
                    Console.WriteLine("NoOfBooks : " + book.NoOfBooks);
                    Console.WriteLine("ISBN : " + book.ISBN);
                    Console.WriteLine(":::::::::::::::::::::::::");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadLine();
                return;
            }
            if (command.ToLower() == "get checkout" || command.ToLower() == "getcheckout" || command.ToLower() == "gc" || command.ToLower() == "g c")
            {
                var checkoutList = _dataAccess.GetCheckout();
                foreach (var checkout in checkoutList)
                {
                    Console.WriteLine("UserId : " + checkout.UserId);
                    Console.WriteLine("TitleId : " + checkout.TitleId);
                    Console.WriteLine("CheckoutId : " + checkout.CheckoutId);
                    Console.WriteLine(":::::::::::::::::::::::::");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadLine();
                return;
            }

        }
    }
}
