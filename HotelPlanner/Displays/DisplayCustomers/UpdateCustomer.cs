using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class UpdateCustomer : IUpdateCustomer
    {
        public void ShowUpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Ändra på befintlig kund");
            Console.WriteLine("=======================");

            Console.ReadKey();
        }
    }
}
