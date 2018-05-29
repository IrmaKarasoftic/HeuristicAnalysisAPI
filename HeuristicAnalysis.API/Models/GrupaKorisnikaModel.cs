using System.Collections.Generic;
using System.Collections.ObjectModel;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class GrupaKorisnikaModel
    {
       
        public int Id { get; set; }
        public string NazivGrupe { get; set; }
        public ICollection<Korisnik> Korisnici { get; set; }
    }
}
