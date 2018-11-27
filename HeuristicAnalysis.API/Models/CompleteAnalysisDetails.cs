using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class CompleteAnalysisDetails
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string VersionName { get; set; }
        public List<Heuristic> Heuristics { get; set; }
        public List<Group> Groups { get; set; }
    }
}