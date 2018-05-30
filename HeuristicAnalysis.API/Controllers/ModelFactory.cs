using System;
using System.Linq;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using AppContext = HeuristicAnalysis.Infrastructure.Database.AppContext;

namespace HeuristicAnalysis.API.Controllers
{
    public class ModelFactory
    {
        public AplikacijaModel Create(Aplikacija aplikacija, AppContext context)
        {
            return new AplikacijaModel()
            {
                Id = aplikacija.Id,
                Naziv = aplikacija.Naziv,
                Url = aplikacija.Url,
                //Verzije = new Repository<Verzija>(context).Get().ToList().Select(verzija => Create(verzija, context)).ToList()
            };
        }

        public VerzijaModel Create(Verzija verzija, AppContext homeContext)
        {
            return new VerzijaModel()
            {
                Id = verzija.Id,
                Datum = verzija.Datum,
                NazivVerzije = verzija.NazivVerzije
            };
        }

        public AnalizaModel Create(Analiza analiza, AppContext context)
        {
            return new AnalizaModel()
            {
                Id = analiza.Id,
                Aplikacija = Create(new Repository<Aplikacija>(context).Get(analiza.IdAplikacije), context),
                Korisnik = Create(new Repository<Korisnik>(context).Get(analiza.IdReviewera), context),
                Verzija = Create(new Repository<Verzija>(context).Get(analiza.IdVerzije), context),
                Pitanje = Create(new Repository<Pitanje>(context).Get(analiza.IdPitanja), context)
            };
        }

        public PitanjeModel Create(Pitanje pitanje, AppContext context)
        {
            return new PitanjeModel()
            {
                Id = pitanje.Id,
                TekstPitanja = pitanje.TekstPitanja,
            };
        }


        public KorisnikModel Create(Korisnik korisnik, AppContext context)
        {
            return new KorisnikModel()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime
            };
        }

        public GrupaKorisnikaModel Create(GrupaKorisnika grupa, AppContext context)
        {
            return new GrupaKorisnikaModel()
            {
                Id = grupa.Id,
                NazivGrupe = grupa.NazivGrupe,
                // Korisnici = grupa.Korisnici.ToList().Select(x => Create(x, context)).ToList();
            };
        }
    }
}