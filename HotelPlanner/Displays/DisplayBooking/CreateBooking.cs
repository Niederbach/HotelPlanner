using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI.Displays.DisplayBooking
{
    public class CreateBooking : ICreateBooking
    {
        IAppConfiguration _appConfiguration;
        ICustomerService _customerService;
        IBookingService _bookingService;
        IRoomService _roomService;

        private bool _running;
        public CreateBooking(
            IAppConfiguration appConfiguration,
            ICustomerService customerService,
            IBookingService bookingService,
            IRoomService roomService)
        {
            _appConfiguration = appConfiguration;
            _customerService = customerService;
            _bookingService = bookingService;
            _roomService = roomService;
        }
        public void ShowCreateBooking()
        {
            var options = _appConfiguration.ConfigureOptionBuilder();

            _running = true;
            while (_running)
            {
                var customers = _customerService.GetAllCustomers(options);
                var customer = ChooseCustomer(options, customers);

                if (_running == false)
                {
                    return;
                }

                var rooms = _roomService.GetAllRooms(options);
                var room = ChooseRoom(options, rooms);

                if (_running == false)
                {
                    return;
                }

                var extraBed = false;
                if (room.RoomSize > 20)
                {
                    extraBed = ChooseExtraBed();
                }

                var numVisitors = ChooseNumVisitors(room);

                var arrvialDate = ChooseArrivalDate();

                var numDays = ChooseNumberOfDays();

                var depatureDate = arrvialDate.AddDays(numDays);

                var price = room.RoomPrice * numDays;

                Console.WriteLine("Är informationen korrekt? (Y/N)");
                Console.WriteLine("=============================");
                Console.WriteLine($"{"Kund".PadRight(12, ' ')} - {customer.Email}");
                Console.WriteLine($"{"Antal gäster".PadRight(12, ' ')} - {numVisitors}");
                Console.WriteLine($"{"Rum".PadRight(12, ' ')} - {room.RoomNumber}, {room.RoomType}");
                Console.WriteLine($"{"Nätter".PadRight(12, ' ')} - {numDays}");
                Console.WriteLine($"{"Extrasäng".PadRight(12, ' ')} - {extraBed}");
                Console.WriteLine($"{"Ankomst".PadRight(12, ' ')} - {arrvialDate}");
                Console.WriteLine($"{"Utcheckning".PadRight(12, ' ')} - {depatureDate}");
                Console.WriteLine($"{"Pris".PadRight(12, ' ')} - {price} kr");
                Console.WriteLine("=============================");
                Console.Write(">>> ");
                var userInput = Console.ReadLine().ToUpper();


                if (userInput == "Y")
                {
                    Console.WriteLine("=======================");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Skapar ny bokning...");
                    Console.ResetColor();

                    _bookingService.CreateBooking(
                                        options,
                                        customer,
                                        room,
                                        numDays,
                                        extraBed,
                                        numVisitors,
                                        arrvialDate,
                                        depatureDate,
                                        price);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ny bokning skapad");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();

                    return;
                }
                else if (userInput == "N")
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogilig inmating, avbryter hadling");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    return;
                }



            }
        }
        public Customer ChooseCustomer(
            DbContextOptionsBuilder<ShabbyChateauDbContext> options,
            List<Customer> customers)
        {

            int selectedIndex = 0;
            int index = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Välj kund");
                Console.WriteLine("==========");

                SelectFormat.CreateCustomerEmailUI(selectedIndex, customers, index);

                Console.WriteLine("==========");

                var keyInput = Console.ReadKey(true);

                selectedIndex = UserKeyInput.CustomerKeyInput(selectedIndex, keyInput, customers);

                if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == customers.Count)
                    {
                        _running = false;
                        return null;
                    }

                    return customers[selectedIndex];
                }
            }
        }
        public Room ChooseRoom(
            DbContextOptionsBuilder<ShabbyChateauDbContext> options,
            List<Room> rooms)
        {

            int selectedIndex = 0;
            int index = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Välj rum");
                Console.WriteLine("=====================");

                SelectFormat.CreateRoomNumberWithRoomTypeUI(selectedIndex, rooms, index);

                Console.WriteLine("=====================");

                var keyInput = Console.ReadKey(true);

                selectedIndex = UserKeyInput.RoomKeyInput(selectedIndex, keyInput, rooms);

                if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == rooms.Count)
                    {
                        _running = false;
                        return null;
                    }

                    return rooms[selectedIndex];
                }
            }
        }
        public int ChooseNumVisitors(Room room)
        {

            int selectedInput = 1;
            int highIndex = 0;
            int lowIndex = 0;
            if (room.RoomType == RoomType.enkelrum)
            {
                highIndex = 2;
                lowIndex = 1;
            }
            else if (room.RoomType == RoomType.dubbelrum)
            {
                highIndex = 3;
                lowIndex = 1;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj antal besökare");
                Console.WriteLine("===================");
                Console.WriteLine($"Antal - {selectedInput}");
                Console.WriteLine("===================");

                var keyInput = Console.ReadKey();

                selectedInput = UserKeyInput.VisistorUserInput(selectedInput, keyInput, highIndex, lowIndex);

                Console.SetCursorPosition(0, 2);
                Console.Write("                 ");
                Console.SetCursorPosition(0, 2);


                if (keyInput.Key == ConsoleKey.Enter)
                {
                    return selectedInput;
                }

            }
        }
        public DateTime ChooseArrivalDate()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj ankomstdatum");
                Console.WriteLine("=================");
                Console.Write(">>> ");
                var arrivaldate = Console.ReadLine();



                if (DateTime.TryParse(arrivaldate, out DateTime arrivalDateTime))
                {
                    if (arrivalDateTime < DateTime.Now)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig datum");
                        Console.ResetColor();
                        Console.WriteLine("=======================");
                        Console.WriteLine("Tryck valfri tangent för att fortsätta");
                        Console.ReadKey();
                        continue;
                    }
                    arrivalDateTime = arrivalDateTime.Date.AddHours(10);
                    return arrivalDateTime;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning, använd rätt format (xxxx-xx-xx)");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
            }
        }
        public int ChooseNumberOfDays()
        {
            int selectedInput = 1;
            int highIndex = 7;
            int lowIndex = 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj antal nätter");
                Console.WriteLine("===================");
                Console.WriteLine($"nätter - {selectedInput}");
                Console.WriteLine("===================");

                var keyInput = Console.ReadKey();

                selectedInput = UserKeyInput.VisistorUserInput(selectedInput, keyInput, highIndex, lowIndex);

                Console.SetCursorPosition(0, 2);
                Console.Write("                 ");
                Console.SetCursorPosition(0, 2);


                if (keyInput.Key == ConsoleKey.Enter)
                {
                    return selectedInput;
                }
            }
        }
        public bool ChooseExtraBed()
        {
            int selectedInput = 0;
            int highIndex = 0;
            int lowIndex = 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Behövs extrasäng?");
                Console.WriteLine("=================");

                if (selectedInput == 0)
                {
                    Console.Write("Svar - ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("JA");
                    Console.ResetColor();

                    Console.WriteLine("NEJ".PadLeft(10, ' '));

                }
                if (selectedInput == 1)
                {
                    Console.Write("Svar - ");

                    Console.WriteLine("JA");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("NEJ".PadLeft(10, ' '));
                    Console.ResetColor();
                }

                var keyInput = Console.ReadKey();

                selectedInput = UserKeyInput.VisistorUserInput(selectedInput, keyInput, highIndex, lowIndex);

                Console.SetCursorPosition(0, 2);
                Console.Write("                 ");
                Console.SetCursorPosition(0, 2);

                if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (selectedInput == 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}
