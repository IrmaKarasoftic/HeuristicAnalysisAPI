using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class CheckedHeuristicModel
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
        public string HeuristicTitle { get; set; }
        public string HeuristicText { get; set; }
        public List<string> Images { get; set; }
    }
}