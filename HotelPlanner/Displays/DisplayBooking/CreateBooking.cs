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
    public class CreateBooking : ICreateBooking
    {
        public bool _running;
        private byte _numberOfVisitors = 1;
        private byte _numberofNights = 1;
        private string _extraBed = "No";
        public void ShowCreateBooking()
        {
            _running = true;
            while(_running)
            {
                Console.Clear();
                Console.WriteLine("Skapa ny bokning");
                Console.WriteLine("================");

                //här ska man välja kunden

                _running = false; 
            }


            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Skapa ny bokning");
                Console.WriteLine("================");

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"- Antal besökare: {_numberOfVisitors}");
                Console.ResetColor();

                var keyInput = Console.ReadKey(true);
                SelectVistorAmount(keyInput);
            }

            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Skapa ny bokning");
                Console.WriteLine("================");

                Console.WriteLine($"- Antal besökare: {_numberOfVisitors}");

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"- Antal Nätter: {_numberofNights}");
                Console.ResetColor();

                var keyInput = Console.ReadKey(true);
                SelectNumberOfNights(keyInput);
            }

            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Skapa ny bokning");
                Console.WriteLine("================");

                //här ska man välja datum

                _running = false;
            }

            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Skapa ny bokning");
                Console.WriteLine("================");

                Console.WriteLine($"- Antal besökare: {_numberOfVisitors}");
                Console.WriteLine($"- Antal Nätter: {_numberofNights}");

                Console.BackgroundColor= ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"- Extra säng: {_extraBed}");
                Console.ResetColor();

                var keyInput = Console.ReadKey(true);
                SelectExtraBed(keyInput);
            }

        }
        public byte SelectVistorAmount(ConsoleKeyInfo keyInput)
        {
            while (true)
            {
                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    _numberOfVisitors++;
                    if (_numberOfVisitors > 5)
                        _numberOfVisitors = 5;
                }
                else if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    _numberOfVisitors--;
                    if (_numberOfVisitors < 1)
                        _numberOfVisitors = 1;
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                    _running = false;

                return _numberOfVisitors;
            }
        }
        public byte SelectNumberOfNights(ConsoleKeyInfo keyInput)
        {

            while (true)
            {
                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    _numberofNights++;
                    if (_numberofNights > 14)
                        _numberofNights = 14;
                }
                else if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    _numberofNights--;
                    if (_numberofNights < 1)
                        _numberofNights = 1;
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                    _running = false;

                return _numberofNights;
            }
        }
        public string SelectExtraBed(ConsoleKeyInfo keyInput)
        {
            while (true)
            {
                if (keyInput.Key == ConsoleKey.UpArrow)
                    _extraBed = "Yes";

                else if (keyInput.Key == ConsoleKey.DownArrow)
                    _extraBed = "No";
                else if (keyInput.Key == ConsoleKey.Enter)
                    _running = false;

                return _extraBed;
            }
        }
    }
}
