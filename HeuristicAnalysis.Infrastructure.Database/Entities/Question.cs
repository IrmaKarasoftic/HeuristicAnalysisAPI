using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Heuristic { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Recommendation { get; set; }
        public int Level { get; set; }
    }
}
