using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public long CityId { get; set; }
        public long ProvinceId { get; set; }
        public long CountryId { get; set; }

        public virtual City City { get; set; }
        public virtual Province Province { get; set; }
        public virtual Country Country { get; set; }
    }
}
