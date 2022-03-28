using AutoMapper;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Mappers;
using FinancialChat.Domain.Models;
using FinancialChat.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialChat.Test.Mappers
{
    [TestClass]
    public class UserIdentityTest
    {
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<UserIdentityMapper>());
            _mapper = mapperConfig.CreateMapper();
        }

        [TestMethod]
        public void Mapper_ToUserModel_CanMap()
        {
            var fakeObj = UserIdentityFake.GetFakeUserEntity();
            var mappedObj = _mapper.Map<UserModel>(fakeObj);

            Assert.IsNotNull(mappedObj);
        }

        [TestMethod]
        public void Mapper_ToUserEntity_CanMap()
        {
            var fakeObj = UserIdentityFake.GetFakeUserModel();
            var mappedObj = _mapper.Map<UserIdentity>(fakeObj);

            Assert.IsNotNull(mappedObj);
        }
    }
}
