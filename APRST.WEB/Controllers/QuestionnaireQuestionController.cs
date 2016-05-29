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
        public void Create(QuestionnaireQuestionViewModel question)
        {
            _questionService.Add(Mapper.Map<QuestionnaireQuestionViewModel, QuestionnaireQuestionDTO>(question));
        }

        [HttpPost]
        public void Edit(QuestionnaireQuestionViewModel question)
        {
            _questionService.UpdateQuestion(Mapper.Map<QuestionnaireQuestionViewModel, QuestionnaireQuestionDTO>(question));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _questionService.RemoveQuestionById(id);
        }
    }
}