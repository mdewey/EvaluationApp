using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class DataOfUnderstanding
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool UnderstandingYorN { get; set; }
        public int StudentID { get; set; }
    }
}
