using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int NumVisitors { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public bool extraBed {  get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
