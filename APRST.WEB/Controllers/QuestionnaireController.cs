using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    public class QuestionnaireController : Controller
    {
        private IQuestionnaireService _questionnaireService;
        private IQuestionnaireCategoryService _questionnaireCategoryService;
        public QuestionnaireController(IQuestionnaireService service, IQuestionnaireCategoryService questionnaireCategoryService)
        {
            _questionnaireService = service;
            _questionnaireCategoryService = questionnaireCategoryService;
        }
        // GET: Questionnaire
        public ActionResult Index()
        {
            //Получаем категории и вопросы для отображения.
             _questionnaireCategoryService.GetAllWithQuestions();
            return View();
        }

        public ActionResult Test()
        {
            /******************ДОБАВЛЕНИЕ********************/
            //QuestionnaireViewModel newQuestionaire = new QuestionnaireViewModel()
            //{
            //    QuestionnaireResults = new List<QuestionnaireResultViewModel>()
            //    {
            //        new QuestionnaireResultViewModel() {QuestionnaireQuestionId = 1,Answer = 10},
            //        new QuestionnaireResultViewModel() {QuestionnaireQuestionId = 2,Answer = 20}
            //    },
            //    QuestionnaireTypeId = 1,
            //    UserProfileId = 4
            //};
            //_questionnaireService.Add(Mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(newQuestionaire));
            /*********************************************************/
        
            //    var test = Mapper.Map<QuestionnaireDTO, QuestionnaireViewModel>(_questionnaireService.QuestionnaireWithResultsByUserId(3));
            return View();
        }
        public ActionResult Questionnaire(int id)
        {
            //получаем анкету, которая содержит ответы на вопросы, на которые ответил пользователь.
            var userQuestionnaire = _questionnaireService.QuestionnaireWithResultsByUserId(4);
            //возвращаем категорию c вопросами
            return View(Mapper.Map<IEnumerable<QuestionnaireCategoryIncludeQuestionsDTO>, IEnumerable<QuestionnaireCategoryIncludeQuestionsViewModel>>(_questionnaireCategoryService.GetAllWithQuestions()));
        }

    }
}