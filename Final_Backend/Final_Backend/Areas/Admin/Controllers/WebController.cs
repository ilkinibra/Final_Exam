using Final_Backend.DAL;
using Final_Backend.Helpers;
using Final_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Paterna_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class WebController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public WebController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Web> web = _context.webs.ToList();
            return View(web);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
           Web dbWeb = _context.webs.Find(id);
            if (dbWeb == null) return View(dbWeb);
            return View(dbWeb);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Web dbWeb = await _context.webs.FindAsync(id);
            if (dbWeb == null) return NotFound();
            Helper.DeleteFile(_env, "img", dbWeb.ImageUrl);
            _context.webs.Remove(dbWeb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Web web)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!web.Photo.ContentType.Contains("image/"))
            {
                return View();
            }
            if (web.Photo.Length / 1024 > 1000)
            {
                return View();
            }
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + web.Photo.FileName;
            string result = Path.Combine(path, "img", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await web.Photo.CopyToAsync(stream);
            };
            Web newWeb = new Web();
            newWeb.ImageUrl = fileName;
            await _context.webs.AddAsync(newWeb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id)
        {
            Web web = _context.webs.Find(id);
            if (web == null) return NotFound();
            return View(web);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id, Web web)
        {
            if (!ModelState.IsValid) return View();
            if (id != web.Id) return BadRequest();
            Web dbWeb = await _context.webs.Where(c=> c.Id == id).FirstOrDefaultAsync();
            if (dbWeb == null) return NotFound();
            if (dbWeb.Title.ToLower().Trim() == web.Title.ToLower().Trim())
            {
                return RedirectToAction(nameof(Index));
            }
            bool IsExist = _context.webs
                                .Any(c => c.Title.ToLower().Trim() == web.Title.ToLower().Trim());
            if (IsExist)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View(dbWeb);
            }
            dbWeb.Title = web.Title;
            dbWeb.Description = web.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
