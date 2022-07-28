using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using educationalpp.Data;
using educationalpp.viewmodel;
using educationalpp.Models;

namespace educationalpp.Controllers
{
    public class courseviewmodelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public courseviewmodelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: courseviewmodels
        public async Task<IActionResult> Index()
        { 
            return _context.course  != null ?
                        View(await _context.course.Include(s=> s.teacher).Include(s => s.department).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.courseviewmodel'  is null.");
        }
      

        // GET: courseviewmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.course == null)
            {
                return NotFound();
            }

            var course= await _context.course.Include(s => s.teacher).Include(s => s.department)
                .FirstOrDefaultAsync(m => m.id == id);
            if (course  == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: courseviewmodels/Create
         public IActionResult Create()
            {
                courseviewmodel item = new courseviewmodel();
                var teachers = _context.teacher.Include(s => s.number_of_courses).ToList();

                item.teacher = new SelectList((System.Collections.IEnumerable)teachers, "id", "Name");
                var departments = _context.department.ToList();

                item.department = new SelectList((System.Collections.IEnumerable)departments, "id", "name");
                return View(item);
             
        }

     

        // POST: courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(courseviewmodel newcourse)
        {
            course c = new course()
            {
                Name = newcourse.Name,
                price = newcourse.price,
                hours = newcourse.hours,
                start_date = newcourse.start_date,
                end_date = newcourse.end_date,
                teacher = _context.teacher.Find(newcourse.teacherid),
                department = _context.department.Find(newcourse.departmentid)


            };
            if (ModelState.IsValid)
            {
                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View( c); 
        }


        // GET: courseviewmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.course == null)
            {
                return NotFound();
            }

            var c =  _context.course.SingleOrDefault(s => s.id == id);
            if (c == null)
            {
                return NotFound();
            }
           var teachers = _context.teacher.Include(s => s.number_of_courses).ToList();
           var departments = _context.department.ToList();
           var courseviewmodel = new courseviewmodel 
            {
                id = c.id,
                Name =c.Name ,
                hours=c.hours ,
                price =c.price,
                start_date=c.start_date,
                end_date = c.end_date,
                teacher = new SelectList((System.Collections.IEnumerable)teachers, "id", "Name"),
                department = new SelectList((System.Collections.IEnumerable)departments, "id", "name")

            };
             
            return View(courseviewmodel);
        }
                   
    

 

// POST: courseviewmodels/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, courseviewmodel courseviewmodel)
        {
            if (id != courseviewmodel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var c = _context.course.SingleOrDefault(s => s.id == courseviewmodel.id);
                   
                    c.Name = courseviewmodel.Name;

                    c.hours = courseviewmodel.hours;
                    c.price = courseviewmodel.price;
                    c.start_date = courseviewmodel.start_date;
                    c.end_date = courseviewmodel.end_date;
                    c.teacher = _context.teacher.Find(courseviewmodel.teacherid);
                    c.department = _context.department.Find(courseviewmodel.departmentid);



                    _context.Update(c);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!courseviewmodelExists((int)courseviewmodel.id))
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
            return View(courseviewmodel);
        }

        // GET: courseviewmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.course == null)
            {
                return NotFound();
            }

            var course  = await _context.course.Include(s => s.teacher).Include(s => s.department)
                .FirstOrDefaultAsync(m => m.id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course );
        }

        // POST: courseviewmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.course == null)
            {
                return Problem("Entity set 'ApplicationDbContext.courseviewmodel'  is null.");
            }
            var course = await _context.course.FindAsync(id);
            if (course  != null)
            {
                _context.course.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool courseviewmodelExists(int id)
        {
          return (_context.course?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
