using System;

namespace MCHomem.Blogging.ConsoleApp.Shared
{
    public class Message
    {
        public static void Error(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n*** Error ***\n\nMessage: { e.Message }");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
