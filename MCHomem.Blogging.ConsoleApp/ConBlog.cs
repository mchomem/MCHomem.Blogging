using MCHomem.Blogging.ConsoleApp.Shared;
using MCHomem.Blogging.Controllers;
using MCHomem.Blogging.Models.Entity;
using System;
using System.Collections.Generic;

namespace MCHomem.Blogging.ConsoleApp
{
    public class ConBlog
    {
        #region Methods

        public static void Add()
        {
            try
            {
                Blog blog = new Blog();

                while (true)
                {
                    Console.Write("Url: ");
                    String url = Console.ReadLine();

                    if (String.IsNullOrEmpty(url))
                    {
                        Console.WriteLine("Type a required field.");
                        continue;
                    }

                    blog.Url = url;
                    new BlogController().Add(blog);
                    Console.WriteLine("\nNew record added.");
                    break;
                }
            }
            catch (Exception e)
            {
                Message.Error(e);
            }

            Console.ReadKey();
        }

        public static void Remove()
        {
            try
            {
                while (true)
                {
                    Console.Write("Type a valid ID: ");

                    Int32 id = 0;
                    String input = Console.ReadLine();

                    if (!Int32.TryParse(input, out id))
                    {
                        Console.WriteLine("Type a valid number.");
                        continue;
                    }

                    Blog blog = new BlogController().Get(new Blog() { BlogId = id });

                    if (blog == null)
                    {
                        Console.WriteLine("Not found. Continue[y/n]");
                        String op = Console.ReadLine();

                        if (op.ToLower().Equals("y"))
                            continue;
                        else
                            break;
                    }

                    new BlogController().Remove(blog);
                    Console.WriteLine("\nRecord removed.");
                    break;
                }
            }
            catch (Exception e)
            {
                Message.Error(e);
            }

            Console.ReadKey();
        }

        public static void Refresh()
        {
            try
            {
                while (true)
                {
                    Console.Write("Type a valid ID: ");

                    Int32 id = 0;
                    String input = Console.ReadLine();

                    if (!Int32.TryParse(input, out id))
                    {
                        Console.WriteLine("Type a valid number.");
                        continue;
                    }

                    Blog blog = new BlogController().Get(new Blog() { BlogId = id });

                    if (blog == null)
                    {
                        Console.WriteLine("Not found. Continue[y/n]");
                        String op = Console.ReadLine();

                        if (op.ToLower().Equals("y"))
                            continue;
                        else
                            break;
                    }

                    Console.Write("Url: ");
                    blog.Url = Console.ReadLine();
                    new BlogController().Refresh(blog);
                    Console.WriteLine("\nRecord refreshed.");
                    break;
                }
            }
            catch (Exception e)
            {
                Message.Error(e);
            }

            Console.ReadKey();
        }

        public static void Get()
        {
            try
            {
                while (true)
                {
                    Console.Write("Type a valid ID: ");

                    Int32 id = 0;
                    String input = Console.ReadLine();

                    if (!Int32.TryParse(input, out id))
                    {
                        Console.WriteLine("Type a valid number.");
                        continue;
                    }

                    Blog blog = new BlogController().Get(new Blog() { BlogId = id });

                    if (blog == null)
                    {
                        Console.WriteLine("Not found. Continue[y/n]");
                        String op = Console.ReadLine();

                        if (op.ToLower().Equals("y"))
                            continue;
                        else
                            break;
                    }

                    Console.WriteLine($"ID: { blog.BlogId }");
                    Console.WriteLine($"URL: { blog.Url }");
                    break;
                }
            }
            catch (Exception e)
            {
                Message.Error(e);
            }

            Console.ReadKey();
        }

        public static void GetAll()
        {
            try
            {
                List<Blog> blogs = new BlogController().GetAll();
                String title = "Report of Blogs";
                Console.Clear();
                Console.WriteLine("".PadRight(Console.BufferWidth, '='));
                Console.Write("".PadRight( (Console.BufferWidth / 2) - (title.Length / 2)), ' ');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(title);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.WriteLine("".PadRight(Console.BufferWidth, '='));

                Console.Write("ID".PadRight(10, ' '));
                Console.WriteLine("URL");
                Console.WriteLine("-".PadRight(Console.BufferWidth, '-'));

                foreach (Blog b in blogs)
                {
                    Console.Write(b.BlogId.ToString().PadRight(10, ' '));
                    Console.Write(b.Url);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Message.Error(e);
            }

            Console.ReadKey();
        }

        #endregion
    }
}
