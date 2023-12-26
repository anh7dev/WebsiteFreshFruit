using AspNetCoreHero.ToastNotification.Abstractions;
using FruistAndVegetables.Extension;
using FruistAndVegetables.Helpper;
using FruistAndVegetables.Models;
using FruistAndVegetables.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly dbMarketsContext _context;
        private readonly INotyfService _notifyService;

        public CheckoutController(dbMarketsContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Checkout/Index
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(string returnUrl = null)
        {
            // Lấy giỏ hàng ra để xử lý.
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();

            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));

                model.CustomerId = khachhang.CustomerId;
                model.FullName = khachhang.FullName;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Phone;
                model.Address = khachhang.Address;
            }

            // ViewData["lsTinh Thanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "LocationId", "Name");

            ViewBag.GioHang = cart;

            return View(model);
        }



        [HttpPost]
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(MuaHangVM muaHang)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();

            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));

                model.CustomerId = khachhang.CustomerId;
                model.FullName = khachhang.FullName;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Phone;
           
                model.Address = muaHang.Address;
                //;;;;
                _context.Update(khachhang);
                _context.SaveChanges();

                try
                {
                    if (ModelState.IsValid)
                    {
                        // Khởi tạo đơn hàng
                        Order donhang = new Order();
                        donhang.CustomerId = model.CustomerId;
                       // donhang.Customer.Address = model.Address;
                        donhang.OrderDate = DateTime.Now;
                        donhang.TranSactStatusId = 1; // Đơn hàng mới
                        donhang.Deleted = false;
                        donhang.Paid = false;
                        donhang.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));

                        _context.Add(donhang);
                        _context.SaveChanges();

                        // Tạo danh sách đơn hàng
                        foreach (var item in cart)
                        {
                            OrderDetail orderDetail = new OrderDetail();
                            orderDetail.OrderId = donhang.OrderId;
                            orderDetail.ProductId = item.product.ProductId;
                            orderDetail.OrderNumber = item.amount;
                            orderDetail.Total = donhang.TotalMoney;
                            orderDetail.Discount = item.product.Price;
                            orderDetail.ShipDate = DateTime.Now;

                            _context.Add(orderDetail);
                            _context.SaveChanges();
                        }

                        // Clear giỏ hàng
                        HttpContext.Session.Remove("GioHang");

                        // Xuất thông báo
                        _notifyService.Success("Đơn hàng đặt thành công");

                        // Cập nhật thông tin khách hàng
                        return RedirectToAction("Success");
                    }
                }
                catch(Exception ex)
                {
                    string msg = ex.Message;
                   
                    // Xử lý lỗi nếu cần thiết
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

    }
}
