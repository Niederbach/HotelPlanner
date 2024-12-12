using Autofac;
using ConsoleUI.Displays;
using ConsoleUI.Displays.DisplayBooking;
using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.Displays.DisplayCustomers;
using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.Displays.DisplayRoomManagement;
using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
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

        builder.RegisterType<CreateBooking>().As<ICreateBooking>();
        builder.RegisterType<ReadBooking>().As<IReadBooking>();
        builder.RegisterType<UpdateBooking>().As<IUpdateBooking>();
        builder.RegisterType<DeleteBooking>().As<IDeleteBooking>();

        builder.RegisterType<CreateCustomer>().As<ICreateCustomer>();
        builder.RegisterType<ReadCustomer>().As<IReadCustomer>();
        builder.RegisterType<DeleteCustomer>().As<IDeleteCustomer>();
        builder.RegisterType<UpdateCustomer>().As<IUpdateCustomer>();
        builder.RegisterType<RecoverCustomer>().As<IRecoverCustomer>();

        builder.RegisterType<RecoverRoom>().As<IRecoverRoom>();
        builder.RegisterType<CreateRoom>().As<ICreateRoom>();
        builder.RegisterType<ReadRoom>().As<IReadRoom>();
        builder.RegisterType<UpdateRoom>().As<IUpdateRoom>();
        builder.RegisterType<DeleteRoom>().As<IDeleteRoom>();

        return builder.Build();
    }
}
