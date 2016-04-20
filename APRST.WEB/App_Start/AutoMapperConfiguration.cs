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
            Mapper.CreateMap<TestCategoryViewModel, TestCategoryDTO>();
            Mapper.CreateMap<TestCategoryDTO, TestCategoryViewModel>();
            Mapper.CreateMap<TestDTO, TestViewModel>();
            Mapper.CreateMap<TestCategoryIncludeTestsDTO, TestCategoryIncludeTestsViewModel>()
                .ForMember(dto => dto.Tests, opt => opt.MapFrom(src => src.TestDtos));
        }
    }
}