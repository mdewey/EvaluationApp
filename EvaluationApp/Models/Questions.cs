using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public DateTime TimeAsked { get; set; }
        public string QuestionText { get; set; }

        public int StudentsId { get; set; }
        public Students Students { get; set; }
    }
}
