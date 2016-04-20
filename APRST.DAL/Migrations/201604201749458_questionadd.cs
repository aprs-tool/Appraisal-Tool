namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questionadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.Tests");
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            DropTable("dbo.TestQuestions");
        }
    }
}
