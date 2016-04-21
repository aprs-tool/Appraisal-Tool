namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answersadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestQuestions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestAnswers", "QuestionId", "dbo.TestQuestions");
            DropIndex("dbo.TestAnswers", new[] { "QuestionId" });
            DropTable("dbo.TestAnswers");
        }
    }
}
