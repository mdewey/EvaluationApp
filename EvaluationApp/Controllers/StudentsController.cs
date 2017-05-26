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
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // Student Portal: Requests student name
        //public async Task<IActionResult> Portal(int id)
        //{
        //    var students = _context.Students.Include(l => l.Lectures);
        //    ViewData["lectureId"] = id;
        //    return View(await students.ToListAsync());
        //}

        public IActionResult Portal(int id)
        {
            ViewData["lecturesId"] = id;
            return View();
        }

        // Student Evaluator Tool
        public IActionResult Evaluator()
        {
            return View();
        }
    }
}
