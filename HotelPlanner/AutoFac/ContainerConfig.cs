using Autofac;
using ConsoleUI.Displays;
using ConsoleUI.Displays.DisplayBooking;
using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.Displays.DisplayCustomers;
using ConsoleUI.Displays.DisplayRoomManagement;
using HotelManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.AutoFac;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<App>().As<IApp>();
        builder.RegisterType<MainMenu>().As<IMenu>();
        builder.RegisterType<BookingMenu>().As<IBookingMenu>();
        builder.RegisterType<CustomerMenu>().As<ICustomerMenu>();
        builder.RegisterType<RoomMenu>().As<IRoomMenu>();
        builder.RegisterType<DisplayCreateBooking>().As<IDisplayCreateBooking>();
      
        return builder.Build();
    }
}
