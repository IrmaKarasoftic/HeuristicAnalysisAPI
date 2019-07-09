using System;
using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class ReportModel
    {
        public List<Answer> Answers { get; set; }
        public DiagramModel DiagramModel { get; set; }
    }
}
