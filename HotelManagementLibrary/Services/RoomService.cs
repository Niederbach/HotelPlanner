using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services;

public class RoomService : IRoomService
{
    public void CreateRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber, decimal roomPrice, double roomSize)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
        {
            var newRoom = new Room
            {
                RoomNumber = roomNumber,
                RoomPrice = roomPrice,
                RoomSize = roomSize,
                RoomType = CalculateRoomType(roomSize),
                HasExtraBed = CalculateExtraBed(roomSize),
                IsActive = true
            };
            context.Rooms.Add(newRoom);
            context.SaveChanges();
        }
    }
    public bool CalculateExtraBed(double roomSize)
    {
        if (roomSize > 20)
        {
            return true;
        }
        else 
            return false;
    }
    public RoomType CalculateRoomType(double roomSize)
    {
        if (roomSize > 20)
        {
            return RoomType.dubbelrum;
        }
        else 
        {
            return RoomType.enkelrum;
        }
    }
    public Room GetSingelRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int roomNumber)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
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
    public void UpdateRoom(DbContextOptionsBuilder<ShabbyChateauDbContext> options, Room room, string newInformation, int selectedInput)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
        {
            var roomUpdate = context.Rooms.First(x => x.RoomId == room.RoomId);

            if (selectedInput == 1)
            {
                roomUpdate.RoomNumber = int.Parse(newInformation);
            }
            else if (selectedInput == 2)
            {
                roomUpdate.RoomPrice = decimal.Parse(newInformation);
            }
            else if (selectedInput == 3)
            {
                roomUpdate.RoomSize = double.Parse(newInformation);

                if (roomUpdate.RoomSize > 20)
                {
                    roomUpdate.RoomType = RoomType.dubbelrum;
                    roomUpdate.HasExtraBed = true;
                }
                else if (roomUpdate.RoomSize <= 20)
                {
                    roomUpdate.RoomType = RoomType.enkelrum;
                    roomUpdate.HasExtraBed = false;
                }
            }
            context.SaveChanges();
        }
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
    public bool RoomNumberExist(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string roomNumber)
    {
        using (var context = new ShabbyChateauDbContext(options.Options))
        {
            if (context.Rooms.Any(x => x.RoomNumber == int.Parse(roomNumber)))
            {
                return true;
            }
            else
                return false;
        }
    }
}
