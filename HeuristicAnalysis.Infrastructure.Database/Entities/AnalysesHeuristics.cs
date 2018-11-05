using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class AnalysesHeuristics
    {
        public int Id { get; set; }
        public int AnalysisId { get; set; }
        public int HeuristicId { get; set; }
    }
}
