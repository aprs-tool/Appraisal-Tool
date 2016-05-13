using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APRST.BLL.DTO;
using APRST.DAL.Entities;
using AutoMapper;

namespace APRST.BLL.Infastructure
{
    public class BuisnessLayerMapperProfile : Profile
    {
        protected override void Configure()
        {
            //TestService
            CreateMap<TestDTO, Test>().ReverseMap();
            CreateMap<Test, TestInfoDTO>()
               .ForMember("Category", opt => opt.MapFrom(src => src.TestCategory.NameOfCategory));
            CreateMap<TestQuestion, TestQuestionDTO>();
            CreateMap<Test, TestIncludeQuestionsDTO>()
                .ForMember(dto => dto.QuestionsDTO, opt => opt.MapFrom(src => src.Questions));

            //TestQuestionService
            CreateMap<TestQuestionDTO, TestQuestion>().ReverseMap();
            CreateMap<TestQuestion, TestQuestionInfoDTO>();
            CreateMap<TestAnswer, TestAnswerDTO>();
            CreateMap<TestQuestion, TestQuestionIncludeAnswersDTO>()
                .ForMember(dto => dto.AnswersDTO, opt => opt.MapFrom(src => src.Answers));

            //TestCategoryService
            CreateMap<TestCategoryDTO, TestCategory>().ReverseMap();
            CreateMap<TestCategory, TestCategoryIncludeTestsDTO>()
                .ForMember(dto => dto.TestDtos, opt => opt.MapFrom(src => src.Tests));

            //TestAnswerService
            CreateMap<TestAnswerDTO, TestAnswer>().ReverseMap();

            //UserProfileService
            CreateMap<UserProfile, UserProfileIncludeTestsDTO>().ForMember(s=>s.Role,opt=>opt.MapFrom(src=>src.UserRole.RoleName));
            CreateMap<UserProfileDTO, UserProfile>().ReverseMap();

            //QuestionnaireQuestionService
            CreateMap<QuestionnaireQuestionDTO, QuestionnaireQuestion>().ReverseMap();

            //QuestionnaireCategoryService
            CreateMap<QuestionnaireCategoryDTO, QuestionnaireCategory>().ReverseMap();
            CreateMap<QuestionnaireCategory, QuestionnaireCategoryIncludeQuestionsDTO>()
                .ForMember(dto => dto.QuestionnaireQuestionDtos, opt => opt.MapFrom(src => src.QuestionnaireQuestions));

            //QuestionnaireService
            CreateMap<QuestionnaireResultDTO, QuestionnaireResult>().ReverseMap();
            CreateMap<Questionnaire, QuestionnaireDTO>().ReverseMap();
            CreateMap<Questionnaire, QuestionnaireDTO>()
                .ForMember(s => s.QuestionnaireResults, opt => opt.MapFrom(src => src.QuestionnaireResults));
        }
    }
}
