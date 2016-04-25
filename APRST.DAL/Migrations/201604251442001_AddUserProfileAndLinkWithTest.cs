namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileAndLinkWithTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserPrincipalName = c.String(),
                        SamAccoutName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfileTests",
                c => new
                    {
                        UserProfile_Id = c.Int(nullable: false),
                        Test_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfile_Id, t.Test_Id })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.Test_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfileTests", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.UserProfileTests", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfileTests", new[] { "Test_Id" });
            DropIndex("dbo.UserProfileTests", new[] { "UserProfile_Id" });
            DropTable("dbo.UserProfileTests");
            DropTable("dbo.UserProfiles");
        }
    }
}
