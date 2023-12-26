using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Mod, ModNews, ModPage, ModProduct")]
    [Route("Admin/Home/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
