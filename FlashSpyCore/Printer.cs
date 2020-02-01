using System;

namespace FlashSpyCore
{
    class Printer
    {
        public static void PrintDangerMessage(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintSuccessMessage(string text)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintInfoMessage(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintHelloWorld()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("H");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("l");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("l");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("o ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("w");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("r");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("l");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("d");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("!");

            Console.ResetColor();
        }
    }
}
