using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class CreateAnalysisModel
    {
        public int AppId {get; set; }
        public int VersionId { get; set; }
        public List<GroupModel> Groups { get; set; }
        public List<CheckedHeuristicModel> Heuristics { get; set; }
    }
}
