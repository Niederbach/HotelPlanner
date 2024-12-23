using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Services.ServiceInterfaces;
using System.Text.RegularExpressions;

namespace ConsoleUI.Displays.DisplayCustomers
{
    public class CreateCustomer : ICreateCustomer
    {
        IAppConfiguration _appConfiguration;
        ICustomerService _customerService;

        private bool _running;
        public CreateCustomer(
            IAppConfiguration appConfiguration,
            ICustomerService customerService)
        {
            _appConfiguration = appConfiguration;
            _customerService = customerService;
        }
        public void ShowCreateCustomer()
        {
            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Skapa ny kund");
                Console.WriteLine("=============");

                var firstName = CreateFirstName();
                var lastName = CreateLastName();
                var email = CreateEmail();
                var phoneNumber = CreatePhoneNumber();
                var address = CreateAddress();
                var city = CreateCity();
                var country = CreateCountry();
                var postalcode = CreatePostalCode();

                Console.WriteLine("-------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Lägger till ny kund...");
                Console.WriteLine("Kund sparad");
                Console.ResetColor();

                var options = _appConfiguration.ConfigureOptionBuilder();
                _customerService.CreateCustomer(
                    options,
                    firstName,
                    lastName,
                    email,
                    phoneNumber,
                    address,
                    city,
                    country,
                    postalcode);

                Console.WriteLine("=============");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");

                _running = false;
            }
        }
        public string CreateFirstName()
        {
            while (true)
            {
                Console.Write("Skriv in förnamn: ");
                var firstName = Console.ReadLine();

                firstName = StringManipulator.CapitalizeFirstLetter(firstName);

                if (string.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej vara blankt");
                    continue;
                }
                else if (StringManipulator.ContainsInteger(firstName))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej innehålla nummer");
                    continue;
                }

                return firstName;
            }
        }
        public string CreateLastName()
        {
            while (true)
            {
                Console.Write("Skriv in efternamn: ");
                var lastName = Console.ReadLine();

                lastName = StringManipulator.CapitalizeFirstLetter(lastName);

                if (string.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej vara blankt");
                    continue;
                }
                else if (StringManipulator.ContainsInteger(lastName))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej innehålla nummer");
                    continue;
                }

                return lastName;
            }
        }
        public string CreateEmail()
        {
            while (true)
            {
                Console.Write("Skriv in email: ");
                var email = Console.ReadLine();

                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$";

                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig email format");
                    Console.ResetColor();
                    continue;
                }

                return email;
            }
        }
        public string CreatePhoneNumber()
        {
            while (true)
            {
                Console.Write("Skriv in telefonnummer: ");
                var phoneNumber = Console.ReadLine();

                if (int.TryParse(phoneNumber, out int resualt))
                {
                    return phoneNumber;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning, Måste enbart innehålla nummer");
                    continue;
                }
            }
        }
        public string CreateAddress()
        {
            while (true)
            {
                Console.Write("Skriv in adress: ");
                var address = Console.ReadLine();

                if (string.IsNullOrEmpty(address))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej vara blankt");
                    continue;
                }

                return address;
            }
        }
        public string CreateCity()
        {
            while (true)
            {
                Console.Write("Skriv in stad: ");
                var city = Console.ReadLine();

                city = StringManipulator.CapitalizeFirstLetter(city);

                if (string.IsNullOrEmpty(city))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej vara blankt");
                    continue;
                }
                else if (StringManipulator.ContainsInteger(city))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej innerhålla nummer");
                    continue;
                }

                return city;
            }
        }
        public string CreateCountry()
        {
            while (true)
            {
                Console.Write("Skriv in land: ");
                var country = Console.ReadLine();

                country = StringManipulator.CapitalizeFirstLetter(country);

                if (string.IsNullOrEmpty(country))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej vara blankt");
                    continue;
                }
                else if (StringManipulator.ContainsInteger(country))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej innerhålla nummer");
                    continue;
                }

                return country;
            }
        }
        public string CreatePostalCode()
        {
            while (true)
            {
                Console.Write("Skriv in postnummer: ");
                var postalCode = Console.ReadLine();

                if (string.IsNullOrEmpty(postalCode))
                {
                    Console.WriteLine("Ogiltig inmatning, får ej vara blankt");
                    continue;
                }

                return postalCode;
            }

        }

    }
}
