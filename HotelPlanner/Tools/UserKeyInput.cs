using HotelManagementLibrary.Models;
using Microsoft.Extensions.Options;
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
        public static int VisistorUserInput(int selectedIndex, ConsoleKeyInfo keyInput, int highIndex, int lowIndex)
        {
            if (keyInput.Key == ConsoleKey.DownArrow)
            {
                selectedIndex--;
                if (selectedIndex < lowIndex)
                    selectedIndex = lowIndex;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                selectedIndex++;
                if (selectedIndex > highIndex)
                    selectedIndex = highIndex;
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
        public static int RoomKeyInput(int selectedIndex, ConsoleKeyInfo keyInput, List<Room> room)
        {
            if (keyInput.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex > room.Count)
                    selectedIndex = 0;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = room.Count;
            }

            return selectedIndex;
        }
        public static int BookingKeyInput(int selectedIndex, ConsoleKeyInfo keyInput, List<Booking> booking)
        {
            if (keyInput.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex > booking.Count)
                    selectedIndex = 0;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = booking.Count;
            }

            return selectedIndex;
        }
    }
}
