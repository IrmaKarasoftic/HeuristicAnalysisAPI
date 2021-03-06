﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Recommendation { get; set; }
        public int Level { get; set; }
        public int QuestionAnswerId { get; set; }
        public int HeuristicId { get; set; }
        public bool Answered { get; set; }
        public bool Resolved { get; set; }
        public virtual ICollection<HeuristicImage> Images { get; set; }
    }
}
