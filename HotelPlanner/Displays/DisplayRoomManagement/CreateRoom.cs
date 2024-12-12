using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class CreateRoom : ICreateRoom
    {
        public void ShowCreateRoom()
        {
            Console.Clear();
            Console.WriteLine("Lägg till rum");
            Console.WriteLine("=============");

            Console.ReadKey();
        }
    }
}
