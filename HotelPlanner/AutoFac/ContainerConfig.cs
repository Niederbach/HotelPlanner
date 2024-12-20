using Autofac;
using ConsoleUI.Displays;
using ConsoleUI.Displays.DisplayBooking;
using ConsoleUI.Displays.DisplayBooking.BookingInterfaces;
using ConsoleUI.Displays.DisplayCustomers;
using ConsoleUI.Displays.DisplayCustomers.CustomerInterfaces;
using ConsoleUI.Displays.DisplayInvoice;
using ConsoleUI.Displays.DisplayInvoice.InvoiceInterfaces;
using ConsoleUI.Displays.DisplayRoomManagement;
using ConsoleUI.Displays.DisplayRoomManagement.RoomManagementInterfaces;
using ConsoleUI.RootInterfaces;
using HotelManagementLibrary.Data;
using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.Services;
using HotelManagementLibrary.Services.ServiceInterfaces;

namespace ConsoleUI.AutoFac;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        //Build Program
        builder.RegisterType<AppConfiguration>().As<IAppConfiguration>();
        builder.RegisterType<App>().As<IApp>();
        builder.RegisterType<SeedData>().As<ISeedData>();

        //Menyer 
        builder.RegisterType<MainMenu>().As<IMenu>();
        builder.RegisterType<BookingMenu>().As<IBookingMenu>();
        builder.RegisterType<CustomerMenu>().As<ICustomerMenu>();
        builder.RegisterType<RoomMenu>().As<IRoomMenu>();
        builder.RegisterType<InvoiceMenu>().As<IInvoiceMenu>();

        //Display Booking
        builder.RegisterType<CreateBooking>().As<ICreateBooking>();
        builder.RegisterType<ReadBooking>().As<IReadBooking>();
        builder.RegisterType<UpdateBooking>().As<IUpdateBooking>();
        builder.RegisterType<DeleteBooking>().As<IDeleteBooking>();

        //Display Customer
        builder.RegisterType<CreateCustomer>().As<ICreateCustomer>();
        builder.RegisterType<ReadCustomer>().As<IReadCustomer>();
        builder.RegisterType<DeleteCustomer>().As<IDeleteCustomer>();
        builder.RegisterType<UpdateCustomer>().As<IUpdateCustomer>();
        builder.RegisterType<RecoverCustomer>().As<IRecoverCustomer>();

        //Display Room
        builder.RegisterType<RecoverRoom>().As<IRecoverRoom>();
        builder.RegisterType<CreateRoom>().As<ICreateRoom>();
        builder.RegisterType<ReadRoom>().As<IReadRoom>();
        builder.RegisterType<UpdateRoom>().As<IUpdateRoom>();
        builder.RegisterType<DeleteRoom>().As<IDeleteRoom>();

        //Display Invoice


        //Services
        builder.RegisterType<CustomerService>().As<ICustomerService>();
        builder.RegisterType<BookingService>().As<IBookingService>();
        builder.RegisterType<RoomService>().As<IRoomService>();
        builder.RegisterType<InvoiceService>().As<IInvoiceService>();



        return builder.Build();
    }
}
