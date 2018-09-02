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
        public DbSet<Application> Aplikacije { get; set; }
        public DbSet<UserGroup> GrupeKorisnika { get; set; }
        public DbSet<User> Korisnik { get; set; }
        public DbSet<Question> Pitanja { get; set; }
        public DbSet<Entities.Version> Verzije { get; set; }
        public DbSet<Analysis> Analize { get; set; }

    }
}
