using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<JsonResult> GetQuestionnaire()
        {
            return Json(Mapper.Map<IEnumerable<QuestionnaireCategoryIncludeQuestionsDTO>, IEnumerable<QuestionnaireCategoryIncludeQuestionsViewModel>>(await _questionnaireCategoryService.GetAllWithQuestionsAsync()), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetQuestionnaireResult()
        {
            var user =await _userProfileService.GetProfileByIdentityNameAsync(User.Identity.Name);
            return Json(await _questionnaireService.QuestionnaireWithResultsByUserIdAsync(user.Id), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetAllIncludeUserAndType()
        {
            return Json(await _questionnaireService.GetAllIncludeUserAndTypeAsync(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task Add(List<QuestionnaireResultViewModel> results)
        {
            results.RemoveAll(item => item == null);

            var user = await _userProfileService.GetProfileByIdentityNameAsync(User.Identity.Name);
            var questionnaireType = user.Role == "User" ? 1 : 2;

            var questionaire =  await _questionnaireService.QuestionnaireWithResultsByUserIdAsync(user.Id);

            if (questionaire == null)
            {
                var newQuestionaire = new QuestionnaireViewModel()
                {
                    QuestionnaireResults = results,
                    QuestionnaireTypeId = questionnaireType,
                    UserProfileId = user.Id
                };

                await _questionnaireService.AddAsync(Mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(newQuestionaire));
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
                    await _questionnaireResultService.AddResultAsync(Mapper.Map<List<QuestionnaireResultViewModel>, List<QuestionnaireResultDTO>>(resultsAdd), user.Id);
                }
                else
                {
                    var newQuestionaire = new QuestionnaireViewModel()
                    {
                        QuestionnaireResults = resultsAdd,
                        QuestionnaireTypeId = questionnaireType,
                        UserProfileId = user.Id
                    };

                    await _questionnaireService.AddAsync(Mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(newQuestionaire));
                }

                await _questionnaireResultService.UpdateResultAsync(Mapper.Map<List<QuestionnaireResultViewModel>, List<QuestionnaireResultDTO>>(resultsUpdate));
            }

        }
    }
}