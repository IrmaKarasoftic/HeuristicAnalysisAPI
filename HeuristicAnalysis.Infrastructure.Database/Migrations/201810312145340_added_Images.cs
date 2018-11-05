namespace HeuristicAnalysis.Infrastructure.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_Images : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadedImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnalysisId = c.Int(nullable: false),
                        Img = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadedImages");
        }
    }
}
