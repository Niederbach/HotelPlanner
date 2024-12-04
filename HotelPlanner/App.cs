﻿using ConsoleUI.Displays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

public class App : IApp
{
    IMenu _mainMenu;
    public App(IMenu mainMenu)
    {
        _mainMenu = mainMenu;
    }
    public void Run()
    {
        _mainMenu.ShowMenu();
    }
}
