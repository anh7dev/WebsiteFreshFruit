using FruistAndVegetables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.Areas.Admin.Models
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public Category category { get; set; }
        public Product product  { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
