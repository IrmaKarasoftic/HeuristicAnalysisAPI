using System.Collections.Generic;

namespace HeuristicAnalysis.API.Models
{
    public class PitanjeModel
    {
        public int Id { get; set; }
        public string TekstPitanja { get; set; }
        public string OpisProblema { get; set; }
        public string LokacijaProblema { get; set; }
        public string PreporukaZaPoboljsanje { get; set; }
        public int NivoProblema { get; set; }
    }
}
