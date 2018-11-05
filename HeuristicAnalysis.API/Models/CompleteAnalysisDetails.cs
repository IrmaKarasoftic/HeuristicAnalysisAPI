using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeuristicAnalysis.API.Models
{
    public class CompleteAnalysisDetails
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string VersionName { get; set; }
        public List<string> Heuristics { get; set; }
        public List<string> Groups { get; set; }
    }
}