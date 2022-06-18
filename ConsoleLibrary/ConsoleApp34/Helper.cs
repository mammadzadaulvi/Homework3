using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp34
{
    class Helper
    {
        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
