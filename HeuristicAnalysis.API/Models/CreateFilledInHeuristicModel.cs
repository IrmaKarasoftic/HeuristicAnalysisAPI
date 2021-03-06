﻿using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class CreateFilledInHeuristicModel
    {
        public int Id { get; set; }
        public string HeuristicTitle { get; set; }
        public string HeuristicText { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Recommendation { get; set; }
        public int Level { get; set; }
        public List<ImageSrc> Images { get; set; }
    }
}
