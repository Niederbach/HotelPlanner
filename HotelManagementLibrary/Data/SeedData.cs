using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;

namespace HotelManagementLibrary.Data
{
    public class SeedData : ISeedData
    {
        public void SeedCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                if (!context.Customers.Any())
                {
                    var customer1 = new Customer()
                    {
                        FirstName = "Stefan",
                        LastName = "Björk",
                        Address = "12 Västerlånggatan",
                        City = "Stockholm",
                        Country = "Sverige",
                        Phone = "0701234567",
                        PostalCode = "11129",
                        Email = "Stefan.Björk@example.com",
                        IsActive = true,
                    };
                    var customer2 = new Customer()
                    {
                        FirstName = "Lisa",
                        LastName = "Andersson",
                        Address = "8 Storgatan",
                        City = "Göteborg",
                        Country = "Sverige",
                        Phone = "0702345678",
                        PostalCode = "41127",
                        Email = "Lisa.Andersson@example.com",
                        IsActive = true,
                    };
                    var customer3 = new Customer()
                    {
                        FirstName = "Peter",
                        LastName = "Sjö",
                        Address = "35 Drottninggatan",
                        City = "Malmö",
                        Country = "Sverige",
                        Phone = "0703456789",
                        PostalCode = "21122",
                        Email = "Peter.Sjö@example.com",
                        IsActive = true,
                    };
                    var customer4 = new Customer()
                    {
                        FirstName = "Philip",
                        LastName = "Philipsson",
                        Address = "77 Östra Järnvägsgatan",
                        City = "Uppsala",
                        Country = "Sverige",
                        Phone = "0769876543",
                        PostalCode = "75335",
                        Email = "Philip.Philipsson@example.com",
                        IsActive = true,
                    };
                    context.Customers.AddRange(customer1, customer2, customer3, customer4);

                    context.SaveChanges();
                }

            }
        }
        public void SeedRooms(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                if (!context.Rooms.Any())
                {
                    var room1 = new Room()
                    {
                        RoomNumber = 101,
                        RoomType = RoomType.enkelrum,
                        RoomPrice = 2000m,
                        RoomSize = 20,
                        HasExtraBed = false,
                        IsActive = true
                    };
                    var room2 = new Room()
                    {
                        RoomNumber = 102,
                        RoomType= RoomType.dubbelrum,
                        RoomPrice = 3000m,
                        RoomSize = 30,
                        HasExtraBed = true,
                        IsActive = true
                    };
                    var room3 = new Room()
                    {
                        RoomNumber = 201,
                        RoomType = RoomType.enkelrum,
                        RoomPrice = 2000m,
                        RoomSize = 20,
                        HasExtraBed = false,
                        IsActive = true
                    };
                    var room4 = new Room()
                    {
                        RoomNumber = 202,
                        RoomType = RoomType.dubbelrum,
                        RoomPrice = 3000m,
                        RoomSize = 30,
                        HasExtraBed = true,
                        IsActive = true
                    };
                    context.Rooms.AddRange(room1, room2, room3, room4);

                    context.SaveChanges();
                }
            }

        }
    }
}
