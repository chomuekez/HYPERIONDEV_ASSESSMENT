using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HYPERION_ASSESSMENT.Models;

namespace HYPERION_ASSESSMENT.Controllers
{
    public class StudentsController : Controller
    {
        private readonly CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext _context;

        public StudentsController(CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext context)
        {
            _context = context;
        }

 
        public async Task<IActionResult> Index(string SearchBy, string Search)
        {
            var student = _context.Students.AsQueryable();
            if (SearchBy == "LASTNAME")
            {

                student = student.Where(x => x.Lastname.StartsWith(Search) || Search == null);
            }
            else
            {

                student = student.Where(x => x.Country.Contains(Search) || Search == null);
            }

            return View(await student.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudId,Studentname,Firstname,Lastname,Country")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudId,Studentname,Firstname,Lastname,Country")] Student student)
        {
            if (id != student.StudId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudId))
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
            return View(student);
        }

         
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return _context.Students.Any(e => e.StudId == id);
        }
    }
}
