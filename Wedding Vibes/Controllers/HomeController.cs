using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wedding_Vibes.Data;
using Wedding_Vibes.Models;
using Wedding_Vibes.Models.MenuVM;

namespace Wedding_Vibes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var menus = (from men in _context.Menu
                            select new MenuVM
                            {
                                Id = men.Id,
                                Name = men.MenuName,
                                Price = men.MenuPrice,
                                Items = _context.MenuItem.Where(x=>x.MenuId==men.Id).OrderBy(x=>x.Category).ToList()
                            }).ToList();
            return View(menus);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
