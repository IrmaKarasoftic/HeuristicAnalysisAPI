using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class HeuristicModel
    {
        public int Id { get; set; }
        public string HeuristicTitle { get; set; }
        public string HeuristicText { get; set; }
    }
}
