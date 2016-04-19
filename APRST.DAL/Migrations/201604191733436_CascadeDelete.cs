namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories");
            AddForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories");
            AddForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories", "Id");
        }
    }
}
