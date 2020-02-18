using MCHomem.Blogging.ConsoleApp.Shared;
using MCHomem.Blogging.Controllers;
using MCHomem.Blogging.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCHomem.Blogging.ConsoleApp
{
    public class ConLogin
    {
        #region Methods

        public static void Authenticate()
        {
            while (true)
            {
                Console.WriteLine("==== Type your login and password ".PadRight(Console.BufferWidth, '='));
                Console.WriteLine();

                Console.Write("Login: ");
                String login = Console.ReadLine();
                Console.Write("Password: ");
                String password = ReadPassword();

                User user = new UserController()
                    .CheckUserLogin(new User() { Login = login, Password = password });

                if (user != null)
                {
                    Session.UserSession = user;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInvalid login or password. Try again!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
        }

        public static String ReadPassword(char mask)
        {
            const Int32 ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
            Int32[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

            Stack<char> pass = new Stack<char>();
            char chr = (char)0;

            while ((chr = Console.ReadKey(true).KeyChar) != ENTER)
            {
                if (chr == BACKSP)
                {
                    if (pass.Count > 0)
                    {
                        Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else if (chr == CTRLBACKSP)
                {
                    while (pass.Count > 0)
                    {
                        Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else if (FILTERED.Count(x => chr == x) > 0) { }
                else
                {
                    pass.Push((char)chr);
                    Console.Write(mask);
                }
            }

            Console.WriteLine();

            return new String(pass.Reverse().ToArray());
        }

        public static String ReadPassword()
        {
            return ReadPassword('*');
        }

        #endregion
    }
}
