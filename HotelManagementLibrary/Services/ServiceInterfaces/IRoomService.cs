using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services.ServiceInterfaces
{
    public interface IRoomService
    {
        void CreateRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        void DeleteRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber);
        List<Room> GetAllRooms(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        Room GetSingelRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber);
        void RecoverRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber);
        void UpdateRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        List<Room> GetAllDeletedRooms(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
    }
}