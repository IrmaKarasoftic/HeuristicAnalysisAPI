﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class CompleteAnalysisDetails
    {
        public int AnalysisId { get; set; }
        public string ApplicationName { get; set; }
        public List<QuestionModel> Heuristics { get; set; }
    }
}