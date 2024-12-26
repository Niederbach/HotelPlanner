using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services;
using HotelManagementLibrary.Services.ServiceInterfaces;

namespace ConsoleUI.Displays.DisplayRoomManagement;

public class ReadRoom : IReadRoom
{
    IAppConfiguration _appConfiguration;
    IRoomService _roomService;

    private int _selectedIndex;
    private bool _running;
    private List<string> _readOptions = new List<string>();
    public ReadRoom(
        IAppConfiguration appConfiguration,
        IRoomService roomService)
    {
        _readOptions.Add("Titta på alla rum");
        _readOptions.Add("Titta på ett rum");
        _appConfiguration = appConfiguration;
        _roomService = roomService;
    }
    public void ShowReadRoom()
    {
        _running = true;
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Titta på rum");
            Console.WriteLine("============");

            ReadFormat.CreateReadUI(_selectedIndex, _readOptions);

            var keyInput = Console.ReadKey(true);

            _selectedIndex = UserKeyInput.UserInput(_selectedIndex, keyInput, _readOptions);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (_selectedIndex == 0)
                {
                    ShowReadAllRooms();
                }
                else if (_selectedIndex == 1)
                {
                    ShowReadOneRoom();
                }
                else if (_selectedIndex == _readOptions.Count)
                    _running = false;
            }
        }
    }
    public void ShowReadOneRoom()
    {
        int index = 0;
        int selectedIndex = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Titta på en kund");
            Console.WriteLine("================");

            var options = _appConfiguration.ConfigureOptionBuilder();
            var rooms = _roomService.GetAllRooms(options);

            SelectFormat.CreateRoomNumberUI(selectedIndex, rooms, index);

            Console.WriteLine("================");

            var keyInput = Console.ReadKey(true);

            selectedIndex = UserKeyInput.RoomKeyInput(selectedIndex, keyInput, rooms);

            if (keyInput.Key == ConsoleKey.Enter)
            {
                if (selectedIndex == rooms.Count)
                {
                    return;
                }

                var room = _roomService.GetSingelRoom(options, rooms[selectedIndex].RoomNumber);

                Console.WriteLine($"{"ID".PadRight(11, ' ')} - {room.RoomId}");
                Console.WriteLine($"{"Rumsnummer".PadRight(11, ' ')} - {room.RoomNumber}");
                Console.WriteLine($"{"Rumspris".PadRight(11, ' ')} - {room.RoomPrice} kr/natt");
                Console.WriteLine($"{"Rumstorlek".PadRight(11, ' ')} - {room.RoomSize} kvm");
                Console.WriteLine($"{"Extra säng".PadRight(11, ' ')} - {room.HasExtraBed}");
                Console.WriteLine($"{"Rums typ".PadRight(11, ' ')} - {room.RoomType}");


                Console.WriteLine("================");
                Console.WriteLine("Tryck valfri tagent för att gå tillbaka");
                Console.ReadKey();

            }
        }
    }
    public void ShowReadAllRooms()
    {
        Console.Clear();
        Console.WriteLine("Titta på alla rum");
        Console.WriteLine("=================");

        var options = _appConfiguration.ConfigureOptionBuilder();
        var rooms = _roomService.GetAllRooms(options);

        int count = 0;
        foreach (var room in rooms)
        {
            Console.WriteLine($"{"ID".PadRight(11, ' ')} - {room.RoomId}");
            Console.WriteLine($"{"Rumsnummer".PadRight(11, ' ')} - {room.RoomNumber}");
            Console.WriteLine($"{"Rumspris".PadRight(11, ' ')} - {room.RoomPrice} kr/natt");
            Console.WriteLine($"{"Rumstorlek".PadRight(11, ' ')} - {room.RoomSize} kvm");
            Console.WriteLine($"{"Extra säng".PadRight(11, ' ')} - {room.HasExtraBed}");
            Console.WriteLine($"{"Rums typ".PadRight(11, ' ')} - {room.RoomType}");


            count++;
            if (count < rooms.Count)
                Console.WriteLine("--------------------");
        }

        Console.WriteLine("=================");
        Console.WriteLine("Tryck valfritagent för att gå tillbaka");
        Console.ReadKey();
    }
}
