using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ConsoleUI.Displays.DisplayCustomers;

public class ReadCustomer : IReadCustomer
{
    IAppConfiguration _appConfiguration;
    ICustomerService _customerService;

    private bool _running;
    private int _selectedIndex;
    private List<string> _readOptions = new List<string>();
    public ReadCustomer(
        IAppConfiguration appConfiguration,
        ICustomerService customerService)
    {
        _readOptions.Add("Titta på alla kunder");
        _readOptions.Add("Titta på en kund");
        _appConfiguration = appConfiguration;
        _customerService = customerService;
    }

    public void ShowReadCustomer()
    {
        _selectedIndex = 0;
        _running = true;
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Titta på kunder");
            Console.WriteLine("===============");

            ReadFormat.CreateReadUI(_selectedIndex, _readOptions);

            Console.WriteLine("===============");

            var keyInput = Console.ReadKey(true);

            _selectedIndex = UserKeyInput.UserInput(_selectedIndex, keyInput, _readOptions);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (_selectedIndex == 0)
                    ShowAllCustomers();
                else if (_selectedIndex == 1)
                    ShowOneCustomer();
                else if (_selectedIndex == _readOptions.Count)
                    _running = false;
            }
        }
    }
    public void ShowAllCustomers()
    {
        Console.Clear();
        Console.WriteLine("Titta på alla kunder");
        Console.WriteLine("====================");

        var options = _appConfiguration.ConfigureOptionBuilder();
        var customers = _customerService.GetAllCustomers(options);

        int count = 0;
        foreach (var customer in customers)
        {
            Console.WriteLine($"{"ID".PadRight(10, ' ')} - {customer.CustomerId}");
            Console.WriteLine($"{"Namn".PadRight(10, ' ')} - {customer.FirstName}, {customer.LastName}");
            Console.WriteLine($"{"Email".PadRight(10, ' ')} - {customer.Email}");
            Console.WriteLine($"{"Telefon".PadRight(10, ' ')} - {customer.Phone}");
            Console.WriteLine($"{"Adress".PadRight(10, ' ')} - {customer.Address}");
            Console.WriteLine($"{"Stad".PadRight(10, ' ')} - {customer.City}");
            Console.WriteLine($"{"Land".PadRight(10, ' ')} - {customer.Country}");
            Console.WriteLine($"{"Postnummer".PadRight(10, ' ')} - {customer.PostalCode}");

            count++;
            if (count < customers.Count)
                Console.WriteLine("--------------------");
        }

        Console.WriteLine("====================");
        Console.WriteLine("Tryck valfritagent för att gå tillbaka");
        Console.ReadKey();
    }
    public void ShowOneCustomer()
    {
        int index = 0;
        int selectedIndex = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Titta på en kund");
            Console.WriteLine("================");

            var options = _appConfiguration.ConfigureOptionBuilder();
            var customers = _customerService.GetAllCustomers(options);

            SelectFormat.CreateCustomerEmailUI(selectedIndex, customers, index);

            Console.WriteLine("================");

            var keyInput = Console.ReadKey(true);

            selectedIndex = UserKeyInput.CustomerKeyInput(selectedIndex, keyInput, customers);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (selectedIndex == customers.Count)
                {
                    return;
                }

                var customer = _customerService.GetSingleCustomer(options, customers[selectedIndex].Email);

                Console.WriteLine($"{"ID". PadRight(10, ' ')} - {customer.CustomerId}");
                Console.WriteLine($"{"Namn".PadRight(10, ' ')} - {customer.FirstName}, {customer.LastName}");
                Console.WriteLine($"{"Email".PadRight(10, ' ')} - {customer.Email}");
                Console.WriteLine($"{"Telefon".PadRight(10, ' ')} - {customer.Phone}");
                Console.WriteLine($"{"Adress".PadRight(10, ' ')} - {customer.Address}");
                Console.WriteLine($"{"Stad".PadRight(10, ' ')} - {customer.City}");
                Console.WriteLine($"{"Land".PadRight(10, ' ')} - {customer.Country}");
                Console.WriteLine($"{"Postnummer".PadRight(10, ' ')} - {customer.PostalCode}");

                Console.WriteLine("================");
                Console.WriteLine("Tryck valfri tagent för att gå tillbaka");
                Console.ReadKey();

            }
        }
    }
}
