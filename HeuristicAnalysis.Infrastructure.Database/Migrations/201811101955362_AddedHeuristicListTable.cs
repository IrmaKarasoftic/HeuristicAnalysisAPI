namespace HeuristicAnalysis.Infrastructure.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHeuristicListTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeuristicLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeuristicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HeuristicLists");
        }
    }
}
