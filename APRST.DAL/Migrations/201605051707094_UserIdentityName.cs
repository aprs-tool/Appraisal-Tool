namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdentityName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "UserIdentityName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "UserIdentityName");
        }
    }
}
