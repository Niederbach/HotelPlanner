using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.Models;

namespace HotelManagementLibrary.Data
{
    public class SeedData : ISeedData
    {
        public void SeedCustomers()
        {
            using (var context = new ShabbyChateauDbContext())
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
                        Phone = "070 123 45 67",
                        PostalCode = "111 29",
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
                        Phone = "070 234 56 78",
                        PostalCode = "411 27",
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
                        Phone = "070 345 67 89",
                        PostalCode = "211 22",
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
                        Phone = "076 987 65 43",
                        PostalCode = "753 35",
                        Email = "Philip.Philipsson@example.com",
                        IsActive = true,
                    };
                    context.Customers.AddRange(customer1, customer2, customer3, customer4);

                    context.SaveChanges();
                }

            }
        }
        public void SeedRooms()
        {
            using (var context = new ShabbyChateauDbContext())
            {
                if (!context.Rooms.Any())
                {
                    var room1 = new Room()
                    {
                        RoomNumber = 101,
                    };
                    var room2 = new Room()
                    {
                        RoomNumber = 102,
                    };
                    var room3 = new Room()
                    {
                        RoomNumber = 201
                    };
                    var room4 = new Room()
                    {
                        RoomNumber = 202
                    };
                    context.Rooms.AddRange(room1, room2, room3, room4);

                    context.SaveChanges();
                }
            }

        }
    }
}
