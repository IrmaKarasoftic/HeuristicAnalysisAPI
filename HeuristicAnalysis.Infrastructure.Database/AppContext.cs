using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.Infrastructure.Database
{
    public class AppContext : DbContext
    {
        public AppContext() : base("HeuristicAnalysis") { }
        public DbSet<Aplikacija> Aplikacije { get; set; }
        public DbSet<GrupaKorisnika> GrupeKorisnika { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Odgovor> Odgovori { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<Verzija> Verzije { get; set; }
        public DbSet<Analiza> Analize { get; set; }

    }
}
