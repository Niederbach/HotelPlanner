using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services
{
    public class BookingService : IBookingService
    {
        public void CreateBooking(
            DbContextOptionsBuilder<ShabbyChateauDbContext> options,
            Customer customer,
            Room room, 
            int numDays,
            bool extrabed,
            int numVisitors,
            DateTime arrivalDay,
            DateTime departureDay,
            decimal price)
        {
            using (var context  = new ShabbyChateauDbContext(options.Options))
            {
                var newBooking = new Booking()
                {
                    customerId = customer.CustomerId,
                    NumVisitors = numVisitors,
                    ArrivalDate = arrivalDay,
                    DepartureDate = departureDay,
                    Price = price,
                    RoomId = room.RoomId,
                    extraBed = extrabed
                };
                context.Bookings.Add(newBooking);
                context.SaveChanges();
            }
        }
        public Booking GetSingleBooking(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int bookingId)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                return context.Bookings.First(x => x.BookingId == bookingId);
            }
        }
        public List<Booking> GetAllBookings(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                return context.Bookings.ToList();
            }
        }
        public void DeleteBooking(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int bookingId)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                var booking = context.Bookings.First(x => x.BookingId == bookingId);
                
                context.Bookings.Remove(booking);
                context.SaveChanges();
            }
        }

    }
}
