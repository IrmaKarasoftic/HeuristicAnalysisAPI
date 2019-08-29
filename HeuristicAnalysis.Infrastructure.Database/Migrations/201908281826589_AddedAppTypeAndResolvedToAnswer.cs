namespace HeuristicAnalysis.Infrastructure.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppTypeAndResolvedToAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Resolved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "ApplicationType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "ApplicationType");
            DropColumn("dbo.Answers", "Resolved");
        }
    }
}
