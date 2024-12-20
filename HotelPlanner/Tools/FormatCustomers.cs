using Autofac.Features.Indexed;
using HotelManagementLibrary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Tools
{
    public class FormatCustomers
    {
        public static void CreateCustomerEmailUI(int selectedIndex, List<Customer> customers, int index)
        {
            for (index = 0; index < customers.Count; index++)
            {
                if (selectedIndex == index)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"- {customers[index].Email}");
                Console.ResetColor();
            }
            if (selectedIndex == customers.Count)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("- Tillbaka");
            Console.ResetColor();
        }
    }
}
