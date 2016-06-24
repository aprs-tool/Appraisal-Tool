using APRST.DAL.EF;
using APRST.DAL.Interfaces;
using APRST.DAL.Repositories;
using Ninject.Modules;
using System.Data.Entity;

namespace APRST.BLL.Infastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
            Bind<DbContext>().To<AprstContext>();
        }
    }
}
