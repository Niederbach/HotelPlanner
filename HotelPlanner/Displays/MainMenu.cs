using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays;

public class MainMenu : IMenu
{
    private int _selectedIndex = 0;
    private bool _running = true;
    private List<string> _mainMenuOptions = new List<string>();
    public MainMenu()
    {
        _mainMenuOptions.Add("Kunder");
        _mainMenuOptions.Add("Bokningar");
        _mainMenuOptions.Add("Hantera rum");
    }
    public void ShowMenu()
    {
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("The Shabby Chateau");
            Console.WriteLine("==================");

            for (int i = 0; i < _mainMenuOptions.Count; i++)
            {
                if (_selectedIndex == i)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"- {_mainMenuOptions[i]}");
                Console.ResetColor();
            }
            if (_selectedIndex == _mainMenuOptions.Count)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("- Avsluta");
            Console.ResetColor();
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
    }
}
