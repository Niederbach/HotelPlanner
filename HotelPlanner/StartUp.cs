using ConsoleUI.RootInterfaces;
using HotelManagementLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public class StartUp : IStartUp
    {
        public void ConfigureServices()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ShabbyChateauDbContext>();

            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
                      

            using (var dbContext = new ShabbyChateauDbContext(options.Options))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
