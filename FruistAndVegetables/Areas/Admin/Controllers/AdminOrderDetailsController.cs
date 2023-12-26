using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FruistAndVegetables.Models;
using Microsoft.AspNetCore.Authorization;
using FruistAndVegetables.Extension;
using FruistAndVegetables.ModelViews;
using FruistAndVegetables.Areas.Admin.Models;

namespace FruistAndVegetables.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/AdminOrderDetails/[action]")]
    public class AdminOrderDetailsController : Controller
    {
        private readonly dbMarketsContext _context;

        public AdminOrderDetailsController(dbMarketsContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminOrderDetails
        public async Task<IActionResult> Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var dbMarketsContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            return View(await dbMarketsContext.ToListAsync());
        }

        // GET: Admin/AdminOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Where(m => m.OrderDetailId == id)
                .ToListAsync();

            if (orderDetails == null || orderDetails.Count == 0)
            {
                return NotFound();
            }

            var orderDetailsViewModel = new OrderDetailsViewModel
            {
                Order = orderDetails.First().Order,
                OrderDetails = orderDetails,
                // Add other properties if needed
            };

            return View(orderDetailsViewModel);
        }


        // GET: Admin/AdminOrderDetails/Create
        public IActionResult Create()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: Admin/AdminOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailId,OrderId,ProductId,OrderNumber,Quantity,Discount,Total,ShipDate")] OrderDetail orderDetail)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: Admin/AdminOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: Admin/AdminOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailId,OrderId,ProductId,OrderNumber,Quantity,Discount,Total,ShipDate")] OrderDetail orderDetail)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            if (id != orderDetail.OrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: Admin/AdminOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: Admin/AdminOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailId == id);
        }
    }
}
