using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class DeleteCustomer : IDeleteCustomer
    {
        public void ShowDeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("Ta bort kund");
            Console.WriteLine("============");

            Console.ReadKey();
        }
    }
}
