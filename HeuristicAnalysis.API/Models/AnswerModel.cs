using System.Collections.Generic;

namespace HeuristicAnalysis.API.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string HeuristicId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Recommendation { get; set; }
        public int Level { get; set; }
        public List<string> Images { get; set; }
    }
}
