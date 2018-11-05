using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeuristicAnalysis.API.Models
{
    public class CheckedHeuristicModel
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
        public string HeuristicText { get; set; }
    }
}