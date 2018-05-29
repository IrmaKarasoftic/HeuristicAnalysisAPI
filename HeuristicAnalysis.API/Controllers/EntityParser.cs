using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class EntityParser
    {
        public Analiza Create(AnalizaModel model, AppContext context)
        {
            return new Analiza()
            {
                Id = model.Id,
                IdAplikacije = model.Aplikacija.Id,
                IdPitanja = model.Pitanje.Id,
                IdReviewera = model.Korisnik.Id,
                IdVerzije = model.Verzija.Id
            };
        }
    }
}