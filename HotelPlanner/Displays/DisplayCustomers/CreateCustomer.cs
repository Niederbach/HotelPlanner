using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class CreateCustomer : ICreateCustomer
    {
        public void ShowCreateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Skapa ny kund");
            Console.WriteLine("=============");

            Console.ReadKey();
        }
    }
}
