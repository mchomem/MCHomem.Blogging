using MCHomem.Blogging.ConsoleApp.Shared;
using MCHomem.Blogging.Controllers;
using System;

namespace MCHomem.Blogging.ConsoleApp
{
    class Program
    {
        #region Main method

        static void Main(String[] args)
        {
            Init();
            ConLogin.Authenticate();
            AddMenu();
        }

        #endregion

        #region Methods

        private static void Init()
        {
            Console.Title = "Console app to works with Entity Framework Core & Sql Server";
            new UserController().InitializeUser();
        }

        private static void AddMenu()
        {
            while (true)
            {
                Console.Clear();
                Header.Add();
                Console.WriteLine("\n*** Menu ***");
                Console.WriteLine("\n1. Blog");
                Console.WriteLine("2. Post");
                Console.WriteLine("0. Exit");
                Console.Write("\nOption: ");

                String selectedOperation = Console.ReadLine();

                if (selectedOperation.Equals("1"))
                {
                    AddMenuBlog();
                }
                else if (selectedOperation.Equals("2"))
                {
                    AddMenuPost();
                }
                else if (selectedOperation.Equals("0"))
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("Choose a valid option from menu!");
                    Console.ReadKey();
                }
            }
        }

        private static void AddMenuBlog()
        {
            while (true)
            {
                Console.Clear();
                Header.Add();
                Console.WriteLine("\n*** Blog - operations ***");
                Console.WriteLine("\n1. Add");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Refresh");
                Console.WriteLine("4. Get");
                Console.WriteLine("5. Get all");
                Console.WriteLine("0. Return to main menu");
                Console.Write("\nOption: ");

                String selectedOperation = Console.ReadLine();

                if (selectedOperation.Equals("1"))
                {
                    ConBlog.Add();
                }
                else if (selectedOperation.Equals("2"))
                {
                    ConBlog.Remove();
                }
                else if (selectedOperation.Equals("3"))
                {
                    ConBlog.Refresh();
                }
                else if (selectedOperation.Equals("4"))
                {
                    ConBlog.Get();
                }
                else if (selectedOperation.Equals("5"))
                {
                    ConBlog.GetAll();
                }
                else if (selectedOperation.Equals("0"))
                {
                    break;
                }
                else
                {
                    InvalidOptionMessage();
                }
            }
        }

        private static void AddMenuPost()
        {
            while (true)
            {
                Console.Clear();
                Header.Add();
                Console.WriteLine("\n*** Post - operations ***");
                Console.WriteLine("\n1. Add");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Refresh");
                Console.WriteLine("4. Get");
                Console.WriteLine("5. Get all");
                Console.WriteLine("0. Return to main menu");
                Console.Write("\nOption: ");

                String selectedOperation = Console.ReadLine();

                if (selectedOperation.Equals("1"))
                {
                    ConPost.Add();
                }
                else if (selectedOperation.Equals("2"))
                {
                    ConPost.Remove();
                }
                else if (selectedOperation.Equals("3"))
                {
                    ConPost.Refresh();
                }
                else if (selectedOperation.Equals("4"))
                {
                    ConPost.Get();
                }
                else if (selectedOperation.Equals("5"))
                {
                    ConPost.GetAll();
                }
                else if (selectedOperation.Equals("0"))
                {
                    break;
                }
                else
                {
                    InvalidOptionMessage();
                }
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting system...\nPress any button.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static void InvalidOptionMessage()
        {
            Console.WriteLine("Choose a valid option from menu!");
            Console.ReadKey();
        }

        #endregion
    }
}
