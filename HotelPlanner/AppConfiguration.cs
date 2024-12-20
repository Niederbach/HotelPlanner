using ConsoleUI.RootInterfaces;
using HotelManagementLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConsoleUI
{
    public class AppConfiguration : IAppConfiguration
    {
        public void ConfigureServices(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);


            using (var dbContext = new ShabbyChateauDbContext(options.Options))
            {
                dbContext.Database.Migrate();
            }
        }
        public DbContextOptionsBuilder<ShabbyChateauDbContext> ConfigureOptionBuilder()
        {
            var options = new DbContextOptionsBuilder<ShabbyChateauDbContext>();
            return options;
        }
    }
}
