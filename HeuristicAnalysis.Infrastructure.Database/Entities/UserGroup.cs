using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<AnalysisApplicationForm> AnalysisApplicationForm { get; set; }
    }
}
