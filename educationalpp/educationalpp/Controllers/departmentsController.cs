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
    public class departmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public departmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: departments
        public async Task<IActionResult> Index()
        {
              return _context.department != null ? 
                          View(await _context.department.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.department'  is null.");
        }

        // GET: departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.department == null)
            {
                return NotFound();
            }

            var department = await _context.department
                .FirstOrDefaultAsync(m => m.id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description")] department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.department == null)
            {
                return NotFound();
            }

            var department = await _context.department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description")] department department)
        {
            if (id != department.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departmentExists(department.id))
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
            return View(department);
        }

        // GET: departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.department == null)
            {
                return NotFound();
            }

            var department = await _context.department
                .FirstOrDefaultAsync(m => m.id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.department == null)
            {
                return Problem("Entity set 'ApplicationDbContext.department'  is null.");
            }
            var department = await _context.department.FindAsync(id);
            if (department != null)
            {
                _context.department.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departmentExists(int id)
        {
          return (_context.department?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
