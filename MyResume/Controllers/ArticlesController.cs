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
using Microsoft.AspNetCore.Session;

namespace MyResume.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly MyResumeContext _context;

        public ArticlesController(MyResumeContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                return View(await _context.Article.ToListAsync());
            }
            else
            {
                return RedirectToAction("Show");
            }
            
        }

        public async Task<IActionResult> Show()
        {
            return View(await _context.Article.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
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

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Pictrue,Body,Tags,CreateAt")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var article = await _context.Article.FindAsync(id);
                if (article == null)
                {
                    return NotFound();
                }
                return View(article);
            }
            else
            {
                return RedirectToAction("Show");
            }
            
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Pictrue,Body,Tags,CreateAt")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var article = await _context.Article
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (article == null)
                {
                    return NotFound();
                }

                return View(article);
            }
            else
            {
                return RedirectToAction("Show");
            }
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Article.FindAsync(id);
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }
    }
}
