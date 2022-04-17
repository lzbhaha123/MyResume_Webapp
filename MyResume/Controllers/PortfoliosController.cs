#nullable disable
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
    public class PortfoliosController : Controller
    {
        private readonly MyResumeContext _context;
        public PortfoliosController(MyResumeContext context)
        {
            _context = context;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                return View(await _context.Portfolio.ToListAsync());
            }
            else
            {
                return RedirectToAction("Show");
            }
            
        }
        // GET: Portfolios/Show
        public async Task<IActionResult> Show()
        {
            List<String> pics = new List<String>();
            pics.Add("https://static.banner.co.uk/images/carousel/group/home/Media_Hub_Web_Banner4.jpg");
            pics.Add("https://static.banner.co.uk/images/carousel/group/home/Media_Hub_Web_Banner4.jpg");
            pics.Add("https://static.banner.co.uk/images/carousel/group/home/Media_Hub_Web_Banner4.jpg");
            ViewData["pics"] = pics;
            return View(await _context.Portfolio.ToListAsync());
        }
        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // GET: Portfolios/Create
        public IActionResult Create()
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Show");
            }
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Picture,Body,CreateAt")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolio);
        }

        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var portfolio = await _context.Portfolio.FindAsync(id);
                if (portfolio == null)
                {
                    return NotFound();
                }
                return View(portfolio);
            }
            else
            {
                return RedirectToAction("Show");
            }
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Picture,Body,CreateAt")] Portfolio portfolio)
        {
            if (id != portfolio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }
            else
            {
                return RedirectToAction("Show");
    }
}

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolio = await _context.Portfolio.FindAsync(id);
            _context.Portfolio.Remove(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
            return _context.Portfolio.Any(e => e.Id == id);
        }
    }
}
