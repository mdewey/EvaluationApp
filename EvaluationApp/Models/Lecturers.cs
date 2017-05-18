using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class Lecturers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }

        public int CourseID { get; set; }
        public Courses Courses { get; set; }

        //public int UserId { get; set; }
        //public virtual User User { get; set; }

    }
}
