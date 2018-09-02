using System.Collections.Generic;

namespace HeuristicAnalysis.API.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Heuristic { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Recommendation { get; set; }
        public int Level { get; set; }
    }
}
