namespace HotelManagementLibrary.Services.ServiceInterfaces
{
    public interface IRoomService
    {
        void CreateRoom();
        void DeleteRoom();
        void GetAllRooms();
        void GetSingelRoom();
        void RecoverRoom();
        void UpdateRoom();
    }
}