using Final_Backend.Areas.Admin.Controllers;
using Final_Backend.Controllers;
using Final_Backend.DAL;
using Final_Backend.Models;
using Final_Backend.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Paterna_Backend.Controllers
{
    
    public class AccountController : Controller
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        // GET: AccountController1/Create
        public async Task<ActionResult> Register()
        {
            var user = new AppUser();
            user.UserName = "Ilkin";
            user.Email = "tu7mrkt9v@code.edu.az";
            string Password = "Ilkinqarabag.1";
            IdentityResult identityResult = await _userManager.CreateAsync(user, Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return Json("Register Alinmadi");
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return Json("Register olundu");
        }

        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            return Json("Create olundu");
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginVM logInVM)
        {
            if (!ModelState.IsValid) return View();
            var AppUser = await _userManager.FindByEmailAsync(logInVM.Email);
            if (AppUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email or Password Wrong");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(AppUser, logInVM.Password, false, false);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "3 cox cehd");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or Password Wrong");
                return View();
            }
            return RedirectToAction(nameof(DashboardController.Index), "Admin");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

