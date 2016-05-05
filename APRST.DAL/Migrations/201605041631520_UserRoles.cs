namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserProfiles", "UserRoleId", c => c.Int());
            CreateIndex("dbo.UserProfiles", "UserRoleId");
            AddForeignKey("dbo.UserProfiles", "UserRoleId", "dbo.UserRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.UserProfiles", new[] { "UserRoleId" });
            DropColumn("dbo.UserProfiles", "UserRoleId");
            DropTable("dbo.UserRoles");
        }
    }
}
