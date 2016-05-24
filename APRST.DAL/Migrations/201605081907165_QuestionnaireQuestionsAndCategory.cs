namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionnaireQuestionsAndCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionnaireCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfCategory = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionnaireQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfQuestion = c.String(),
                        QuestionnaireCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionnaireCategories", t => t.QuestionnaireCategoryId, cascadeDelete: true)
                .Index(t => t.QuestionnaireCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionnaireQuestions", "QuestionnaireCategoryId", "dbo.QuestionnaireCategories");
            DropIndex("dbo.QuestionnaireQuestions", new[] { "QuestionnaireCategoryId" });
            DropTable("dbo.QuestionnaireQuestions");
            DropTable("dbo.QuestionnaireCategories");
        }
    }
}
