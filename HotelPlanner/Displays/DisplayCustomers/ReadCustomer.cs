using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class ReadCustomer : IReadCustomer
    {
        public void ShowReadCustomer()
        {
            Console.Clear();
            Console.WriteLine("Titta på kunder");
            Console.WriteLine("===============");

            Console.ReadKey();
        }
    }
}
