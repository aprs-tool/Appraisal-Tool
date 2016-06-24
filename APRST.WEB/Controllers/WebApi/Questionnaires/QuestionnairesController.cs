using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;

namespace APRST.WEB.Controllers.WebApi.Questionnaires
{
    public class QuestionnairesController : ApiController
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IQuestionnaireResultService _questionnaireResultService;
        private readonly IUserProfileService _userProfileService;
        private readonly Logger _logger;

        public QuestionnairesController(IQuestionnaireService questionnaireService, IQuestionnaireResultService questionnaireResultService, IUserProfileService userProfileService)
        {
            _questionnaireService = questionnaireService;
            _questionnaireResultService = questionnaireResultService;
            _userProfileService = userProfileService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            var questionnaires = await _questionnaireService.GetAllIncludeUserAndTypeAsync();
            return questionnaires != null ? Request.CreateResponse(HttpStatusCode.OK, questionnaires) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения списка анкет.");
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            var questionnaireResult = await _questionnaireService.QuestionnaireWithResultsByUserIdAsync(id);
            return questionnaireResult != null ? Request.CreateResponse(HttpStatusCode.OK, questionnaireResult) : Request.CreateResponse(HttpStatusCode.NotFound, "Ошибка получения анкеты пользователя.");
        }

        [HttpPost]
        public async Task AddOrUpdate(List<QuestionnaireResultViewModel> results)
        {
            //:TODO Написано ногой, с закрытыми глазами. Написать адекватный сервис, вынести логику.
            results.RemoveAll(item => item == null);

            var user = await _userProfileService.GetProfileByIdentityNameAsync(User.Identity.Name);
            var questionnaireType = user.Role == "User" ? 1 : 2;

            var questionaire = await _questionnaireService.QuestionnaireWithResultsByUserIdAsync(user.Id);

            if (questionaire == null)
            {
                var newQuestionaire = new QuestionnaireViewModel()
                {
                    QuestionnaireResults = results,
                    QuestionnaireTypeId = questionnaireType,
                    UserProfileId = user.Id
                };

                await _questionnaireService.AddAsync(Mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(newQuestionaire));
                _logger.Info($"Заполнена анкета");
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
                _logger.Info($"Осуществлено редактирование анкеты");
            }
        }
    }
}
