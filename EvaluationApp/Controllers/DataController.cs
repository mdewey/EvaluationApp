using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EvaluationApp.Models;
using EvaluationApp.Data;
using System.Threading;

namespace EvaluationApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Data")]
    public class DataController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> Get(int id)
        {
            //populateData();
            var lectureId = id;
            var numOfStudents = _context.Students.Count(s => s.LecturesId == lectureId);
            var allData = _context.DataOfUnderstanding.Where(w => w.LecturesId == lectureId).ToList();
            var grouped = allData.GroupBy(x => x.StudentsId, value => value);
            //var rv = new List<List<long>>();
            var total = 0D;
            foreach (var item in grouped)
            {
                var dataPoint = new List<long>();
                var lastPoint = item.OrderByDescending(o => o.Time).First();
                if (lastPoint.UnderstandingYorN)
                {
                    total++;
                }
            }
            var rv = (total / numOfStudents) * 100;
            return new List<object> { DateTime.Now.Ticks, rv };
        }
    }
}