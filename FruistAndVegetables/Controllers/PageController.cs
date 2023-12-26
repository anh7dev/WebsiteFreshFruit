using FruistAndVegetables.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FruistAndVegetables.Controllers
{
    public class PageController : Controller
    {
        private readonly dbMarketsContext _context;

        public PageController(dbMarketsContext context)
        {
            _context = context;
        }

        [Route("/page/{Alias}", Name = "PageDetails")]
        public IActionResult Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }

            var page = _context.Pages.AsNoTracking().FirstOrDefault(x => x.Alias == Alias);


            if (page == null)
            {
                // Return a custom view for a not-found scenario
                return View("PageNotFound");
            }

            return View(page);
        }
    }
}
