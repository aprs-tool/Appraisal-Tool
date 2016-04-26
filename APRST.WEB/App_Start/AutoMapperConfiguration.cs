using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APRST.BLL.DTO;
using APRST.BLL.Infastructure;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB.App_Start
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new BuisnessLayerMapperProfile());
                cfg.AddProfile(new WebProfile());
            });
        }
    }

    public class WebProfile : Profile
    {
        protected override void Configure()
        {
            //TestController
            CreateMap<TestInfoDTO, TestInfoViewModel>();
            CreateMap<TestViewModel, TestDTO>().ReverseMap();
            CreateMap<TestDTO, TestInfoViewModel>();

            //TestCategoryController
            CreateMap<TestCategoryViewModel, TestCategoryDTO>().ReverseMap();
            CreateMap<TestDTO, TestForCategoryViewModel>();
            CreateMap<TestCategoryIncludeTestsDTO, TestCategoryIncludeTestsViewModel>()
                .ForMember(dto => dto.Tests, opt => opt.MapFrom(src => src.TestDtos));

            //TestQuestionController
            //Mapper.CreateMap<TestQuestionDTO, TestQuestionViewModel>();
            CreateMap<TestQuestionViewModel, TestQuestionDTO>().ReverseMap();
            CreateMap<TestIncludeQuestionsDTO, TestWithQuestionViewModel>()
                .ForMember(dto => dto.Questions, opt => opt.MapFrom(src => src.QuestionsDTO));

            //TestAnswerController
            CreateMap<TestAnswerViewModel, TestAnswerDTO>().ReverseMap();
            CreateMap<TestQuestionIncludeAnswersDTO, TestQuestionIncludeAnswersViewModel>()
                .ForMember(dto => dto.Answers, opt => opt.MapFrom(src => src.AnswersDTO));

            //UserController
            CreateMap<UserProfileDTO, UserProfileViewModel>().ReverseMap();

            CreateMap<UserProfileIncludeTestsDTO, UserProfileIncludeTestsViewModel>().ReverseMap();
        }
    }
}