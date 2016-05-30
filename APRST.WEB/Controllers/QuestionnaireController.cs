using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IQuestionnaireCategoryService _questionnaireCategoryService;
        private readonly IQuestionnaireResultService _questionnaireResultService;
        private readonly IUserProfileService _userProfileService;

        public QuestionnaireController(IQuestionnaireService service, IQuestionnaireCategoryService questionnaireCategoryService, IUserProfileService userProfileService, IQuestionnaireResultService questionnaireResultService)
        {
            _questionnaireService = service;
            _questionnaireCategoryService = questionnaireCategoryService;
            _userProfileService = userProfileService;
            _questionnaireResultService = questionnaireResultService;
        }

        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Manage()
        {
            return View();
        }

        public JsonResult GetQuestionnaire()
        {
            return Json(Mapper.Map<IEnumerable<QuestionnaireCategoryIncludeQuestionsDTO>, IEnumerable<QuestionnaireCategoryIncludeQuestionsViewModel>>(_questionnaireCategoryService.GetAllWithQuestions()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuestionnaireResult()
        {
            var user = _userProfileService.GetProfileByIdentityName(User.Identity.Name);
            return Json(_questionnaireService.QuestionnaireWithResultsByUserId(user.Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllIncludeUserAndType()
        {
            return Json(_questionnaireService.GetAllIncludeUserAndType(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Add(List<QuestionnaireResultViewModel> results)
        {
            results.RemoveAll(item => item == null);

            var user = _userProfileService.GetProfileByIdentityName(User.Identity.Name);
            var questionnaireType = user.Role == "User" ? 1 : 2;

            var questionaire = _questionnaireService.QuestionnaireWithResultsByUserId(user.Id);

            if (questionaire == null)
            {
                var newQuestionaire = new QuestionnaireViewModel()
                {
                    QuestionnaireResults = results,
                    QuestionnaireTypeId = questionnaireType,
                    UserProfileId = user.Id
                };

                _questionnaireService.Add(Mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(newQuestionaire));
            }
            else
            {
                var existing = questionaire.QuestionnaireResults
                .Select(c => new { c.Id, c.QuestionnaireQuestionId, c.Answer });

                var resultsUpdate = results
                    .Where(x => existing.Any(y => y.QuestionnaireQuestionId == x.QuestionnaireQuestionId))
                    .ToList();

                var resultsAdd = results
                    .Where(x => existing.All(y => y.QuestionnaireQuestionId != x.QuestionnaireQuestionId))
                    .ToList();

                resultsUpdate.ForEach(x =>
                {
                    var firstOrDefault = existing.FirstOrDefault(y => y.QuestionnaireQuestionId == x.QuestionnaireQuestionId);
                    if (firstOrDefault != null)
                        x.Id = firstOrDefault.Id;
                });

                if (questionaire.UserProfileId == user.Id)
                {
                    _questionnaireResultService.AddResult(Mapper.Map<List<QuestionnaireResultViewModel>, List<QuestionnaireResultDTO>>(resultsAdd), user.Id);
                }
                else
                {
                    var newQuestionaire = new QuestionnaireViewModel()
                    {
                        QuestionnaireResults = resultsAdd,
                        QuestionnaireTypeId = questionnaireType,
                        UserProfileId = user.Id
                    };

                    _questionnaireService.Add(Mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(newQuestionaire));
                }

                _questionnaireResultService.UpdateResult(Mapper.Map<List<QuestionnaireResultViewModel>, List<QuestionnaireResultDTO>>(resultsUpdate));
            }

        }
    }
}