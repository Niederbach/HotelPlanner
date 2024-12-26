using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class RoomMenu : IRoomMenu
    {
        ICreateRoom _createRoom;
        IReadRoom _readRoom;
        IUpdateRoom _updateRoom;
        IDeleteRoom _deleteRoom;
        IRecoverRoom _recoverRoom;

        private bool _running;
        private int _selectedIndex;
        private List<string> _roomOptions = new List<string>();
        public RoomMenu(
            ICreateRoom createRoom, 
            IReadRoom readRoom, 
            IUpdateRoom updateRoom, 
            IDeleteRoom deleteRoom, 
            IRecoverRoom recoverRoom)
        {
            _roomOptions.Add("Lägg till rum");
            _roomOptions.Add("Titta på rum");
            _roomOptions.Add("Ändra rum information");
            _roomOptions.Add("Ta bort rum");
            _roomOptions.Add("Lägg till borttaget rum");
            _createRoom = createRoom;
            _readRoom = readRoom;
            _updateRoom = updateRoom;
            _deleteRoom = deleteRoom;
            _recoverRoom = recoverRoom;
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
                    _createRoom.ShowCreateRoom();
                }
                else if (_selectedIndex == 1)
                {
                    _readRoom.ShowReadRoom();
                }
                else if (_selectedIndex == 2)
                {
                    _updateRoom.ShowUpdateRoom();
                }
                else if (_selectedIndex == 3)
                {
                    _deleteRoom.ShowDeleteRoom();
                }
                else if (_selectedIndex == 4)
                {
                    _recoverRoom.ShowRecoverRoom();
                }
                else if (_selectedIndex == _roomOptions.Count)
                    _running = false;

            }
        }
    }
}
