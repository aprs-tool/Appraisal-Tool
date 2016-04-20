using APRST.BLL.DTO;
using APRST.BLL.Interfaces;
using APRST.DAL.Entities;
using APRST.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.BLL.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        IUnitOfWork _uow;
        public TestQuestionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(TestQuestionDTO questionDTO)
        {
            Mapper.CreateMap<TestQuestionDTO, TestQuestion>();
            _uow.TestQuestionRepository.Add(Mapper.Map<TestQuestionDTO, TestQuestion>(questionDTO));
            _uow.Save();
        }

        public IEnumerable<TestQuestionInfoDTO> GetAll()
        {
            Mapper.CreateMap<TestQuestion, TestQuestionInfoDTO>();
            return Mapper.Map<IEnumerable<TestQuestion>, List<TestQuestionInfoDTO>>(_uow.TestQuestionRepository.GetEntities());
        }
    }
}
