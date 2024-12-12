using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class RecoverRoom : IRecoverRoom
    {
        public void ShowRecoverRoom()
        {
            Console.Clear();
            Console.WriteLine("Lägg till borttaget rum");
            Console.WriteLine("=======================");

            Console.ReadKey();
        }
    }
}
