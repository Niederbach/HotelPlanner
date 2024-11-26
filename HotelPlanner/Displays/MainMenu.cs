using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPlanner.Displays;

public class MainMenu : IMenu
{
    public void ShowMenu()
    {
        Console.WriteLine("i menyn");
        Console.ReadKey();
    }
    public void UserInput()
    {

    }
}
