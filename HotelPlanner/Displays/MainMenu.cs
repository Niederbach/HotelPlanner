using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays;

public class MainMenu : IMenu
{
    IBookingMenu _booking;
    ICustomerMenu _customer;
    IRoomMenu _room;
    private int _selectedIndex = 0;
    private bool _running = true;
    private List<string> _mainMenuOptions = new List<string>();
    public MainMenu(IBookingMenu booking, ICustomerMenu customer, IRoomMenu room)
    {
        _mainMenuOptions.Add("Kunder");
        _mainMenuOptions.Add("Bokningar");
        _mainMenuOptions.Add("Hantera rum");
        _booking = booking;
        _customer = customer;
        _room = room;
    }
    public void ShowMenu()
    {
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("The Shabby Chateau");
            Console.WriteLine("==================");

            MenuFormat.CreateMenuUI(_mainMenuOptions, _selectedIndex);

            Console.WriteLine("==================");


            var keyInput = Console.ReadKey(true);

            UserInput(keyInput);
        }
    }
    public void UserInput(ConsoleKeyInfo keyInput)
    {
        if (keyInput.Key == ConsoleKey.DownArrow)
        {
            _selectedIndex++;
            if (_selectedIndex > _mainMenuOptions.Count)
                _selectedIndex = 0;
        }
        else if (keyInput.Key == ConsoleKey.UpArrow)
        {
            _selectedIndex--;
            if (_selectedIndex < 0)
                _selectedIndex = _mainMenuOptions.Count;
        }
        else if (keyInput.Key == ConsoleKey.Enter)
        {
            if (_selectedIndex == 0)
            {
                _customer.ShowCustomerMenu();
            }
            else if (_selectedIndex == 1)
            {
                _booking.ShowBookingMenu();
            }
            else if (_selectedIndex == 2)
            {
                _room.ShowRoomManagementMenu();
            }
            else if (_selectedIndex == _mainMenuOptions.Count)
                _running = false;

        }
    }
}
