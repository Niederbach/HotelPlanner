﻿using ConsoleUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class RoomMenu : IRoomMenu
    {
        private bool _running;
        private int _selectedIndex;
        private List<string> _roomOptions = new List<string>();
        public RoomMenu()
        {
            _roomOptions.Add("Lägg till rum");
            _roomOptions.Add("titta på rum");
            _roomOptions.Add("ändra rum information");
            _roomOptions.Add("Ta bort rum");
            _roomOptions.Add("Lägg till bortaget rum");
        }
        public void ShowRoomManagementMenu()
        {
            _selectedIndex = 0;
            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Hantering av Rum");
                Console.WriteLine("======================");

                MenuFormat.CreateMenuUI(_roomOptions, _selectedIndex);

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
                if (_selectedIndex > _roomOptions.Count)
                    _selectedIndex = 0;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex < 0)
                    _selectedIndex = _roomOptions.Count;
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
                else if (_selectedIndex == _roomOptions.Count)
                    _running = false;

            }
        }
    }
}
