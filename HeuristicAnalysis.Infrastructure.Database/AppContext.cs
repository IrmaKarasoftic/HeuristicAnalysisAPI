using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using Version = HeuristicAnalysis.Infrastructure.Database.Entities.Version;

namespace HeuristicAnalysis.Infrastructure.Database
{
    public class AppContext : DbContext
    {
        public AppContext() : base("HeuristicAnalysis") { }
        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<AnalysisApplicationForm> AnalysisApplicationForms { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Heuristic> Heuristics { get; set; }
        public DbSet<HeuristicImage> HeuristicImages { get; set; }
        public DbSet<HeuristicList> HeuristicLists { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Version> Versions { get; set; }
    }
}
