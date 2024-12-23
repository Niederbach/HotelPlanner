using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Services;
using HotelManagementLibrary.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement;

public class DeleteRoom : IDeleteRoom
{
    IAppConfiguration _appConfiguration;
    IRoomService _roomService;

    private int _selectedIndex;
    private bool _running;
    public DeleteRoom(
        IAppConfiguration appConfiguration, 
        IRoomService roomService)
    {
        _appConfiguration = appConfiguration;
        _roomService = roomService;
    }
    public void ShowDeleteRoom()
    {
        _running = true;
        int index = 0;
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Ta bort rum");
            Console.WriteLine("===========");

            var options = _appConfiguration.ConfigureOptionBuilder();
            var rooms = _roomService.GetAllRooms(options);

            SelectFormat.CreateRoomNumberUI(_selectedIndex, rooms, index);

            Console.WriteLine("===========");

            var keyInput = Console.ReadKey(true);

            _selectedIndex = UserKeyInput.RoomKeyInput(_selectedIndex, keyInput, rooms);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (_selectedIndex == rooms.Count)
                {
                    return;
                }

                Console.WriteLine($"Är du säker att du vill ta bort (Y/N) - Rum {rooms[_selectedIndex].RoomNumber}");
                Console.Write(">>> ");
                var answarInput = char.Parse(Console.ReadLine().ToUpper());

                if (answarInput == 'Y')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rum tas bort...");
                    Console.ResetColor();

                    _roomService.DeleteRoom(options, rooms[_selectedIndex].RoomNumber);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rum är borttagen");
                    Console.ResetColor();
                    Console.WriteLine("================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                }
                else if (answarInput == 'N')
                    return;
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
