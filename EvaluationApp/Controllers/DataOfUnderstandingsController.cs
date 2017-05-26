using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluationApp.Data;
using EvaluationApp.Models;
using EvaluationApp.Models.ViewModels;

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
            var vm = new EvaluatorViewModel
            {
                Students = student, 
                LectureId = lectureId
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Up([FromBody][Bind("StudentsId,LecturesId")] DataOfUnderstanding data)
        {
            // student, lecture, time, t/f
            data.Time = DateTime.Now;
            data.UnderstandingYorN = true;
            
            // TODO: add to database
            _context.Add(data);
            _context.SaveChanges();
            return Json("successful upvote");
        }

        [HttpPost]
        public ActionResult Down([FromBody][Bind("StudentsId,LecturesId")] DataOfUnderstanding data)
        {
            // student, lecture, time, t/f
            data.Time = DateTime.Now;
            data.UnderstandingYorN = false;

            // TODO: add to database
            _context.Add(data);
            _context.SaveChanges();
            return Json("successful downvote");
        }
    }
}
