using System.Collections.Generic;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class AnalizaModel
    {
        public int Id { get; set; }
        public AplikacijaModel Aplikacija {get; set; }
        public VerzijaModel Verzija { get; set; }
        public KorisnikModel Korisnik { get; set; }
        public PitanjeModel Pitanje { get; set; }
    }
}
