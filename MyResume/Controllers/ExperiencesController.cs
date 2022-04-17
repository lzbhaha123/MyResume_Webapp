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
    public class ExperiencesController : Controller
    {
        private readonly MyResumeContext _context;

        public ExperiencesController(MyResumeContext context)
        {
            _context = context;
        }

        // GET: Experiences
        public async Task<IActionResult> Index()
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                return View(await _context.Experience.ToListAsync());
            }
            else
            {
                return RedirectToAction("Show");
            }
        }

        // GET: Experiences
        public async Task<IActionResult> Show()
        {
            return View(await _context.Experience.ToListAsync());
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experiences/Create
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

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Location,Duration, picture ,description,CreateAt")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }

        // GET: Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var experience = await _context.Experience.FindAsync(id);
                if (experience == null)
                {
                    return NotFound();
                }
                return View(experience);
            }
            else
            {
                return RedirectToAction("Show");
            }
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Location,Duration,picture ,description,CreateAt")] Experience experience)
        {
            if (id != experience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.Id))
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
            return View(experience);
        }

        // GET: Experiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            int? log = HttpContext.Session.GetInt32("log");
            if (log == 1)
            {
                if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);

        }
            else
            {
                return RedirectToAction("Show");
    }
}

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.Experience.FindAsync(id);
            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.Id == id);
        }
    }
}
