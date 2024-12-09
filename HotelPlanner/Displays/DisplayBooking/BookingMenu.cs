using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.Tools;

namespace ConsoleUI.Displays.DisplayBooking;

public class BookingMenu : IBookingMenu
{
    IDisplayCreateBooking _createBooking;
    private bool _running;
    private int _selectedIndex = 0;
    private List<string> _bookingOptions = new List<string>();
    public BookingMenu(IDisplayCreateBooking createBooking)
    {
        _bookingOptions.Add("Lägg till boking");
        _bookingOptions.Add("Titta på bokingar");
        _bookingOptions.Add("Ändra på bokning");
        _bookingOptions.Add("Ta bort bokning");
        _createBooking = createBooking;
    }

    public void ShowBookingMenu()
    {
        _selectedIndex = 0;
        _running = true;
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Hantering av bokningar");
            Console.WriteLine("======================");

            MenuFormat.CreateMenuUI(_bookingOptions, _selectedIndex);

            Console.WriteLine("======================");

            var keyInput = Console.ReadKey(true);
            UserInput(keyInput);
        }

    }
    public void UserInput(ConsoleKeyInfo keyInput)
    {
        if (keyInput.Key == ConsoleKey.DownArrow)
        {
            _selectedIndex++;
            if (_selectedIndex > _bookingOptions.Count)
                _selectedIndex = 0;
        }
        else if (keyInput.Key == ConsoleKey.UpArrow)
        {
            _selectedIndex--;
            if (_selectedIndex < 0)
                _selectedIndex = _bookingOptions.Count;
        }
        else if (keyInput.Key == ConsoleKey.Enter)
        {
            if (_selectedIndex == 0)
            {
                _createBooking.CreateBooking();
            }
            else if (_selectedIndex == 1)
            {

            }
            else if (_selectedIndex == 2)
            {

            }
            else if (_selectedIndex == _bookingOptions.Count)
                _running = false;

        }
    }
}
