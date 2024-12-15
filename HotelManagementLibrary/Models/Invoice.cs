using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }
    }
}
