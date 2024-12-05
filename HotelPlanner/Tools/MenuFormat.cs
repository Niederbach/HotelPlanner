using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Tools
{
    public class MenuFormat
    {
        public static void CreateMenuUI(List<string> menuOptions, int selectedIndex)
        {
            for (int i = 0; i < menuOptions.Count; i++)
            {
                if (selectedIndex == i)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"- {menuOptions[i]}");
                Console.ResetColor();
            }
            if (selectedIndex == menuOptions.Count)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("- Avsluta");
            Console.ResetColor();
        }
    }
}
