using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HotelManagementLibrary.Data.DataInterfaces
{
    public interface ISeedData
    {
        void SeedCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        void SeedRooms(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
    }
}