using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using educationalpp.Data;
using educationalpp.Models;

namespace educationalpp.Controllers
{
    public class teachersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public teachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: teachers
        public async Task<IActionResult> Index()
        {
              return _context.teacher != null ? 
                          View(await _context.teacher.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.teacher'  is null.");
        }

        // GET: teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.teacher
                .FirstOrDefaultAsync(m => m.id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,GenderId,Date_of_Birth,Date_of_employment,address,Phone")] teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,GenderId,Date_of_Birth,Date_of_employment,address,Phone")] teacher teacher)
        {
            if (id != teacher.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!teacherExists(teacher.id))
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
            return View(teacher);
        }

        // GET: teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.teacher
                .FirstOrDefaultAsync(m => m.id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.teacher == null)
            {
                return Problem("Entity set 'ApplicationDbContext.teacher'  is null.");
            }
            var teacher = await _context.teacher.FindAsync(id);
            if (teacher != null)
            {
                _context.teacher.Remove(teacher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool teacherExists(int id)
        {
          return (_context.teacher?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
