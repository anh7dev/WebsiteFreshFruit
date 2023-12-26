using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.Controllers
{
    public class AdminAuthen : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
