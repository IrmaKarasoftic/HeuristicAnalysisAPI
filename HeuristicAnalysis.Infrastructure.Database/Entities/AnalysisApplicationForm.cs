using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class AnalysisApplicationForm
    {
        public int Id { get; set; }
        public virtual ICollection<Heuristic> Heuristics { get; set; }
        public virtual ICollection<UserGroup> Groups { get; set; }
    }
}
