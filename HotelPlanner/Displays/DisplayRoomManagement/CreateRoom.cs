using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.RootInterfaces;
using ConsoleUI.Tools;
using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ConsoleUI.Displays.DisplayRoomManagement;

public class CreateRoom : ICreateRoom
{
    IAppConfiguration _appConfiguration;
    IRoomService _roomService;

    public CreateRoom(
        IAppConfiguration appConfiguration,
        IRoomService roomService)
    {
        _appConfiguration = appConfiguration;
        _roomService = roomService;
    }
    public void ShowCreateRoom()
    {
        Console.Clear();

        Console.WriteLine("Lägg till rum");
        Console.WriteLine("=============");

        var options = _appConfiguration.ConfigureOptionBuilder();

        var roomNumber = CreateRoomNumber(options);
        var roomPrice = CreateRoomPrice();
        var roomSize = CreateRoomSize();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Skapar nytt rum...");
        Console.ResetColor();

        _roomService.CreateRoom(options, roomNumber, roomPrice, roomSize);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Nytt rum skapat");
        Console.ResetColor();
        Console.WriteLine("=======================");
        Console.WriteLine("Tryck valfri tangent för att fortsätta");
        Console.ReadKey();
    }
    public int CreateRoomNumber(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
    {
        while (true)
        {
            Console.Write("Skriv in rumsnummer: ");
            var roomNumber = Console.ReadLine();

            if (int.TryParse(roomNumber, out int input))
            {
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning, Måste vara ett nummer");
                Console.ResetColor();
                Console.WriteLine("-----------------------");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();
                continue;
            }

            if (_roomService.RoomNumberExist(options, roomNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rums numret finns redan");
                Console.ResetColor();
                Console.WriteLine("-----------------------");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();
                continue;
            }

            return int.Parse(roomNumber);
        }
    }
    public decimal CreateRoomPrice()
    {
        while (true)
        {
            Console.Write("Skriv in rumspris: ");
            var roomPrice = Console.ReadLine();

            if (decimal.TryParse(roomPrice, out decimal input))
            {
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning, Måste vara ett nummer");
                Console.ResetColor();
                Console.WriteLine("-----------------------");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();
                continue;
            }

            return input;
        }
    }
    public double CreateRoomSize()
    {
        while (true)
        {
            Console.Write("Skriv in rumstorlek: ");
            var roomSize = Console.ReadLine();

            if (double.TryParse(roomSize, out double input))
            {
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltig inmatning, Måste vara ett nummer");
                Console.ResetColor();
                Console.WriteLine("-----------------------");
                Console.WriteLine("Tryck valfri tangent för att fortsätta");
                Console.ReadKey();
                continue;
            }

            return input;
        }
    }
    
    
}
