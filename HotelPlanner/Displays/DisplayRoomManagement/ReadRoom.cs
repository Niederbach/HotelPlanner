using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class ReadRoom : IReadRoom
    {
        public void ShowReadRoom()
        {
            Console.Clear();
            Console.WriteLine("Titta på rum");
            Console.WriteLine("============");

            Console.ReadKey();
        }
    }
}
