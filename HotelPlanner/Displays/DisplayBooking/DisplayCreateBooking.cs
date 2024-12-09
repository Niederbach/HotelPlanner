using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayBooking
{
    public class DisplayCreateBooking : IDisplayCreateBooking
    {
        private bool _running;
        private int _selectedIndex;
        public List<string> displayInputs = new List<string>();
        public DisplayCreateBooking()
        {
            displayInputs.Add("Antal vuxna      - ");
            displayInputs.Add("Antal barn       - ");
            displayInputs.Add("Antal nätter     - ");
            displayInputs.Add("Extra säng (Y/N) - ");
            displayInputs.Add("Fortsätt");
        }
        public void CreateBooking()
        {
            _running = true;
            _selectedIndex = 0;
            var userInputs = new List<string>(new string[displayInputs.Count]);
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Skapa ny bokning");
                Console.WriteLine("Tryck enter för att fylla i");
                Console.WriteLine("===========================");

                for (int i = 0; i < displayInputs.Count; i++)
                {
                    if (_selectedIndex == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(displayInputs[i]);
                    Console.WriteLine(userInputs[i] ?? "");
                    Console.ResetColor();
                }
                if (_selectedIndex == displayInputs.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("Tillbaka");
                Console.ResetColor();
                Console.WriteLine("================");

                var keyInput = Console.ReadKey(true);

                if (_selectedIndex < displayInputs.Count - 1 && keyInput.Key == ConsoleKey.Enter)
                {
                    // Edit the selected input
                    Console.SetCursorPosition(displayInputs[_selectedIndex].Length, _selectedIndex + 3); 
                    userInputs[_selectedIndex] = Console.ReadLine() ?? "";
                }
                else
                {
                    UserInput(keyInput, userInputs);
                }
            }
        }
        public void UserInput(ConsoleKeyInfo keyInput, List<string> userInputs)
        {
            if (keyInput.Key == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex > displayInputs.Count)
                    _selectedIndex = 0;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex < 0)
                    _selectedIndex = displayInputs.Count;
            }
            else if (_selectedIndex < displayInputs.Count && keyInput.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Fortsätt");
                byte numberOfAdults = byte.Parse(userInputs[0]);
                byte numberOfKids = byte.Parse(userInputs[1]);
                byte numberOfNights = byte.Parse(userInputs[2]);
                char extraBed = char.Parse(userInputs[3]);
                Console.ReadKey();
            }
            else if (_selectedIndex == displayInputs.Count && keyInput.Key == ConsoleKey.Enter)
            {
                _running = false;
            }
        }
    }
}
