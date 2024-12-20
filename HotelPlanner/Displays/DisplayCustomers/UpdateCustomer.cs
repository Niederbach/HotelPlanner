using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class UpdateCustomer : IUpdateCustomer
    {
        IAppConfiguration _appConfiguration;
        ICustomerService _customerService;

        public bool _running;
        public int _selectedIndex;
        public UpdateCustomer(
            IAppConfiguration appConfiguration,
            ICustomerService customerService
            )
        {
            _appConfiguration = appConfiguration;
            _customerService = customerService;

        }
        public void ShowUpdateCustomer()
        {
            int index = 0;
            _selectedIndex = 0;
            _running = true;

            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Ändra på befintlig kund");
                Console.WriteLine("=======================");

                var options = _appConfiguration.ConfigureOptionBuilder();
                var customers = _customerService.GetAllCustomers(options);

                FormatCustomers.CreateCustomerEmailUI(_selectedIndex, customers, index);

                Console.WriteLine("=======================");

                var keyInput = Console.ReadKey(true);

                _selectedIndex = UserKeyInput.CustomerKeyInput(_selectedIndex, keyInput, customers);

                if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (_selectedIndex == customers.Count)
                    {
                        return;
                    }
                    ShowSelectedCustomer(customers[_selectedIndex]);
                }
            }
        }
        public void ShowSelectedCustomer(Customer customer)
        {
            int index = 1;
            int selectedIndex = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Ändrar på kunden - {customer.Email}");
                Console.WriteLine("=======================");



                Console.ReadKey();
            }
        }
    }
}
