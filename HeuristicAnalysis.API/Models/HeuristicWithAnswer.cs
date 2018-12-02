using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class HeuristicWithAnswer
    {
        public int Id { get; set; }
        public string HeuristicTitle { get; set; }
        public string HeuristicText { get; set; }
        public List<HeuristicImage> Images { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
