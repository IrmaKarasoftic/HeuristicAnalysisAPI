using System.Collections.Generic;

namespace HeuristicAnalysis.API.Models
{
    public class HeuristicWithAnswer
    {
        public int Id { get; set; }
        public string HeuristicTitle { get; set; }
        public string HeuristicText { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
