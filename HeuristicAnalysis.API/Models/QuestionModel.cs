using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string HeuristicTitle { get; set; }
        public string HeuristicText { get; set; }
        public ICollection<AnswerModel> Answers { get; set; }
    }
}
