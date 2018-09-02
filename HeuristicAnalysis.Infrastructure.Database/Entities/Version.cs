using System;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Version
    {
        public int Id { get; set; }
        public string VersionName { get; set; }
        public DateTime Date { get; set; }
    }
}
