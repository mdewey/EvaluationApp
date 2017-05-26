using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models.ViewModels
{
    public class EvaluatorViewModel
    {
        public DataOfUnderstanding DataOfUnderstanding { get; set; }
        public DateTime Time { get; set; }
        public bool UnderstandingYorN { get; set; }

        public Questions Questions { get; set; }
        public DateTime TimeAsked { get; set; }
        public string QuestionText { get; set; }

        public Students Students { get; set; }

        public int LectureId { get; set; }
    }
}
