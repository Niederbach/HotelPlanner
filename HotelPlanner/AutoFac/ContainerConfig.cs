using Autofac;
using HotelPlanner.Displays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPlanner.AutoFac;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<App>().As<IApp>();
        builder.RegisterType<MainMenu>().As<IMenu>();
      
        return builder.Build();
    }
}
