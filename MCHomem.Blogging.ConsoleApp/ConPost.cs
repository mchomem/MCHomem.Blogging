using MCHomem.Blogging.ConsoleApp.Shared;
using MCHomem.Blogging.Controllers;
using MCHomem.Blogging.Models.Entities;
using System;
using System.Collections.Generic;

namespace MCHomem.Blogging.ConsoleApp
{
    public class ConPost
    {
        #region Methods

        public static void Add()
        {
            try
            {
                Post post = new Post();

                while (true)
                {
                    Console.Write("Title: ");
                    String title = Console.ReadLine();
                    if (String.IsNullOrEmpty(title))
                    {
                        Console.WriteLine("Required field. Type a value.");
                        continue;
                    }
                    post.Title = title;
                    break;
                }

                Console.WriteLine();

                while (true)
                {
                    Console.Write("Content: ");
                    String content = Console.ReadLine();
                    if (String.IsNullOrEmpty(content))
                    {
                        Console.WriteLine("Required field. Type a value.");
                        continue;
                    }
                    post.Content = content;
                    break;
                }

                Console.WriteLine();

                while (true)
                {
                    Console.WriteLine("Choose a Blog (type a existent ID): ");

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

                    post.Blog = blog;
                    new PostController().Add(post);
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

                    Post post = new PostController().Get(new Post() { PostId = id });

                    if (post == null)
                    {
                        Console.WriteLine("Not found. Continue[y/n]");
                        String op = Console.ReadLine();

                        if (op.ToLower().Equals("y"))
                            continue;
                        else
                            break;
                    }

                    new PostController().Remove(post);
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

                    Post post = new PostController().Get(new Post() { PostId = id });

                    if (post == null)
                    {
                        Console.WriteLine("Not found. Continue[y/n]");
                        String op = Console.ReadLine();

                        if (op.ToLower().Equals("y"))
                            continue;
                        else
                            break;
                    }

                    Console.Write("Title: ");
                    post.Title = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Content: ");
                    post.Content = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Type a valid blog ID: ");

                    Int32 IdBlog = 0;
                    String inputBlog = Console.ReadLine();

                    if (!Int32.TryParse(input, out IdBlog))
                    {
                        Console.WriteLine("Type a valid number.");
                        continue;
                    }

                    Blog blog = new BlogController().Get(new Blog() { BlogId = id });

                    if (post == null)
                    {
                        Console.WriteLine("Not found. Continue[y/n]");
                        String op = Console.ReadLine();

                        if (op.ToLower().Equals("y"))
                            continue;
                        else
                            break;
                    }

                    post.Blog = blog;

                    new PostController().Refresh(post);
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

                    Post post = new PostController().Get(new Post() { PostId = id });

                    if (post == null)
                    {
                        Console.WriteLine("Not found. Continue[y/n]");
                        String op = Console.ReadLine();

                        if (op.ToLower().Equals("y"))
                            continue;
                        else
                            break;
                    }

                    Console.WriteLine($"ID: { post.PostId }");
                    Console.WriteLine($"TITLE: { post.Title }");
                    Console.WriteLine($"CONTENT: { post.Content }");
                    Console.WriteLine($"BLOG: { post.Blog.Url }");
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
                Int32 columnIdSpacing = 10;
                Int32 columnTitleSpacing = 20;
                Int32 columnContentSpacing = 50;

                List<Post> posts = new PostController().GetAll();
                String title = "Report of Posts";
                Console.Clear();
                Console.WriteLine("".PadRight(Console.BufferWidth, '='));
                Console.Write("".PadRight((Console.BufferWidth / 2) - (title.Length / 2)), ' ');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(title);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.WriteLine("".PadRight(Console.BufferWidth, '='));

                Console.Write("ID".PadRight(columnIdSpacing, ' '));
                Console.Write("TITLE".PadRight(columnTitleSpacing, ' '));
                Console.Write("CONTENT".PadRight(columnContentSpacing, ' '));
                Console.WriteLine("BLOG (url)");
                Console.WriteLine("-".PadRight(Console.BufferWidth, '-'));

                foreach (Post p in posts)
                {
                    Console.Write(p.PostId.ToString().PadRight(columnIdSpacing, ' '));
                    Console.Write(p.Title.ToString().PadRight(columnTitleSpacing, ' '));
                    Console.Write(p.Content.ToString().PadRight(columnContentSpacing, ' '));
                    Console.Write(p.Blog.Url);
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
