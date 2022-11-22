using System;
using System.Collections.Generic;
using System.Text;

namespace ebOS
{
    public class Term
    {
        public static string Edit()
        {
            ConsoleKeyInfo key;
            Console.Clear();
            Console.WriteLine("Type your Term script here (Tab to save) (ESC to leave)");
            Console.WriteLine("-------------------------------------------------------");
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += "\n";
                key = Console.ReadKey(true);
            }
            while (key.Key != ConsoleKey.Tab && key.Key != ConsoleKey.Escape);
            if (key.Key == ConsoleKey.Tab)
            {
                return text;
            }
            else
            {
                return null;
            }
            
        }
    }
}