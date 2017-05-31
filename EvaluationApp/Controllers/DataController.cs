using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EvaluationApp.Models;
using EvaluationApp.Data;

namespace EvaluationApp.Controllers
{
    public class DataVM
    {
        public int[] Data { get; set; } = new int[2];
    }

    [Produces("application/json")]
    [Route("api/Data")]
    public class DataController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }
        //ideally i will return an array 
        public async Task<List<List<long>>> Get(int id)
        {
            var lectureId = id;
            var numOfStudents = _context.Students.Count(s => s.LecturesId == lectureId);
            var allData = _context.DataOfUnderstanding.Where(w => w.LecturesId == lectureId).ToList();
            var grouped = allData.GroupBy(x =>
            {
                var stamp = x.Time;
                stamp = stamp.AddMinutes(-(stamp.Minute % 5));
                stamp = stamp.AddMilliseconds(-stamp.Millisecond - 1000 * stamp.Second);
                return stamp.Ticks;
            }, value => value);
            var rv = new List<List<long>>();
            var count = 0;
            foreach (var item in grouped)
            {
                var dataPoint = new List<long>();
                var trued = item.Count(w => w.UnderstandingYorN);
                var falsed = item.Count(w => !w.UnderstandingYorN);
                var total = trued - falsed;
                dataPoint.Add(count++);
                dataPoint.Add(total);
                rv.Add(dataPoint);
            }
            return rv;
        }
    }
}