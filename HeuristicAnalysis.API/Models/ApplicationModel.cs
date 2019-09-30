using System.Collections.Generic;

namespace HeuristicAnalysis.API.Models
{
    public class ApplicationModel
    {
        public ApplicationModel()
        {
            Versions = new List<VersionModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApplicationType { get; set; }
        public List<VersionModel> Versions { get; set; }
    }
}
