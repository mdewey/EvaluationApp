using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; } 

        public ICollection<Lectures> Lectures { get; set; }

        public int LecturersId { get; set; }
        public Lecturers Lecturers { get; set; }
    }
}
