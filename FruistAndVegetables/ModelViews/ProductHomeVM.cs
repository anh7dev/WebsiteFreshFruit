using FruistAndVegetables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.ModelViews
{
    public class ProductHomeVM
    {
        public Category Category { get; set; }
        public List<Product> LsProducts { get; set; }
    }
}
