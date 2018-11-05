using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class AnalysisApplication
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int VersionId { get; set; }
    }
}
