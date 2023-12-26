using FruistAndVegetables.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Linq;

namespace FruistAndVegetables.Controllers
{
    public class BlogController : Controller
    {
        private readonly dbMarketsContext _context;

        public BlogController(dbMarketsContext context)
        {
            _context = context;
        }

        [Route("blogs.html", Name = "BlogIndex")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var lsTinTucs = _context.TinTucs
                .AsNoTracking()
                .OrderByDescending(x => x.PostId);
            PagedList<TinTuc> models = new PagedList<TinTuc>(lsTinTucs, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        [Route("/tin-tuc/{Alias}-{id}.html", Name = "TinDetails")]
        public IActionResult Details( int id)
        {
            var tintuc = _context.TinTucs.AsNoTracking().FirstOrDefault(x => x.PostId == id);
            if (tintuc == null)
            {
                return RedirectToAction("Index");
            }

            var lsBaiVietLienQuan = _context.TinTucs.AsNoTracking()
                .Where(x => x.Published && x.PostId != id)
                .Take(3).OrderByDescending(x => x.CreatedDate)
                .ToList();
            ViewBag.lsBaiVietLienQuan = lsBaiVietLienQuan;
            return View(tintuc);
        }
    }
}
