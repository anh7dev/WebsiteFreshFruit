﻿using FruistAndVegetables.Extension;
using FruistAndVegetables.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruistAndVegetables.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}
