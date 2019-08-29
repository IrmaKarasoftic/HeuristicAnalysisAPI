using System;
using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class TableReportModel
    {
        public List<TableDiagramItem> TableItems { get; set; }
        public DiagramModel DiagramModel { get; set; }
    }
}
