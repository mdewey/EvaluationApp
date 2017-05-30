
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
        public Guid TempKey { get; set; } = Guid.NewGuid();
        

        public ICollection<DataOfUnderstanding> DataOfUnderstanding { get; set; }

        public ICollection<Questions> Questions { get; set; }

        public int LecturesId { get; set; }
        public Lectures Lectures { get; set; }

    }
}
