using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APRST.WEB.Controllers.WebApi.Questionnaires
{
    public class QuestionnairesController : ApiController
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IQuestionnaireResultService _questionnaireResultService;
        private readonly IUserProfileService _userProfileService;

        public QuestionnairesController(IQuestionnaireService questionnaireService, IQuestionnaireResultService questionnaireResultService, IUserProfileService userProfileService)
        {
            _questionnaireService = questionnaireService;
            _questionnaireResultService = questionnaireResultService;
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var questionnaires = _questionnaireService.GetAllIncludeUserAndType();
            return questionnaires != null ? Request.CreateResponse(HttpStatusCode.OK, questionnaires) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения списка анкет.");
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var questionnaireResult = _questionnaireService.QuestionnaireWithResultsByUserId(id);
            return questionnaireResult != null ? Request.CreateResponse(HttpStatusCode.OK, questionnaireResult) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения анкеты пользователя.");
        }

        [HttpPost]
        public void AddOrUpdate(List<QuestionnaireResultViewModel> results)
        {
            //:TODO Написано ногой, с закрытыми глазами. Написать адекватный сервис, вынести логику.
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
