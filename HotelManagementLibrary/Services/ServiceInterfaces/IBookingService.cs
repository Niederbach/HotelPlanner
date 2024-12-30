using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services.ServiceInterfaces;

public interface IBookingService
{
    void CreateBooking(DbContextOptionsBuilder<ShabbyChateauDbContext> options, Customer customer, Room room, int numDays, bool extrabed, int numVisitors, DateTime arrivalDay, DateTime departureDay, decimal price);
    void DeleteBooking(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int bookingId);
    List<Booking> GetAllBookings(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
    Booking GetSingleBooking(DbContextOptionsBuilder<ShabbyChateauDbContext> options, int bookingId);
}