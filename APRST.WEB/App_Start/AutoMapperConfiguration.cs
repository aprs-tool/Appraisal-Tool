using APRST.BLL.DTO;
using APRST.BLL.Infastructure;
using APRST.WEB.Models;
using AutoMapper;

namespace APRST.WEB
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
            //QuestionnaireController
            CreateMap<QuestionnaireResultViewModel, QuestionnaireResultDTO>().ReverseMap();
            CreateMap<QuestionnaireViewModel, QuestionnaireDTO>()
              .ForMember(dto => dto.QuestionnaireResults, opt => opt.MapFrom(src => src.QuestionnaireResults));
        }
    }
}