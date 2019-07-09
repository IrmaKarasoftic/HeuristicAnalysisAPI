namespace HeuristicAnalysis.Infrastructure.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAnsweredBoolToAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Answered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "Answered");
        }
    }
}
