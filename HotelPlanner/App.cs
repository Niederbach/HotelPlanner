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
    IAppConfiguration _startUp;
    ISeedData _seedData;
    
    public App(
        IMenu mainMenu, 
        IAppConfiguration startUp, 
        ISeedData seedData)
    {
        _mainMenu = mainMenu;
        _startUp = startUp;
        _seedData = seedData;
    }
    public void Run()
    {
        var options = _startUp.ConfigureOptionBuilder();

        _startUp.ConfigureServices(options);
        _seedData.SeedCustomers(options);
        _seedData.SeedRooms(options);  
        _mainMenu.ShowMenu();
    }
}
