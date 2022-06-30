using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
