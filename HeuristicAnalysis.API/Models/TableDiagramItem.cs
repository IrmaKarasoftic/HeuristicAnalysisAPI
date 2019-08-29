using System;
using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class TableDiagramItem
    {
        public int DatabaseHeuristicId { get; set; }
        public string DatabaseHeuristicTitle { get; set; }
        public int LowLevel { get; set; }
        public int MediumLevel { get; set; }
        public int HighLevel { get; set; }
        public int Total { get; set; }
        public double Percentage { get; set; }
    }
}
