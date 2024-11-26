using Autofac;
using HotelPlanner.AutoFac;

namespace HotelPlanner
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
