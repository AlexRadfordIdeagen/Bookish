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
            }
        }

        public void Run(string command)
        {
            Console.WriteLine();

            if (command.ToLower() == "get users" || command.ToLower() == "getusers" || command.ToLower() == "gu" || command.ToLower() == "g u")
            {

            }

        }
    }
}
