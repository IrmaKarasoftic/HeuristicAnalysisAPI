namespace HeuristicAnalysis.Infrastructure.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnsweredQuestions", "DatabaseHeuristicId", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "HeuristicId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "HeuristicId");
            DropColumn("dbo.AnsweredQuestions", "DatabaseHeuristicId");
        }
    }
}
