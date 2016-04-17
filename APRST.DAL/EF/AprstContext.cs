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
    }
}
