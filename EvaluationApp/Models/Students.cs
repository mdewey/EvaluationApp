
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid TempKey { get; set; }
        public int DataID { get; set; }
        public int LectureID { get; set; }
    }
}
