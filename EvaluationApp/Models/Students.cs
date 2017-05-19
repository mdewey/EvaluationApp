
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

        public int DataId { get; set; }
        public DataOfUnderstanding DataofUnderstanding { get; set; }

        public int QuestionId { get; set; }
        public Questions Questions { get; set; }
    }
}
