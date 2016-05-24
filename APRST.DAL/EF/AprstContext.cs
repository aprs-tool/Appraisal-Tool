using APRST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.EF
{
    public class AprstContext:DbContext
    {

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestCategory>()
                  .HasMany<Test>(c => c.Tests)
                  .WithOptional(x => x.TestCategory)
                  .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
