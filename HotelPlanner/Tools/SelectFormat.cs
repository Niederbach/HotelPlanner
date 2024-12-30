using HotelManagementLibrary.Models;
using System.Diagnostics.Metrics;

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
            Console.WriteLine($"- Email: {customers[index].Email}");
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
            Console.WriteLine($"- Rumsnummer: {rooms[index].RoomNumber}");
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
    public static void CreateRoomNumberWithRoomTypeUI(int selectedIndex, List<Room> rooms, int index)
    {
        int count = 0;
        for (index = 0; index < rooms.Count; index++)
        {
            if (selectedIndex == index)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"Rumsnummer {rooms[index].RoomNumber}, {rooms[index].RoomType}");
            Console.ResetColor();

            count++;
            if (count < rooms.Count)
                Console.WriteLine("--------------------");
        }
    }
    public static void CreateBookingIdUI(int selectedIndex, List<Booking> bookings, int index)
    {
        for (index = 0; index < bookings.Count; index++)
        {
            if (selectedIndex == index)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"- Bookings ID: {bookings[index].BookingId}");
            Console.ResetColor();
        }
        if (selectedIndex == bookings.Count)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.WriteLine("- Tillbaka");
        Console.ResetColor();
    }
}
