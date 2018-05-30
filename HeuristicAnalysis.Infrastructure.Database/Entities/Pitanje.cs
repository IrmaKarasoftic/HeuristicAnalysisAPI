using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Pitanje
    {
        public int Id { get; set; }
        public string TekstPitanja { get; set; }
        public string OpisProblema { get; set; }
        public string LokacijaProblema { get; set; }
        public string PreporukaZaPoboljsanje { get; set; }
        public int NivoProblema { get; set; }
    }
}
