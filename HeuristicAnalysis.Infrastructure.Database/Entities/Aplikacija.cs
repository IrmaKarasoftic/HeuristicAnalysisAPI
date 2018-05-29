using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Aplikacija
    {
        public Aplikacija()
        {
            Verzije = new Collection<Verzija>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Url { get; set; }
        public ICollection<Verzija> Verzije { get; set; }
    }
}
