using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class DeleteRoom : IDeleteRoom
    {
        public void ShowDeleteRoom()
        {
            Console.Clear();
            Console.WriteLine("Ta bort rum");
            Console.WriteLine("===========");

            Console.ReadKey();
        }

    }
}
