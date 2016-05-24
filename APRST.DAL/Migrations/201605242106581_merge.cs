namespace APRST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Message = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfTest = c.String(),
                        Desc = c.String(),
                        TestCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestCategories", t => t.TestCategoryId, cascadeDelete: true)
                .Index(t => t.TestCategoryId);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.TestAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestQuestions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
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
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserPrincipalName = c.String(),
                        SamAccoutName = c.String(),
                        UserIdentityName = c.String(),
                        Avatar = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        UserRoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId)
                .Index(t => t.UserRoleId);
            
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
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfCategory = c.String(),
                        Desc = c.String(),
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
            DropForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories");
            DropForeignKey("dbo.UserProfiles", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.UserProfileTests", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.UserProfileTests", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfileTestResults", "TestResult_Id", "dbo.TestResults");
            DropForeignKey("dbo.UserProfileTestResults", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Questionnaires", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Questionnaires", "QuestionnaireTypeId", "dbo.QuestionnaireTypes");
            DropForeignKey("dbo.QuestionnaireResultQuestionnaires", "Questionnaire_Id", "dbo.Questionnaires");
            DropForeignKey("dbo.QuestionnaireResultQuestionnaires", "QuestionnaireResult_Id", "dbo.QuestionnaireResults");
            DropForeignKey("dbo.QuestionnaireResults", "QuestionnaireQuestionId", "dbo.QuestionnaireQuestions");
            DropForeignKey("dbo.TestResults", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestAnswers", "QuestionId", "dbo.TestQuestions");
            DropForeignKey("dbo.QuestionnaireQuestions", "QuestionnaireCategoryId", "dbo.QuestionnaireCategories");
            DropIndex("dbo.UserProfileTests", new[] { "Test_Id" });
            DropIndex("dbo.UserProfileTests", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserProfileTestResults", new[] { "TestResult_Id" });
            DropIndex("dbo.UserProfileTestResults", new[] { "UserProfile_Id" });
            DropIndex("dbo.QuestionnaireResultQuestionnaires", new[] { "Questionnaire_Id" });
            DropIndex("dbo.QuestionnaireResultQuestionnaires", new[] { "QuestionnaireResult_Id" });
            DropIndex("dbo.QuestionnaireResults", new[] { "QuestionnaireQuestionId" });
            DropIndex("dbo.Questionnaires", new[] { "UserProfileId" });
            DropIndex("dbo.Questionnaires", new[] { "QuestionnaireTypeId" });
            DropIndex("dbo.UserProfiles", new[] { "UserRoleId" });
            DropIndex("dbo.TestResults", new[] { "TestId" });
            DropIndex("dbo.TestAnswers", new[] { "QuestionId" });
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            DropIndex("dbo.Tests", new[] { "TestCategoryId" });
            DropIndex("dbo.QuestionnaireQuestions", new[] { "QuestionnaireCategoryId" });
            DropTable("dbo.UserProfileTests");
            DropTable("dbo.UserProfileTestResults");
            DropTable("dbo.QuestionnaireResultQuestionnaires");
            DropTable("dbo.TestCategories");
            DropTable("dbo.UserRoles");
            DropTable("dbo.QuestionnaireTypes");
            DropTable("dbo.QuestionnaireResults");
            DropTable("dbo.Questionnaires");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.TestResults");
            DropTable("dbo.TestAnswers");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.Tests");
            DropTable("dbo.QuestionnaireQuestions");
            DropTable("dbo.QuestionnaireCategories");
            DropTable("dbo.LogEntries");
        }
    }
}
