using FruistAndVegetables.Models;
using FruistAndVegetables.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.Controllers
{
    public class ProductController : Controller
    {
        private readonly dbMarketsContext _context;

        public ProductController(dbMarketsContext context)
        {
            _context = context;
        }


        [Route("shop.html", Name = "ShopProduct")]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsProducts = _context.Products
                    .AsNoTracking()
                    .OrderByDescending(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(lsProducts, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [Route("/{Alias}", Name = "ListProduct")]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
                var lsProducts = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatId == danhmuc.CatId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(lsProducts, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult Search(string keyword, int page = 1)
        {
            try
            {
                var pageSize = 10;

                // Lấy danh sách sản phẩm tìm kiếm dựa trên từ khóa
                var searchResult = _context.Products
                    .AsNoTracking()
                    .Where(x => x.ProductName.Contains(keyword) || x.Description.Contains(keyword))
                    .OrderByDescending(x => x.DateCreated);
                if (keyword == null)
                {
                    var lsProducts = _context.Products
                     .AsNoTracking()
                     .OrderByDescending(x => x.DateCreated);
                    PagedList<Product> model = new PagedList<Product>(lsProducts, page, pageSize);
                    ViewBag.CurrentPage = page;
                    ViewBag.SearchKeyword = keyword;
                    return View("SearchResult", model);
                }
                // Phân trang kết quả tìm kiếm

                PagedList<Product> models = new PagedList<Product>(searchResult, page, pageSize);

                // Pass kết quả tìm kiếm và thông tin phân trang vào view
                ViewBag.CurrentPage = page;
                ViewBag.SearchKeyword = keyword;
                return View("SearchResult", models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public IActionResult FilterByCategory(int categoryId, int page = 1)
        {
            try
            {
                var pageSize = 10;

                // Lấy danh sách sản phẩm theo loại
                var productsByCategory = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatId == categoryId)
                    .OrderByDescending(x => x.DateCreated);

                PagedList<Product> models = new PagedList<Product>(productsByCategory, page, pageSize);

                ViewBag.CurrentPage = page;
                ViewBag.CurrentCategory = categoryId;

                return View("SearchResult", models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [Route("/{Alias}-{id}.html", Name = "ProductDetails")]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                var lsProduct = _context.Products.AsNoTracking()
                    .Where(x => x.CatId == product.CatId && x.ProductId != id && x.Active == true)
                    .Take(4)
                    .OrderByDescending(x => x.DateCreated)
                    .ToList();

                ViewBag.sameproduct = lsProduct;
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}
