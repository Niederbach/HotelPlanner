using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.Displays.DisplayInvoice.InvoiceInterfaces;
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
    IInvoiceMenu _invoice;
    private int _selectedIndex = 0;
    private bool _running = true;
    private List<string> _mainMenuOptions = new List<string>();
    public MainMenu(
        IBookingMenu booking, 
        ICustomerMenu customer, 
        IRoomMenu room, 
        IInvoiceMenu invoiceMenu)
    {
        _mainMenuOptions.Add("Hantera Kunder");
        _mainMenuOptions.Add("Hantera Bokningar");
        _mainMenuOptions.Add("Hantera rum");
        _mainMenuOptions.Add("Hantera fakturor");
        _booking = booking;
        _customer = customer;
        _room = room;
        _invoice = invoiceMenu;
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
            else if (_selectedIndex == 3)
            {
                _invoice.ShowInvoiceMenu();
            }
            else if (_selectedIndex == _mainMenuOptions.Count)
                _running = false;

        }
    }
}
