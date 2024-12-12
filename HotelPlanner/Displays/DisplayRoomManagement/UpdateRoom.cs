using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayRoomManagement
{
    public class UpdateRoom : IUpdateRoom
    {
        public void ShowUpdateRoom()
        {
            Console.Clear();
            Console.WriteLine("Updatera befintligt rum");
            Console.WriteLine("=======================");

            Console.ReadKey();
        }
    }
}
