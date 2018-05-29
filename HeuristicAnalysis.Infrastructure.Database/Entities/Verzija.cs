using System;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Verzija
    {
        public int Id { get; set; }
        public string NazivVerzije { get; set; }
        public DateTime Datum { get; set; }
    }
}
