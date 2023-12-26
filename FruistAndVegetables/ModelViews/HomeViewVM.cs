using FruistAndVegetables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.ModelViews
{
    public class HomeViewVM
    {
        public List<TinTuc> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
        public List<Product> AllItemsProducts { get; set; }
        public List<Product> FreshFruitsProducts { get; set; }
        public List<Product> VegetableProducts { get; set; }
        // ...Thêm các danh sách sản phẩm cho các loại mục khác nếu cần
    }

}
