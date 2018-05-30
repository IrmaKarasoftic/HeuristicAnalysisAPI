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

        public Aplikacija Create(AplikacijaModel model, AppContext context)
        {
            return new Aplikacija()
            {
                Id = model.Id,
                Naziv = model.Naziv,
                Url = model.Url
            };
        }

        public Verzija Create(VerzijaModel verzija, AppContext homeContext)
        {
            return new Verzija()
            {
                Id = verzija.Id,
                Datum = verzija.Datum,
                NazivVerzije = verzija.NazivVerzije
            };
        }

        public Pitanje Create(PitanjeModel pitanje, AppContext context)
        {
            return new Pitanje()
            {
                Id = pitanje.Id,
                TekstPitanja = pitanje.TekstPitanja
            };
        }

        public Korisnik Create(KorisnikModel korisnik, AppContext context)
        {
            return new Korisnik()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime
            };
        }

        public GrupaKorisnika Create(GrupaKorisnikaModel grupa, AppContext context)
        {
            return new GrupaKorisnika()
            {
                Id = grupa.Id,
                NazivGrupe = grupa.NazivGrupe,
                //Korisnici
            };
        }

        public Korisnik Create(Korisnik korisnik, AppContext homeContext)
        {
            return new Korisnik()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime
            };
        }
    }
}