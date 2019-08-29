using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApplicationType { get; set; }
        public virtual ICollection<Version> Versions { get; set; }
    }
}
