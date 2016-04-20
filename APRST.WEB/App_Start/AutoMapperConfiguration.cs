using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APRST.BLL.DTO;
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
                cfg.AddProfile(new WebProfile());
            });
        }
    }

    public class WebProfile : Profile
    {
        protected override void Configure()
        {
            //TestController
            Mapper.CreateMap<TestInfoDTO, TestInfoViewModel>();
            Mapper.CreateMap<TestViewModel, TestDTO>();
            Mapper.CreateMap<TestDTO, TestViewModel>();
            Mapper.CreateMap<TestDTO, TestInfoViewModel>();

            //TestCategoryController
            Mapper.CreateMap<TestCategoryViewModel, TestCategoryDTO>();
            Mapper.CreateMap<TestCategoryDTO, TestCategoryViewModel>();
            Mapper.CreateMap<TestDTO, TestForCategoryViewModel>();
            Mapper.CreateMap<TestCategoryIncludeTestsDTO, TestCategoryIncludeTestsViewModel>()
                .ForMember(dto => dto.Tests, opt => opt.MapFrom(src => src.TestDtos));

            //TestQuestionController
            //Mapper.CreateMap<TestQuestionDTO, TestQuestionViewModel>();
            Mapper.CreateMap<TestQuestionViewModel, TestQuestionDTO>();
        }
    }
}