using System.Collections.Generic;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class HeuristicList
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public virtual ICollection<Heuristic> Heuristics { get; set; }
    }
}
