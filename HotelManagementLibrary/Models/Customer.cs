﻿namespace HotelManagementLibrary.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
