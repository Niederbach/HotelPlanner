using ConsoleUI.Displays;
using ConsoleUI.RootInterfaces;
using HotelManagementLibrary.Data.DataInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

public class App : IApp
{
    IMenu _mainMenu;
    IStartUp _startUp;
    ISeedData _seedData;
    
    public App(
        IMenu mainMenu, 
        IStartUp startUp, 
        ISeedData seedData)
    {
        _mainMenu = mainMenu;
        _startUp = startUp;
        _seedData = seedData;
    }
    public void Run()
    {
        _startUp.ConfigureServices();
        _seedData.SeedCustomers();
        //_seedData.SeedRooms();  
        _mainMenu.ShowMenu();
    }
}
