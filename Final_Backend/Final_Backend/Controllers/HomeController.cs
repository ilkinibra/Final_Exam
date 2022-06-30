using Final_Backend.DAL;
using Final_Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.pageIntro = _context.pageIntros.FirstOrDefault();
            homeVM.what = _context.Whats.FirstOrDefault();
            homeVM.card = _context.Cards.ToList();
            homeVM.web = _context.webs.ToList();
            return View(homeVM);
        }
    }
}
