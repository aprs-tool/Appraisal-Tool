using APRST.DAL.Entities;
using System.Data.Entity;

namespace APRST.DAL.EF
{
    public class AprstContext:DbContext
    {
        static AprstContext()
        {
            Database.SetInitializer<AprstContext>(new AprstInitializer());
        }

        public AprstContext():base(@"Data Source=.\SQLEXPRESS;Initial Catalog=APRST;Integrated Security=True")
        {
        }

        public AprstContext(string conntectionString):base(conntectionString)
        {
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<QuestionnaireCategory> QuestionnaireCategories { get; set; }
        public DbSet<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<QuestionnaireType> QuestionnaireTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestCategory>()
                  .HasMany<Test>(c => c.Tests)
                  .WithOptional(x => x.TestCategory)
                  .WillCascadeOnDelete(true);

            modelBuilder.Entity<Test>()
                  .HasMany<TestResult>(c => c.Results)
                  .WithOptional(x => x.Test)
                  .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }

    #region DatabaseInitializer

    class AprstInitializer : CreateDatabaseIfNotExists<AprstContext>
    {
        protected override void Seed(AprstContext db)
        {
            db.UserRoles.Add(new UserRole {RoleName = "User"});
            db.UserRoles.Add(new UserRole { RoleName = "Admin" });
            db.TestCategories.Add(new TestCategory()
            {
                NameOfCategory = "ЯП",
                Desc = "Языки программирования",
                Tests = new List<Test>
                {
                   new Test()
                   {
                       NameOfTest = "C# Стартовый",Desc = "Тестирование для начинающих",
                       Questions = new List<TestQuestion>()
                       {
                           new TestQuestion()
                           {
                               Question = "Модификатор доступа который ограничен текущей сборкой?",
                               Answers = new List<TestAnswer>()
                               {
                                   new TestAnswer() {Answer = "internal", Point = 1},
                                   new TestAnswer() {Answer = "public", Point = 0},
                                   new TestAnswer() {Answer = "private", Point = 0},
                                   new TestAnswer() {Answer = "protected", Point = 0},
                               }
                           },
                             new TestQuestion()
                           {
                               Question = "Используя какое пространство имен, можно обратиться к любым, даже закрытым, членам управляемых объектов?",
                               Answers = new List<TestAnswer>()
                               {
                                   new TestAnswer() {Answer = "System.Diagnostics", Point = 0},
                                   new TestAnswer() {Answer = "System.Resources", Point = 0},
                                   new TestAnswer() {Answer = "System.Reflection", Point = 1},
                                   new TestAnswer() {Answer = "System.Security", Point = 0},
                               }
                           }

                       }
                           
                   },
                   new Test() {NameOfTest = "С# Профессиональный",Desc = "Тестирование для профессионалов"},
                   new Test() {NameOfTest = "Программирование на Python 3.0",Desc = "Тестирование для начинаю разработчиков на Python"}
                }
            });

            db.TestCategories.Add(new TestCategory()
            {
                NameOfCategory = "ОС",
                Desc = "Операционные системы",
                Tests = new List<Test>
                {
                   new Test() {NameOfTest = "Windows Server Стартовый",Desc = "Предназначен для начинающих системных администраторов"},
                   new Test() {NameOfTest = "Windows Server Профессиональный",Desc = "Предназначен для администраторов с опытом разработки"},
                   new Test() {NameOfTest = "Администрирование Linux",Desc = "Для администраторов корпоративных сетей с опытом работы не менее полугода"}
                }
            });

            db.TestCategories.Add(new TestCategory()
            {
                NameOfCategory = "Офисные приложения",
                Desc = "Тестирование на знание пакета MS Office",
                Tests = new List<Test>
                {
                   new Test() {NameOfTest = "Работа в Microsoft Excel 2013",Desc = "Предназначен для работников осуществляющих деятельность в MS Excel"},
                   new Test() {NameOfTest = "Работа в Microsoft Word 2013",Desc = "Предназначен для администраторов с опытом разработки"},
                   new Test() {NameOfTest = "Администрирование Linux",Desc = "Предназначен для работников осуществляющих деятельность в MS Excel"}
                }
            });

            db.QuestionnaireCategories.Add(new QuestionnaireCategory()
            {
                NameOfCategory = "Языки программирования",
                Desc = "Опрос по языкам программироваия",
                QuestionnaireQuestions = new List<QuestionnaireQuestion>()
                {
                    new QuestionnaireQuestion() {NameOfQuestion = "C#"},
                    new QuestionnaireQuestion() {NameOfQuestion = "C/C++"},
                    new QuestionnaireQuestion() {NameOfQuestion = "Delphi"},
                    new QuestionnaireQuestion() {NameOfQuestion = "Java"},
                }
            });

            db.QuestionnaireCategories.Add(new QuestionnaireCategory()
            {
                NameOfCategory = "Операционные системы",
                Desc = "Опрос по операционным системам",
                QuestionnaireQuestions = new List<QuestionnaireQuestion>()
                {
                    new QuestionnaireQuestion() {NameOfQuestion = "Windows"},
                    new QuestionnaireQuestion() {NameOfQuestion = "Android"},
                    new QuestionnaireQuestion() {NameOfQuestion = "IOS"},
                }
            });

            db.QuestionnaireCategories.Add(new QuestionnaireCategory()
            {
                NameOfCategory = "Базы данных",
                Desc = "Опрос по базам данных",
                QuestionnaireQuestions = new List<QuestionnaireQuestion>()
                {
                    new QuestionnaireQuestion() {NameOfQuestion = "Microsoft SQL Server"},
                    new QuestionnaireQuestion() {NameOfQuestion = "Oracle"},
                    new QuestionnaireQuestion() {NameOfQuestion = "PostgreSQL"},
                }
            });

            db.QuestionnaireTypes.Add(new QuestionnaireType() {TypeOfQuestionnaire = "User"});
            db.QuestionnaireTypes.Add(new QuestionnaireType() { TypeOfQuestionnaire = "Admin" });
            db.SaveChanges();
        }
    }
#endregion
}
