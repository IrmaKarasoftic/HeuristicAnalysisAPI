using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeuristicAnalysis.Infrastructure.Services.Entities
{
    internal class GrupaKorisnika
    {
        public GrupaKorisnika()
        {
            Korisnici = new Collection<Korisnik>();
        }
        public int Id { get; set; }
        public string NazivGrupe { get; set; }
        public ICollection<Korisnik> Korisnici { get; set; }
    }
}
