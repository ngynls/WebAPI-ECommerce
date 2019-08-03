using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class CustomerAddress
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long AddressId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Address Address { get; set; }
    }
}
