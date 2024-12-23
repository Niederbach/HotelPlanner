using HotelManagementLibrary.Models;

namespace ConsoleUI.Tools;

public class SelectFormat
{
    public static void CreateCustomerEmailUI(int selectedIndex, List<Customer> customers, int index)
    {
        for (index = 0; index < customers.Count; index++)
        {
            if (selectedIndex == index)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"- {customers[index].Email}");
            Console.ResetColor();
        }
        if (selectedIndex == customers.Count)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.WriteLine("- Tillbaka");
        Console.ResetColor();
    }
    public static void CreateRoomNumberUI(int selectedIndex, List<Room> rooms, int index)
    {
        for (index = 0; index < rooms.Count; index++)
        {
            if (selectedIndex == index)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"- Rumsnummer {rooms[index].RoomNumber}");
            Console.ResetColor();
        }
        if (selectedIndex == rooms.Count)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.WriteLine("- Tillbaka");
        Console.ResetColor();
    }
}
