using FruistAndVegetables.Models;
using FruistAndVegetables.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbMarketsContext _context;

        public HomeController(ILogger<HomeController> logger, dbMarketsContext context)
        {
            _logger = logger;
            _context = context;
        }



        public async Task<IActionResult> Index(int id)
        {
            // Lấy danh sách tin tức
            //var tinTucs = await _context.TinTucs.ToListAsync();
            var tinTucs = _context.TinTucs.AsNoTracking()
                .Where(x => x.Published && x.PostId != id)
                .Take(3).OrderByDescending(x => x.CreatedDate)
                .ToList();
                ViewBag.lsBaiVietLienQuan = tinTucs;

            // Lấy danh sách sản phẩm và danh mục sản phẩm
            var products = await _context.Categories
                .Include(c => c.Products)
                .Select(c => new ProductHomeVM
                {
                    Category = c,
                    LsProducts = c.Products.ToList()
                })
                .ToListAsync();

            // Lấy danh sách sản phẩm cho từng loại mục
            var allItemsProducts = await GetProductsByCategoryAsync("All Items");
            var freshFruitsProducts = await GetProductsByCategoryAsync("Fresh Fruits");
            var vegetableProducts = await GetProductsByCategoryAsync("Vegetable");
            // ...Thêm loại mục khác nếu cần

            // Tạo đối tượng HomeViewVM và set dữ liệu
            var homeViewModel = new HomeViewVM
            {
                TinTucs = tinTucs,
                Products = products,
                AllItemsProducts = allItemsProducts,
                FreshFruitsProducts = freshFruitsProducts,
                VegetableProducts = vegetableProducts
                // ...Thêm thuộc tính khác nếu cần
            };

            // Trả về view với dữ liệu đã lấy
            return View(homeViewModel);
        }

        private async Task<List<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            return await _context.Categories
                .Where(c => c.CatName == categoryName)
                .SelectMany(c => c.Products)
                .ToListAsync();
        }




        [Route("lien-he.html", Name = "Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("ve-chung-toi.html", Name = "About")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
