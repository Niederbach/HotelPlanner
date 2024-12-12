using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class RecoverCustomer : IRecoverCustomer
    {
        public void ShowRecoverCustomer()
        {
            Console.Clear();
            Console.WriteLine("borttagna kunder");
            Console.WriteLine("================");

            Console.ReadKey();
        }
    }
}
