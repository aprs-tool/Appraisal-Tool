using APRST.BLL.Interfaces;
using APRST.BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace APRST.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<ITestService>().To<TestService>();
            kernel.Bind<ITestCategoryService>().To<TestCategoryService>();
            kernel.Bind<ITestQuestionService>().To<TestQuestionService>();
            kernel.Bind<ITestAnswerService>().To<TestAnswerService>();
            kernel.Bind<ITestResultService>().To<TestResultService>();
            kernel.Bind<IUserProfileService>().To<UserProfileService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IQuestionnaireCategoryService>().To<QuestionnaireCategoryService>();
            kernel.Bind<IQuestionnaireQuestionService>().To<QuestionnaireQuestionService>();
            kernel.Bind<IQuestionnaireResultService>().To<QuestionnaireResultService>();
            kernel.Bind<IQuestionnaireService>().To<QuestionnaireService>();
            kernel.Bind<ILogService>().To<LogService>();
        }
    }
}