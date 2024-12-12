using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayBooking
{
    public class DeleteBooking : IDeleteBooking
    {
        public void ShowDeleteBooking()
        {
            Console.Clear();
            Console.WriteLine("Ta bort bokning");
            Console.WriteLine("===============");

            Console.ReadKey();
        }
    }
}
