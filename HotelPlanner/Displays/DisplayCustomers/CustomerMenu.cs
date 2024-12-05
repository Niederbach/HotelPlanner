using ConsoleUI.Tools;
using HotelManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayCustomers;

public class CustomerMenu : ICustomerMenu
{
    private bool _running;
    private int _selectedIndex;
    private List<string> _customerOptions = new List<string>();
    public CustomerMenu()
    {
        _customerOptions.Add("Lägg till kund");
        _customerOptions.Add("Titta på kunder");
        _customerOptions.Add("Ändra kund information");
        _customerOptions.Add("Ta bort kund");
        _customerOptions.Add("Lägg till bortagen kund");
    }
    public void ShowCustomerMenu()
    {
        _selectedIndex = 0;
        _running = true;
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Hantering av Kunder");
            Console.WriteLine("======================");

            MenuFormat.CreateMenuUI(_customerOptions, _selectedIndex);

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
            if (_selectedIndex > _customerOptions.Count)
                _selectedIndex = 0;
        }
        else if (keyInput.Key == ConsoleKey.UpArrow)
        {
            _selectedIndex--;
            if (_selectedIndex < 0)
                _selectedIndex = _customerOptions.Count;
        }
        else if (keyInput.Key == ConsoleKey.Enter)
        {
            if (_selectedIndex == 0)
            {
                
            }
            else if (_selectedIndex == 1)
            {
                
            }
            else if (_selectedIndex == 2)
            {
                
            }
            else if (_selectedIndex == _customerOptions.Count)
                _running = false;

        }
    }
}
