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
    public class DataOfUnderstandingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataOfUnderstandingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DataOfUnderstandings
        public async Task<IActionResult> Index(string name, int lectureId)
        {
            // query the database to check if the student exists (going to models)
            var student = _context.Students.FirstOrDefault(f => f.Name == name);
            // if it does not exist, we want to add to the database and pass it the viewmodel (creating if new student)
            if (student == null)
            {
                student = new Students
                {
                    Name = name,
                    LecturesId = lectureId,
                };
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            return View(student);
        }
    }
}
