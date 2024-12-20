using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Tools
{
    public class ReadFormat
    {
        public static void CreateReadUI(int selectedIndex, List<string> readOptions)
        {
            for (var i = 0; i < readOptions.Count; i++)
            {
                if (selectedIndex == i)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"- {readOptions[i]}");
                Console.ResetColor();
            }
            if (selectedIndex == readOptions.Count)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("- Tillbaka");
            Console.ResetColor();
        }
    }
}
