namespace HotelManagementLibrary.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }
    }
}
