using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Services.ServiceInterfaces;

namespace ConsoleUI.Displays.DisplayBooking;

public class DeleteBooking : IDeleteBooking
{
    IAppConfiguration _appConfiguration;
    IBookingService _bookingService;

    private int _selectedIndex;
    private bool _running;
    public DeleteBooking(
        IAppConfiguration appConfiguration,
        IBookingService bookingService)
    {
        _appConfiguration = appConfiguration;
        _bookingService = bookingService;
    }
    public void ShowDeleteBooking()
    {
        int index = 0;
        _running = true;
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Ta bort bokning");
            Console.WriteLine("===============");

            var options = _appConfiguration.ConfigureOptionBuilder();
            var bookings = _bookingService.GetAllBookings(options);

            SelectFormat.CreateBookingIdUI(_selectedIndex, bookings, index);

            Console.WriteLine("================");

            var keyInput = Console.ReadKey(true);

            _selectedIndex = UserKeyInput.BookingKeyInput(_selectedIndex, keyInput, bookings);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (_selectedIndex == bookings.Count)
                {
                    return;
                }

                var booking = _bookingService.GetSingleBooking(options, bookings[_selectedIndex].BookingId);

                Console.Clear();
                Console.WriteLine("Är du säker att du vill ta bort bokningen? (Y/N)");
                Console.WriteLine("================");
                Console.WriteLine($"{"Kund ID".PadRight(12, ' ')} - {booking.customerId}");
                Console.WriteLine($"{"Antal gäster".PadRight(12, ' ')} - {booking.NumVisitors}");
                Console.WriteLine($"{"Rum ID".PadRight(12, ' ')} - {booking.RoomId}");
                Console.WriteLine($"{"Extrasäng".PadRight(12, ' ')} - {booking.extraBed}");
                Console.WriteLine($"{"Ankomst".PadRight(12, ' ')} - {booking.ArrivalDate}");
                Console.WriteLine($"{"Utcheckning".PadRight(12, ' ')} - {booking.DepartureDate}");
                Console.WriteLine($"{"Pris".PadRight(12, ' ')} - {booking.Price} kr");
                Console.WriteLine("================");
                Console.Write(">>> ");
                var answarInput = Console.ReadLine().ToUpper();

                if (answarInput == "Y")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tar bort bokning");
                    Console.ResetColor();

                    _bookingService.DeleteBooking(options, booking.BookingId);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bokning borttagen");
                    Console.ResetColor();

                    Console.WriteLine("================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();

                    return;
                }
                else if (answarInput == "N")
                {
                    return;
                }
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
