namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Avatar");
        }
    }
}
