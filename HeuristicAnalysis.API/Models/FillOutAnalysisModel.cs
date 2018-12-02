using System.Collections.Generic;

namespace HeuristicAnalysis.API.Models
{
    public class FillOutAnalysisModel
    {
        public int AppId { get; set; }
        public int VersionId { get; set; }
        public List<CreateFilledInHeuristicModel> Heuristics { get; set; }
    }
}