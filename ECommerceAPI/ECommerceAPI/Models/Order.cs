using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string DateIssued { get; set; }
        public string ShippedDate { get; set; }
        public string Status { get; set; }
        public double Subtotal { get; set; }
        public double TPSTax { get; set; }
        public double TVQTax { get; set; }
        public double Total { get; set; }
        public string PaymentType { get; set; }
        public long CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
