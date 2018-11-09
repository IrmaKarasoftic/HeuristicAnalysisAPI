using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Heuristic
    {
        public int Id { get; set; }
        public string HeuristicTitle { get; set; }
        public string HeuristicText { get; set; }
    }
}
