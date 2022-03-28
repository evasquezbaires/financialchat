using AutoMapper;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Mappers;
using FinancialChat.Domain.Models;
using FinancialChat.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialChat.Test.Mappers
{
    [TestClass]
    public class MessageChatTest
    {
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MessageChatMapper>());
            _mapper = mapperConfig.CreateMapper();
        }

        [TestMethod]
        public void Mapper_ToMessageChatModel_CanMap()
        {
            var fakeObj = MessageChatFake.GetFakeMessageChatEntity();
            var mappedObj = _mapper.Map<MessageChatModel>(fakeObj);

            Assert.IsNotNull(mappedObj);
        }

        [TestMethod]
        public void Mapper_ToMessageChatEntity_CanMap()
        {
            var fakeObj = MessageChatFake.GetFakeMessageChatModel();
            var mappedObj = _mapper.Map<MessageChat>(fakeObj);

            Assert.IsNotNull(mappedObj);
        }
    }
}
