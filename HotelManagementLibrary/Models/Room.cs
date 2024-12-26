namespace HotelManagementLibrary.Models
{
    public enum RoomType
    {
        enkelrum,
        dubbelrum
    }
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType {  get; set; } 
        public double RoomSize { get; set; }
        public decimal RoomPrice { get; set; }
        public bool IsActive { get; set; }
        public bool HasExtraBed { get; set; }

    }
}
