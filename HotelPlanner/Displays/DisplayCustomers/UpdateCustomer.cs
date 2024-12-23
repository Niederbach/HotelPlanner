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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers;

public class UpdateCustomer : IUpdateCustomer
{
    IAppConfiguration _appConfiguration;
    ICustomerService _customerService;

    private bool _running;
    private int _selectedIndex;
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

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Ändrar på kunden - {customer.Email}");
            Console.WriteLine("=======================");

            Console.WriteLine($"1. {"Förnamn".PadRight(10, ' ')} - {customer.FirstName}");
            Console.WriteLine($"2. {"Efternamn".PadRight(10, ' ')} - {customer.LastName}");
            Console.WriteLine($"3. {"Email".PadRight(10, ' ')} - {customer.Email}");
            Console.WriteLine($"4. {"Telefon".PadRight(10, ' ')} - {customer.Phone}");
            Console.WriteLine($"5. {"Adress".PadRight(10, ' ')} - {customer.Address}");
            Console.WriteLine($"6. {"Stad".PadRight(10, ' ')} - {customer.City}");
            Console.WriteLine($"7. {"Land".PadRight(10, ' ')} - {customer.Country}");
            Console.WriteLine($"8. {"Postnummer".PadRight(10, ' ')} - {customer.PostalCode}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Tillbaka");
            Console.ResetColor();

            Console.WriteLine("=======================");
            Console.WriteLine("Välj infromationen du vill ändra");
            Console.Write(">>> ");
            var stringInput = Console.ReadLine();

            if (int.TryParse(stringInput, out int input))
            {
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();
                continue;
            }

            if (input < 0 || input > 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();
                continue;
            }

            var options = _appConfiguration.ConfigureOptionBuilder();


            if (input == 1)
            {
                Console.WriteLine("Skriv in nytt förnamn");
                Console.Write(">>> ");
                var newFirstName = Console.ReadLine();

                newFirstName = StringManipulator.CapitalizeFirstLetter(newFirstName);

                if (string.IsNullOrEmpty(newFirstName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                else if (StringManipulator.ContainsInteger(newFirstName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ändrar på förnamn...");
                Console.ResetColor();

                _customerService.UpdateCustomer(options, newFirstName, customer, input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Förnamn ändrat");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                return;
            }
            else if (input == 2)
            {
                Console.WriteLine("Skriv in nytt efternamn");
                Console.Write(">>> ");
                var newLastName = Console.ReadLine();

                newLastName = StringManipulator.CapitalizeFirstLetter(newLastName);

                if (string.IsNullOrEmpty(newLastName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                else if (StringManipulator.ContainsInteger(newLastName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ändrar på efternamn...");
                Console.ResetColor();

                _customerService.UpdateCustomer(options, newLastName, customer, input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Efternamn ändrat");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                return;
            }
            else if (input == 3)
            {
                Console.WriteLine("Skriv in ny email");
                Console.Write(">>> ");
                var newEmail = Console.ReadLine();

                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$";

                Regex regex = new Regex(pattern);

                if (regex.IsMatch(newEmail))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ändrar på email...");
                    Console.ResetColor();

                    _customerService.UpdateCustomer(options, newEmail, customer, input);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("email ändrat");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();

                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig email format");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
            }
            else if (input == 4)
            {
                Console.WriteLine("Skriv in nytt telefonnummer");
                Console.Write(">>> ");
                var newPhoneNumber = Console.ReadLine();

                if (int.TryParse(newPhoneNumber, out int resualt))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ändrar på telefonnummer...");
                    Console.ResetColor();

                    _customerService.UpdateCustomer(options, newPhoneNumber, customer, input);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Telefonnummer ändrat");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();

                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
            }
            else if (input == 5)
            {
                Console.WriteLine("Skriv in ny adress");
                Console.Write(">>> ");
                var newAddress = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ändrar på adress...");
                Console.ResetColor();

                _customerService.UpdateCustomer(options, newAddress, customer, input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Adress ändrad");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                return;
            }
            else if (input == 6)
            {
                Console.WriteLine("Skriv in ny stad");
                Console.Write(">>> ");
                var newCity = Console.ReadLine();

                newCity = StringManipulator.CapitalizeFirstLetter(newCity);

                if (string.IsNullOrEmpty(newCity))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                else if (StringManipulator.ContainsInteger(newCity))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ändrar på stad...");
                Console.ResetColor();

                _customerService.UpdateCustomer(options, newCity, customer, input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Stad ändrad");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                return;
            }
            else if (input == 7)
            {
                Console.WriteLine("Skriv in nytt land");
                Console.Write(">>> ");
                var newCountry = Console.ReadLine();

                newCountry = StringManipulator.CapitalizeFirstLetter(newCountry);

                if (string.IsNullOrEmpty(newCountry))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                else if (StringManipulator.ContainsInteger(newCountry))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ändrar på land...");
                Console.ResetColor();

                _customerService.UpdateCustomer(options, newCountry, customer, input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Land ändrad");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                return;
            }
            else if (input == 8)
            {
                Console.WriteLine("Skriv in nytt postnummer");
                Console.Write(">>> ");
                var newPostalCode = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ändrar på postnummer...");
                Console.ResetColor();

                _customerService.UpdateCustomer(options, newPostalCode, customer, input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Postnummer ändrat");
                Console.ResetColor();
                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();
            }
            else if (input == 0)
                return;
        }
    }
}
