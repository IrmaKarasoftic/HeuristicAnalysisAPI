using System;

namespace HeuristicAnalysis.API.Models
{
    public class VersionModel
    {
        public int Id { get; set; }
        public string VersionName { get; set; }
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public int AnalysisId { get; set; }
    }
}
