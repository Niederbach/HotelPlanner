using HotelManagementLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI.RootInterfaces
{
    public interface IAppConfiguration
    {
        void ConfigureServices(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        DbContextOptionsBuilder<ShabbyChateauDbContext> ConfigureOptionBuilder();
    }
}