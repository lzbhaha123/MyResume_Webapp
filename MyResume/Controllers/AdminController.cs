using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyResume.Data;
using MyResume.Models;

namespace MyResume.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyResumeContext _context;

        public AdminController(MyResumeContext context)
        {
            _context = context;
        }
        public ViewResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginConfirm([Bind("Pwd")] Pin pin)
        {
            bool r = pin.Pwd == "lzb1990";
            if (r) {
                HttpContext.Session.SetInt32("log",1);
                return RedirectToAction("Index","Home");
            }
            else {
                return RedirectToAction("Index","Admin");
            }
            

        }
        
        // GET: Admin/Messages
        public async Task<IActionResult> Messages(int page = 1)
        {

            int pageIndex = page;
            int pageSize = 10;

            IQueryable<Message> messageIQ = from m in _context.Message select m;
            messageIQ = messageIQ.OrderByDescending(m => m.CreatedAt);

            int count = await messageIQ.CountAsync();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);

            messageIQ = messageIQ.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            ViewData["PaginationTotalPage"] = totalPages;
            ViewData["PaginationIndex"] = pageIndex;

            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                return View(await _context.Article.ToListAsync());
            }
            else
            {
                return View(await messageIQ.AsNoTracking().ToListAsync());
            }
            //return View(_context.Message.OrderByDescending(x => x.Id).ToList());
        }
        

    }
}
