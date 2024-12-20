namespace HotelManagementLibrary.Services.ServiceInterfaces
{
    public interface IBookingService
    {
        void CreateBooking();
        void DeleteBooking();
        void GetAllBookings();
        void GetSingleBooking();
        void UpdateBooking();
    }
}