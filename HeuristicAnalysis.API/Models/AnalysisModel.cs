using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class AnalysisModel
    {
        public int Id { get; set; }
        public ApplicationModel Aplikacija {get; set; }
        public VersionModel Verzija { get; set; }
        public UserModel Korisnik { get; set; }
        public QuestionModel Pitanje { get; set; }
    }
}
