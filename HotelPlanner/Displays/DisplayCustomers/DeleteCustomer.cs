using Autofac.Features.Indexed;
using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class DeleteCustomer : IDeleteCustomer
    {
        IAppConfiguration _appConfiguration;
        ICustomerService _customerService;

        public bool _running;
        public int _selectedIndex;
        public DeleteCustomer(
            IAppConfiguration appConfiguration,
            ICustomerService customerService
            )
        {
            _appConfiguration = appConfiguration;
            _customerService = customerService;

        }
        public void ShowDeleteCustomer()
        {
            int index = 0;
            _running = true;
            _selectedIndex = 0;

            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Ta bort kund");
                Console.WriteLine("============");

                var options = _appConfiguration.ConfigureOptionBuilder();
                var customers = _customerService.GetAllCustomers(options);

                FormatCustomers.CreateCustomerEmailUI(_selectedIndex, customers, index);
                
                Console.WriteLine("================");

                var keyInput = Console.ReadKey(true);

                _selectedIndex = UserKeyInput.CustomerKeyInput(_selectedIndex, keyInput, customers);

                if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (_selectedIndex == customers.Count)
                    {
                        return;
                    }

                    Console.WriteLine($"Är du säker att du vill ta bort (Y/N) - {customers[_selectedIndex].Email}");
                    Console.Write(">>> ");
                    var answarInput = char.Parse(Console.ReadLine().ToUpper());

                    if (answarInput == 'Y')
                    {
                        Console.WriteLine("Kund tas bort...");
                        _customerService.DeleteCustomer(options, customers[_selectedIndex].Email);
                        Console.WriteLine("Kund är borttagen");
                        Console.WriteLine("================");
                        Console.WriteLine("Tryck valfri tangent för att fortsätta");
                        Console.ReadKey();
                    }
                    else if (answarInput == 'N')
                        return;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktig inmatning. Åtgärden avbröts");
                        Console.ResetColor();
                        Console.WriteLine("================");
                        Console.WriteLine("Tryck valfri tangent för att fortsätta");
                        Console.ReadKey();
                    }
                        

                }
            }

        }
    }
}
