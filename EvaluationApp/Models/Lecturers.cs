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

        public ICollection<Courses> Courses { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
