using System;
using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class DiagramModel
    {
        public int NumberOfAnswers { get; set; }
        public int LowLevel { get; set; }
        public int MediumLevel { get; set; }
        public int HighLevel { get; set; }
        public int NoLevel { get; set; }
    }
}
