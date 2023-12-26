using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FruistAndVegetables.Models;
using FruistAndVegetables.ModelViews;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using FruistAndVegetables.Helpper;
using FruistAndVegetables.Extension;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;


namespace FruistAndVegetables.Controllers
{
    //[Authorize]

    public class AccountsController : Controller
    {
        private readonly dbMarketsContext _context;
        public INotyfService _notyfService { get; }

        public AccountsController(dbMarketsContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }


        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public IActionResult LoginAdmin()
        {
            var taikhoanID = HttpContext.Session.GetString("AccountId");
            if (!string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Index", "Home", new { Area = "Admin" });
            try
            {
                int accountid = Convert.ToInt32(taikhoanID);
                var account = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.AccountId == accountid);
                if (account == null) return View();
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }


            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public async Task<IActionResult> LoginAdmin(LoginViewModel account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(account.UserName);
                    if (!isEmail) return View(account);

                    var khachhang = _context.Accounts.AsNoTracking()
                        .Include(x=>x.Role)
                        .SingleOrDefault(x => x.Email.Trim() == account.UserName);
                    if (khachhang == null) return RedirectToAction("CreateAccount", "Accounts");
                    string pass = (account.Password + khachhang.Salt.Trim()).ToMD5();
                    if (khachhang.Password != pass)
                    {
                        _notyfService.Error("Sai thông tin đăng nhập");
                        return View(account);
                    }
                    HttpContext.Session.SetString("AccountId", khachhang.AccountId.ToString());
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.FullName),
                        new Claim("AccountId", khachhang.AccountId.ToString()),
                        new Claim("RoleId", khachhang.RoleId.ToString()),
                        new Claim(ClaimTypes.Role,khachhang.Role.RoleName!) // Admin, Mod, NhanVien
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    _notyfService.Success("Đăng nhập thành công");
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });// tuy chon
                }
            }
            catch (Exception ex)
            {
                _notyfService.Success("Đăng nhập không thành công");
                return RedirectToAction("LoginAdmin", "Accounts");
            }
            return View(account);

        }




        //Kiểm tra SĐT
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.ToLower() == Phone.ToLower());

                if (khachhang != null)
                {
                    return Json(data: "Số điện thoại : " + Phone + " Đã được sử dụng ");
                }

                return Json(data: true);
            }
            catch
            {
                // Handle the exception or log it
                return Json(data: false);
            }
        }

        //Kiểm tra Email
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());

                if (khachhang != null)
                {
                    return Json(data: "Email: " + Email + " Đã được sử dụng<br />");
                }

                return Json(data: true);
            }
            catch
            {
                // Handle the exception or log it
                return Json(data: false);
            }
        }

        //IndexI
        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {

                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    var lsDonHang = _context.Orders
                        .Include(x => x.TranSactStatus)
                        .AsNoTracking()
                        .Where(x => x.CustomerId == khachhang.CustomerId)
                        .OrderByDescending(x => x.OrderDate)
                        .ToList();
                    ViewBag.DonHang = lsDonHang;
                    return View(khachhang);
                }
            }
            return RedirectToAction("Login", "Accounts");
        }



        // GET: Accounts/Create
        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "Dangky")]
        public IActionResult CreateAccount()
        {
            return View();
        }

        //Xử lý đăng ký
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "Dangky")]
        public async Task<IActionResult> CreateAccount(RegisterVM account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string salt = Utilities.GetRandomKey();
                    Customer khachhang = new Customer
                    {
                        FullName = account.FullName,
                        Phone = account.Phone.Trim().ToLower(),
                        Email = account.Email.Trim().ToLower(),
                        Password = (account.Password + salt.Trim()).ToMD5(),
                        Active = true,
                        Salt = salt,
                        CreateDate = DateTime.Now
                    };

                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();

                        // Save CustomerId to Session
                        HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");

                        // Identity
                        var claims = new List<Claim>
                        {
                              new Claim(ClaimTypes.Name, khachhang.FullName),
                              new Claim("CustomerId", khachhang.CustomerId.ToString())
                         };

                        var claimsIdentity = new ClaimsIdentity(claims, "login");
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                    catch (Exception ex)
                    {
                        _notyfService.Error("Đăng ký không thành công" + ex.Message);

                        return RedirectToAction("CreateAccount", "Accounts");
                    }
                }
                else
                {
                    return View(account);
                }
            }
            catch (Exception ex)
            {
                return View(account);
            }

        }

        //Xử lý đăng nhập

        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {

                return RedirectToAction("Dashboard", "Accounts");
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail) return View(customer);

                    var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);
                    if (khachhang == null) return RedirectToAction("CreateAccount", "Accounts");
                    string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                    if (khachhang.Password != pass)
                    {
                        _notyfService.Error("Sai thông tin đăng nhập");
                        return View(customer);
                    }
                    HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.FullName),
                        new Claim("CustomerId", khachhang.CustomerId.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    _notyfService.Success("Đăng nhập thành công");
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Dashboard", "Accounts");// bo xunng code
                    }
                        return RedirectToAction("Dashboard", "Accounts");
                }
            }
            catch (Exception ex)
            {
                _notyfService.Success("Đăng nhập không thành công");
                return RedirectToAction("Login", "Accounts");
            }
            return View(customer);

        }

        //Logout
        [HttpGet]
        [Route("dang-xuat.html", Name = "Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            _notyfService.Success("Đăng xuất thành công");
            return RedirectToAction("Index", "Home");
        }

        //đổi mật khẩu
        public IActionResult ModalChangePassword()
        {
            return PartialView("ChangePassword");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (taikhoanID == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Customers.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null)
                    {
                        return RedirectToAction("Login", "Accounts");
                    }
                    var pass = (model.PasswordNow.Trim() + taikhoan.Salt.Trim()).ToMD5();
                    if (pass == taikhoan.Password)
                    {
                        string passnew = (model.Password.Trim() + taikhoan.Salt.Trim()).ToMD5();
                        taikhoan.Password = passnew;
                        _context.Update(taikhoan);
                        _notyfService.Success("Cập nhật mật khẩu thành công");
                        _context.SaveChanges();
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                }

            }
            catch
            {
                _notyfService.Error("Cập nhật mật khẩu không thành công");
                return RedirectToAction("Dashboard", "Accounts");
            }
            _notyfService.Error("Cập nhật mật khẩu không thành công");
            return RedirectToAction("Dashboard", "Accounts");
        }



        


    }
}
