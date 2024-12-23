using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services;

public class RoomService : IRoomService
{
    public void CreateRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
    {

    }
    public Room GetSingelRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber)
    {
        using (var context  = new ShabbyChateauDbContext(options.Options))
        {
            return context.Rooms.First(x => x.RoomNumber == roomNumber);
        }
    }
    public List<Room> GetAllRooms(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
        {
            return context.Rooms.Where(x => x.IsActive).ToList();
        }
    }
    public void UpdateRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
    {

    }
    public void DeleteRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
        {
            var room = context.Rooms.First(x => x.RoomNumber == roomNumber);
            room.IsActive = false;
            context.SaveChanges();
        }
    }
    public void RecoverRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
        {
            var room = context.Rooms.First(x => x.RoomNumber == roomNumber);
            room.IsActive = true;
            context.SaveChanges();
        } 
    }
    public List<Room> GetAllDeletedRooms(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
        {
            return context.Rooms.Where(x => x.IsActive == false).ToList();
        }
    }
}
