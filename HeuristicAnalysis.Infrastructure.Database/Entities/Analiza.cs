using System.Collections.Generic;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Analiza
    {
        public int Id { get; set; }
        public int IdAplikacije {get; set; }
        public int IdVerzije { get; set; }
        public int IdReviewera { get; set; }
        public int IdPitanja { get; set; }
        public List<Odgovor> Odgovori { get; set; }
    }
}
