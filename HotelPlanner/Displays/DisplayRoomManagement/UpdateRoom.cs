using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class UpdateRoom : IUpdateRoom
    {
        IAppConfiguration _appConfiguration;
        IRoomService _roomService;

        private int _selectedIndex;
        public UpdateRoom(
            IAppConfiguration appConfiguration, 
            IRoomService roomService)
        {
            _appConfiguration = appConfiguration;
            _roomService = roomService;
        }
        public void ShowUpdateRoom()
        {
            int index = 0;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Updatera befintligt rum");
                Console.WriteLine("=======================");

                var options = _appConfiguration.ConfigureOptionBuilder();
                var rooms = _roomService.GetAllRooms(options);

                SelectFormat.CreateRoomNumberUI(_selectedIndex, rooms, index);

                Console.WriteLine("=======================");

                var keyInput = Console.ReadKey(true);

                _selectedIndex = UserKeyInput.RoomKeyInput(_selectedIndex, keyInput, rooms);

                if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (_selectedIndex == rooms.Count)
                    {
                        return;
                    }
                    ShowSelectedRoom(rooms[_selectedIndex]);
                }
            }
        }
        public void ShowSelectedRoom(Room room)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Ändrar på rum - Rum {room.RoomNumber}");
                Console.WriteLine("=======================");

                Console.ReadKey();
            }
            
        }
    }
}
