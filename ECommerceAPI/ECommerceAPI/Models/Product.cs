using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Product
    {
       public long Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public string ImageUrl { get; set; }
       public double Cost { get; set; }
       public int Quantity { get; set; }
       public bool OutOfStock { get; set; }
       public long CategoryId { get; set; }

       public virtual Category Category { get; set; }
    }
}
