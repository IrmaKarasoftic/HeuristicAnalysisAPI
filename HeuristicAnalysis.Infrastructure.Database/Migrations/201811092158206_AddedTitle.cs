namespace HeuristicAnalysis.Infrastructure.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heuristics", "HeuristicTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heuristics", "HeuristicTitle");
        }
    }
}
