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
        public DbSet<Application> Applications { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Heuristic> Heuristics { get; set; }
        public DbSet<Entities.Version> Versions { get; set; }
        public DbSet<Analysis> Analysis { get; set; }

    }
}
