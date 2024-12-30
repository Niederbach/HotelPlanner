using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Services.ServiceInterfaces;

namespace ConsoleUI.Displays.DisplayBooking;

public class ReadBooking : IReadBooking
{
    IAppConfiguration _appConfiguration;
    IBookingService _bookingService;

    private int _selectedIndex;
    private bool _running;
    private List<string> _readOptions = new List<string>();
    public ReadBooking(
        IAppConfiguration appConfiguration,
        IBookingService bookingService)
    {
        _readOptions.Add("Titta på alla bokningar");
        _readOptions.Add("Titta på en bokning");
        _appConfiguration = appConfiguration;
        _bookingService = bookingService;
    }
    public void ShowReadBooking()
    {
        _running = true;
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Titta på befintliga bokningar");
            Console.WriteLine("=============================");

            ReadFormat.CreateReadUI(_selectedIndex, _readOptions);

            var keyInput = Console.ReadKey(true);

            _selectedIndex = UserKeyInput.UserInput(_selectedIndex, keyInput, _readOptions);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (_selectedIndex == 0)
                {
                    ShowReadAllBookings();
                }
                else if (_selectedIndex == 1)
                {
                    ShowReadOneBooking();
                }
                else if (_selectedIndex == _readOptions.Count)
                    _running = false;
            }
        }
    }
    public void ShowReadAllBookings()
    {
        Console.Clear();
        Console.WriteLine("Titta på alla bokningar");
        Console.WriteLine("=================");

        var options = _appConfiguration.ConfigureOptionBuilder();
        var bookings = _bookingService.GetAllBookings(options);

        int count = 0;
        foreach (var booking in bookings)
        {
            Console.WriteLine($"{"Kund ID".PadRight(12, ' ')} - {booking.customerId}");
            Console.WriteLine($"{"Antal gäster".PadRight(12, ' ')} - {booking.NumVisitors}");
            Console.WriteLine($"{"Rum ID".PadRight(12, ' ')} - {booking.RoomId}");
            Console.WriteLine($"{"Extrasäng".PadRight(12, ' ')} - {booking.extraBed}");
            Console.WriteLine($"{"Ankomst".PadRight(12, ' ')} - {booking.ArrivalDate}");
            Console.WriteLine($"{"Utcheckning".PadRight(12, ' ')} - {booking.DepartureDate}");
            Console.WriteLine($"{"Pris".PadRight(12, ' ')} - {booking.Price} kr");


            count++;
            if (count < bookings.Count)
                Console.WriteLine("--------------------");
        }

        Console.WriteLine("=================");
        Console.WriteLine("Tryck valfritagent för att gå tillbaka");
        Console.ReadKey();
    }
    public void ShowReadOneBooking()
    {
        int index = 0;
        int selectedIndex = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Titta på en bokning");
            Console.WriteLine("================");

            var options = _appConfiguration.ConfigureOptionBuilder();
            var bookings = _bookingService.GetAllBookings(options);

            SelectFormat.CreateBookingIdUI(selectedIndex, bookings, index);

            Console.WriteLine("================");

            var keyInput = Console.ReadKey(true);

            selectedIndex = UserKeyInput.BookingKeyInput(selectedIndex, keyInput, bookings);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (selectedIndex == bookings.Count)
                {
                    return;
                }

                var booking = _bookingService.GetSingleBooking(options, bookings[selectedIndex].BookingId);

                Console.WriteLine($"{"Kund ID".PadRight(12, ' ')} - {booking.customerId}");
                Console.WriteLine($"{"Antal gäster".PadRight(12, ' ')} - {booking.NumVisitors}");
                Console.WriteLine($"{"Rum ID".PadRight(12, ' ')} - {booking.RoomId}");
                Console.WriteLine($"{"Extrasäng".PadRight(12, ' ')} - {booking.extraBed}");
                Console.WriteLine($"{"Ankomst".PadRight(12, ' ')} - {booking.ArrivalDate}");
                Console.WriteLine($"{"Utcheckning".PadRight(12, ' ')} - {booking.DepartureDate}");
                Console.WriteLine($"{"Pris".PadRight(12, ' ')} - {booking.Price} kr");


                Console.WriteLine("================");
                Console.WriteLine("Tryck valfri tagent för att gå tillbaka");
                Console.ReadKey();

            }
        }
    }
}
