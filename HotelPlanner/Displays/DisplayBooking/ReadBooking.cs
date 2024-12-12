using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayBooking
{
    public class ReadBooking : IReadBooking
    {
        public void ShowReadBooking()
        {
            Console.Clear();
            Console.WriteLine("Titta på befintliga bokningar");
            Console.WriteLine("=============================");

            Console.ReadKey();
        }
    }
}
