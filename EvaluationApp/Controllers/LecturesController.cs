using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluationApp.Data;
using EvaluationApp.Models;

namespace EvaluationApp.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        ////Slug Generator
        //public void Slug()
        //{
        //    int[] theArray = new int[1000];
        //    int i = 0;
        //    while (i < theArray.Length)
        //    {
        //        theArray[i] = ++i;
        //    }

        //    Random r = new Random();
        //    while (i > 1)
        //    {
        //        int j = r.Next(i);
        //        int t = theArray[--i];
        //        theArray[i] = theArray[j];
        //        theArray[j] = t;
        //    }

        //    for (i = 0; i < theArray.Length; ++i)
        //    {
        //        Console.WriteLine(theArray[i].ToString());
        //    }
        //}

        //public ActionResult Show(string slug)
        //{
        //    if (slug.Equals(string.Empty))
        //    {
        //        return this.HttpNotFound();
        //    }

        //    var slugPost = slugPostRepository.FindPost(slug);
        //    if (slugPost == null)
        //    {
        //        return this.HttpNotFound();
        //    }

        //    return View(slugPost);
        //}

        //[Route("lecture/{slug}", Name = "UserProfile")]
        public ActionResult StudentPortal()
        {
            return RedirectToAction("/Students/Portal");
        }

        [HttpPost]
        [Route("/lecture/{slug}")]
        public IActionResult Post(int slug)
        {
            string buttonClicked = "";

            if (HttpContext.Request.Form.ContainsKey("urlgenerator"))
            {
                buttonClicked = "urlgenerator";
            }
            else if (HttpContext.Request.Form.ContainsKey("testing"))
            {
                buttonClicked = "testing";
                return RedirectToAction("/Students/Portal");
            }

            return View("Index");
        }

        // GET: Lectures
        public async Task<IActionResult> Index(int id)
        {
            var lectures = _context.Lectures.Include(l => l.Courses);
            ViewData["courseId"] = id;
            return View(await lectures.ToListAsync());
        }

        // GET: Lectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectures = await _context.Lectures
                .Include(l => l.Courses)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lectures == null)
            {
                return NotFound();
            }

            return View(lectures);
        }

        // GET: Lectures/Create
        public IActionResult Create(int id)
        {
            ViewData["CoursesId"] = id;
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subject,LectureDate,CoursesId")] Lectures lectures)
        {
            if (ModelState.IsValid)
            {
                // current course id is added automatically to lecture when created
                _context.Add(lectures);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", lectures.CoursesId);
            return View(lectures);
        }

        // GET: Lectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectures = await _context.Lectures.SingleOrDefaultAsync(m => m.Id == id);
            if (lectures == null)
            {
                return NotFound();
            }
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", lectures.CoursesId);
            return View(lectures);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,LectureDate,CoursesId")] Lectures lectures)
        {
            if (id != lectures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lectures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturesExists(lectures.Id))
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
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", lectures.CoursesId);
            return View(lectures);
        }

        // GET: Lectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectures = await _context.Lectures
                .Include(l => l.Courses)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lectures == null)
            {
                return NotFound();
            }

            return View(lectures);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lectures = await _context.Lectures.SingleOrDefaultAsync(m => m.Id == id);
            _context.Lectures.Remove(lectures);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LecturesExists(int id)
        {
            return _context.Lectures.Any(e => e.Id == id);
        }
    }
}
