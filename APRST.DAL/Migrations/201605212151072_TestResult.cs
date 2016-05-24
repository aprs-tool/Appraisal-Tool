namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(),
                        Point = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.UserProfileTestResults",
                c => new
                    {
                        UserProfile_Id = c.Int(nullable: false),
                        TestResult_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfile_Id, t.TestResult_Id })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestResults", t => t.TestResult_Id, cascadeDelete: true)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.TestResult_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfileTestResults", "TestResult_Id", "dbo.TestResults");
            DropForeignKey("dbo.UserProfileTestResults", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.TestResults", "TestId", "dbo.Tests");
            DropIndex("dbo.UserProfileTestResults", new[] { "TestResult_Id" });
            DropIndex("dbo.UserProfileTestResults", new[] { "UserProfile_Id" });
            DropIndex("dbo.TestResults", new[] { "TestId" });
            DropTable("dbo.UserProfileTestResults");
            DropTable("dbo.TestResults");
        }
    }
}
