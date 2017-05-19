using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluationApp.Data;
using EvaluationApp.Models;
using Microsoft.AspNetCore.Identity;

namespace EvaluationApp.Controllers
{
    public class LecturersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LecturersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Portal()
        {
            var _userId = _userManager.GetUserId(HttpContext.User);
            var rv = await _context.Lecturers.Include(i => i.Courses).Where(w => w.ApplicationUserId == _userId).Select(s => s.Courses).ToListAsync();
            return View(rv);
        }

        public IActionResult Display()
        {
            return View();
        }

        //// GET: Lecturers
        public async Task<IActionResult> Index()
        {
               return View(await _context.Lecturers.ToListAsync());
            
        }

        // GET: Lecturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lecturers == null)
            {
                return NotFound();
            }

            return View(lecturers);
        }

        // GET: Lecturers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,School,CourseID")] Lecturers lecturers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturers);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lecturers);
        }

        // GET: Lecturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturers.SingleOrDefaultAsync(m => m.Id == id);
            if (lecturers == null)
            {
                return NotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,School,CourseID")] Lecturers lecturers)
        {
            if (id != lecturers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturersExists(lecturers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(lecturers);
        }

        // GET: Lecturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lecturers == null)
            {
                return NotFound();
            }

            return View(lecturers);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecturers = await _context.Lecturers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Lecturers.Remove(lecturers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LecturersExists(int id)
        {
            return _context.Lecturers.Any(e => e.Id == id);
        }
    }
}
