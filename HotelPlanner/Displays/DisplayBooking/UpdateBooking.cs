using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayBooking
{
    public class UpdateBooking : IUpdateBooking
    {
        public void ShowUpdateBooking()
        {
            Console.Clear();
            Console.WriteLine("Ändra på bokning");
            Console.WriteLine("================");

            Console.ReadKey();
        }
    }
}
