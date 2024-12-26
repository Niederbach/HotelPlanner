using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class UpdateRoom : IUpdateRoom
    {
        IAppConfiguration _appConfiguration;
        IRoomService _roomService;

        private int _selectedIndex;
        private bool _running;
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
            while (true)
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
                    ShowSelectedRoom(rooms[_selectedIndex], options);
                }
            }
        }
        public void ShowSelectedRoom(Room room, DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {
            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine($"Ändrar på rum - Rum {room.RoomNumber}");
                Console.WriteLine("=======================");

                Console.WriteLine($"1. {"Rumsnummer".PadRight(11, ' ')} - {room.RoomNumber}");
                Console.WriteLine($"2. {"Rumspris".PadRight(11, ' ')} - {room.RoomPrice} kr/natt");
                Console.WriteLine($"3. {"Rumstorlek".PadRight(11, ' ')} - {room.RoomSize} kvm");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Tillbaka");
                Console.ResetColor();

                Console.WriteLine("=======================");
                Console.WriteLine("Välj infromationen du vill ändra");
                Console.Write(">>> ");
                var stringInput = Console.ReadLine();

                if (int.TryParse(stringInput, out int selectedInput))
                {
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                if (selectedInput < 0 || selectedInput > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                if (selectedInput == 1)
                {
                    UpdateRoomNumber(options, selectedInput, room);
                }
                else if (selectedInput == 2)
                {
                    UpdateRoomPrice(options, selectedInput, room);
                }
                else if (selectedInput == 3)
                {
                    UpdateRoomSize(options, selectedInput, room);
                }
                else if (selectedInput == 0)
                    return;

            }

        }
        public void UpdateRoomNumber(
            DbContextOptionsBuilder<ShabbyChateauDbContext> options,
            int selectedInput,
            Room room)
        {
            while (true)
            {
                Console.Write("Skriv in nytt Rumsnummer: ");
                var newRoomNumber = Console.ReadLine();

                if (int.TryParse(newRoomNumber, out int input))
                {
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning, Måste vara ett nummer");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                if (_roomService.RoomNumberExist(options, newRoomNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rums numret finns redan");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                if (newRoomNumber == "0")
                {
                    _running = false;
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Rums nummer ändras...");
                Console.ResetColor();

                _roomService.UpdateRoom(options, room, newRoomNumber, selectedInput);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Rums nummer ändrat");
                Console.ResetColor();

                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                _running = false;
                return;
            }
        }
        public void UpdateRoomPrice(
            DbContextOptionsBuilder<ShabbyChateauDbContext> options,
            int selectedInput,
            Room room)
        {
            while (_running)
            {
                Console.Write("Skriv in nytt rumspris: ");
                var newRoomPrice = Console.ReadLine();

                if (decimal.TryParse(newRoomPrice, out decimal input))
                {
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning, Måste vara ett nummer");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Rumspris ändras...");
                Console.ResetColor();

                _roomService.UpdateRoom(options, room, newRoomPrice, selectedInput);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Rumspris ändrat");
                Console.ResetColor();

                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                _running = false;
                return;
            }
        }
        public void UpdateRoomSize(
            DbContextOptionsBuilder<ShabbyChateauDbContext> options,
            int selectedInput,
            Room room)
        {
            while (_running)
            {
                Console.Write("Skriv in nytt rumstorlek: ");
                var newRoomSize = Console.ReadLine();

                if (double.TryParse(newRoomSize, out double input))
                {
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning, Måste vara ett nummer");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("det här kan ändra den här informationen - extrasäng");
                Console.WriteLine("Vill du göra ändringen? (Y/N): ");
                var choiceInput = Console.ReadLine().ToUpper();

                if (choiceInput == "Y")
                {
                }
                else if (choiceInput == "N")
                {
                    _running = false;
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning");
                    Console.ResetColor();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta");
                    Console.ReadKey();
                    continue;
                }


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Rumstorlek ändras...");
                Console.ResetColor();

                _roomService.UpdateRoom(options, room, newRoomSize, selectedInput);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Rumstorlek ändrat");
                Console.ResetColor();

                Console.WriteLine("=======================");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();

                _running = false;
                return;
            }
        }
    }
}
