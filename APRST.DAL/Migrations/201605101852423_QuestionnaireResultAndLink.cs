namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionnaireResultAndLink : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionnaireTypeId = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionnaireTypes", t => t.QuestionnaireTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.QuestionnaireTypeId)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.QuestionnaireResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionnaireQuestionId = c.Int(nullable: false),
                        Answer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionnaireQuestions", t => t.QuestionnaireQuestionId, cascadeDelete: true)
                .Index(t => t.QuestionnaireQuestionId);
            
            CreateTable(
                "dbo.QuestionnaireTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfQuestionnaire = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionnaireResultQuestionnaires",
                c => new
                    {
                        QuestionnaireResult_Id = c.Int(nullable: false),
                        Questionnaire_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionnaireResult_Id, t.Questionnaire_Id })
                .ForeignKey("dbo.QuestionnaireResults", t => t.QuestionnaireResult_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questionnaires", t => t.Questionnaire_Id, cascadeDelete: true)
                .Index(t => t.QuestionnaireResult_Id)
                .Index(t => t.Questionnaire_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questionnaires", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Questionnaires", "QuestionnaireTypeId", "dbo.QuestionnaireTypes");
            DropForeignKey("dbo.QuestionnaireResultQuestionnaires", "Questionnaire_Id", "dbo.Questionnaires");
            DropForeignKey("dbo.QuestionnaireResultQuestionnaires", "QuestionnaireResult_Id", "dbo.QuestionnaireResults");
            DropForeignKey("dbo.QuestionnaireResults", "QuestionnaireQuestionId", "dbo.QuestionnaireQuestions");
            DropIndex("dbo.QuestionnaireResultQuestionnaires", new[] { "Questionnaire_Id" });
            DropIndex("dbo.QuestionnaireResultQuestionnaires", new[] { "QuestionnaireResult_Id" });
            DropIndex("dbo.QuestionnaireResults", new[] { "QuestionnaireQuestionId" });
            DropIndex("dbo.Questionnaires", new[] { "UserProfileId" });
            DropIndex("dbo.Questionnaires", new[] { "QuestionnaireTypeId" });
            DropTable("dbo.QuestionnaireResultQuestionnaires");
            DropTable("dbo.QuestionnaireTypes");
            DropTable("dbo.QuestionnaireResults");
            DropTable("dbo.Questionnaires");
        }
    }
}
