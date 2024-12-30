using Autofac;
using ConsoleUI.AutoFac;
using ConsoleUI.RootInterfaces;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApp>();
                app.Run(); 
            }
        }
    }
}
