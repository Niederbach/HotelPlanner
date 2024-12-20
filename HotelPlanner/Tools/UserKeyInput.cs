using HotelManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Tools
{
    public class UserKeyInput
    {
        public static int UserInput(int selectedIndex, ConsoleKeyInfo keyInput, List<string> options)
        {
            if (keyInput.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex > options.Count)
                    selectedIndex = 0;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = options.Count;
            }

            return selectedIndex;
        }
        public static int CustomerKeyInput(int selectedIndex, ConsoleKeyInfo keyInput, List<Customer> customers)
        {
            if (keyInput.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex > customers.Count)
                    selectedIndex = 0;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = customers.Count;
            }

            return selectedIndex;
        }
    }
}
