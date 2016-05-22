namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeInLogEntry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogEntries", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogEntries", "Date", c => c.String());
        }
    }
}
