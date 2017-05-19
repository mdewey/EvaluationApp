using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class Lectures
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime LectureDate { get; set; }

        public int CoursesId { get; set; }
        public Courses Courses { get; set; }

    }
}
