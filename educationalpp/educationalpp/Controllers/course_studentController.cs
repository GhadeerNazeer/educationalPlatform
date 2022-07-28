using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using educationalpp.Data;
using educationalpp.Models;
using educationalpp.viewmodel;

namespace educationalpp.Controllers
{
    public class course_studentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public course_studentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: course_student
        public async Task<IActionResult> Index()
        {
              return _context.courses_and_student != null ? 
                          View(await _context.courses_and_student.Include(s => s.student).Include(s => s.course).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.courses_and_student'  is null.");
        }

        // GET: course_student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.courses_and_student == null)
            {
                return NotFound();
            }

            var course_student = await _context.courses_and_student.Include(s => s.student).Include(s => s.course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course_student == null)
            {
                return NotFound();
            }

            return View(course_student);
        }

        // GET: course_student/Create
        public IActionResult Create()
        {
            coursestudentmodel itemm = new coursestudentmodel();
            var students = _context.student.ToList();
             

            itemm.student = new SelectList((System.Collections.IEnumerable)students, "id", "name");
            var courses = _context.course.ToList(); 

            itemm.course = new SelectList((System.Collections.IEnumerable)courses, "id", "Name");
            return View(itemm);
        }

        // POST: course_student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(coursestudentmodel newre)
        {

            course_student cc = new course_student()
            {
                mark = newre.mark,
                student_status =newre.student_status,
                total_payment=newre.total_payment,

                student = _context.student.Find(newre.studentid),
                course = _context.course.Find(newre.courseid)



            }; 
            if (ModelState.IsValid)
            {
                _context.Add(cc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cc);
        }

        // GET: course_student/Edit/5
        public async Task<IActionResult> Edit(int? id)

        {   
            if (id == null || _context.courses_and_student == null)
            {
                return NotFound();
            }

            var co = await _context.courses_and_student.FindAsync(id);
            if (co  == null)
            {
                return NotFound();
            }
            var students = _context.student.ToList();
            var courses = _context.course.ToList();
            var courseviewmodel = new coursestudentmodel
            {
                Id=co.Id, 
                student= new SelectList((System.Collections.IEnumerable) students, "id", "name"),
                course = new SelectList((System.Collections.IEnumerable)courses, "id", "Name"),
                mark =co.mark,
                student_status =co.student_status,
                total_payment =co.total_payment,
                

            };
            return View(courseviewmodel);
        }


        // POST: course_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, coursestudentmodel course_studentmodel)
        {
            if (id != course_studentmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var c = _context.courses_and_student.SingleOrDefault(s => s.Id == course_studentmodel.Id);

                    c.student = _context.student.Find(course_studentmodel.studentid);
                    c.course = _context.course.Find(course_studentmodel.courseid);
                    c.mark = course_studentmodel.mark;
                    c.student_status = course_studentmodel.student_status;
                    c.total_payment = course_studentmodel.total_payment;
               
                    _context.Update(c );
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!course_studentExists((int)course_studentmodel.Id))
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
            return View(course_studentmodel);
        }

        // GET: course_student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.courses_and_student == null)
            {
                return NotFound();
            }

            var course_student = await _context.courses_and_student.Include(s => s.student).Include(s => s.course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course_student == null)
            {
                return NotFound();
            }

            return View(course_student);
        }

        // POST: course_student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.courses_and_student == null)
            {
                return Problem("Entity set 'ApplicationDbContext.courses_and_student'  is null.");
            }
            var course_student = await _context.courses_and_student.FindAsync(id);
            if (course_student != null)
            {
                _context.courses_and_student.Remove(course_student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool course_studentExists(int id)
        {
          return (_context.courses_and_student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
