using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Analysis
    {
        public int Id { get; set; }
        public virtual User Reviewer { get; set; }
        public virtual Version Version{ get; set; }
        public bool Analyzed { get; set; }
        public virtual ICollection<AnsweredQuestion> QuestionsAndAnswers { get; set; }
    }
}
