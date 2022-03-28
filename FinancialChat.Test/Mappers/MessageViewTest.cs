using AutoMapper;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Mappers;
using FinancialChat.Domain.Models;
using FinancialChat.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialChat.Test.Mappers
{
    [TestClass]
    public class MessageViewTest
    {
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MessageViewMapper>());
            _mapper = mapperConfig.CreateMapper();
        }

        [TestMethod]
        public void Mapper_ToMessageViewModel_CanMap()
        {
            var fakeObj = MessageViewFake.GetFakeMessageViewEntity();
            var mappedObj = _mapper.Map<MessageViewModel>(fakeObj);

            Assert.IsNotNull(mappedObj);
        }

        [TestMethod]
        public void Mapper_ToMessageViewEntity_CanMap()
        {
            var fakeObj = MessageViewFake.GetFakeMessageViewModel();
            var mappedObj = _mapper.Map<MessageView>(fakeObj);

            Assert.IsNotNull(mappedObj);
        }
    }
}
