namespace HeuristicAnalysis.Infrastructure.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalysisApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnalysesGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnalysisId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnalysesHeuristics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnalysisId = c.Int(nullable: false),
                        HeuristicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnalysesHeuristics");
            DropTable("dbo.AnalysesGroups");
            DropTable("dbo.AnalysisApplications");
        }
    }
}
