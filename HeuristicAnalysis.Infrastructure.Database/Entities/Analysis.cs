using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Analysis
    {
        public int Id { get; set; }
        public int ApplicationId {get; set; }
        public int VersionId { get; set; }
        public int ReviewerId { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionsAndAnswers { get; set; }
    }
}
