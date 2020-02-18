using System;

namespace MCHomem.Blogging.ConsoleApp.Shared
{
    public class Header
    {
        #region Methods

        public static void Add()
        {
            Console.WriteLine(String.Empty.PadRight(Console.BufferWidth, '='));
            Console.Write("Connected user ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Session.UserSession.Name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine(String.Empty.PadRight(Console.BufferWidth, '='));
        }

        #endregion
    }
}
