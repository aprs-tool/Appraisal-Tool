using System.Threading.Tasks;
using System.Web.Mvc;
using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.Controllers
{
    public class QuestionnaireQuestionController : Controller
    {
        private readonly IQuestionnaireQuestionService _questionService;

        public QuestionnaireQuestionController(IQuestionnaireQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task Create(QuestionnaireQuestionViewModel question)
        {
            await _questionService.AddAsync(Mapper.Map<QuestionnaireQuestionViewModel, QuestionnaireQuestionDTO>(question));
        }

        [HttpPost]
        public async Task Edit(QuestionnaireQuestionViewModel question)
        {
            await _questionService.UpdateQuestionAsync(Mapper.Map<QuestionnaireQuestionViewModel, QuestionnaireQuestionDTO>(question));
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _questionService.RemoveQuestionByIdAsync(id);
        }
    }
}