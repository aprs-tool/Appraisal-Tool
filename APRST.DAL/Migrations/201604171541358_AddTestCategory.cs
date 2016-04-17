namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfCategory = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tests", "TestCategoryId", c => c.Int());
            CreateIndex("dbo.Tests", "TestCategoryId");
            AddForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories");
            DropIndex("dbo.Tests", new[] { "TestCategoryId" });
            DropColumn("dbo.Tests", "TestCategoryId");
            DropTable("dbo.TestCategories");
        }
    }
}
