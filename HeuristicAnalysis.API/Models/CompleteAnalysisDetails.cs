using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class CompleteAnalysisDetails
    {
        public int AnalysisId { get; set; }
        public List<HeuristicModel> Heuristics { get; set; }
        public List<GroupModel> Groups { get; set; }
    }
}