using AutoMapper;
using FinancialChat.Domain.Contracts;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Exceptions;
using FinancialChat.Domain.Services;
using FinancialChat.Test.Fakes;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace FinancialChat.Test.Services
{
    [TestClass]
    public class UserManagementTest
    {
        private readonly Mock<IFinancialChatRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<UserManagementService>> _loggerMock;
        private readonly IUserManagementService _userService;

        public UserManagementTest()
        {
            _repositoryMock = new Mock<IFinancialChatRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<UserManagementService>>();

            _userService = new UserManagementService(_repositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [TestMethod]
        public async Task CreateUser_WithNullModel_ThrowsException()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _userService.CreateUserAsync(null));
        }

        [TestMethod]
        public async Task CreateUser_WithExistentModel_ThrowsException()
        {
            var model = UserIdentityFake.GetFakeUserModel();
            _repositoryMock.Setup(r => r.FindUserByNameAsync(It.IsAny<string>())).ReturnsAsync(model.Name);

            await Assert.ThrowsExceptionAsync<ApiException>(() => _userService.CreateUserAsync(model));
        }

        [TestMethod]
        public async Task CreateUser_ValidModel_ReturnsId()
        {
            var model = UserIdentityFake.GetFakeUserModel();
            var entity = UserIdentityFake.GetFakeUserEntity();
            _repositoryMock.Setup(r => r.FindUserByNameAsync(It.IsAny<string>())).ReturnsAsync(string.Empty);
            _mapperMock.Setup(m => m.Map<UserIdentity>(model)).Returns(entity);
            _repositoryMock.Setup(r => r.AddUserAsync(entity)).ReturnsAsync(entity.Id);

            var result = await _userService.CreateUserAsync(model);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, entity.Id);
        }

        [TestMethod]
        public async Task GetUser_WithNullModel_ThrowsException()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _userService.GetUserAsync(null));
        }

        [TestMethod]
        public async Task GetUser_NotExistentModel_ThrowsException()
        {
            var model = UserIdentityFake.GetFakeUserModel();
            _repositoryMock.Setup(r => r.FindUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(string.Empty);

            await Assert.ThrowsExceptionAsync<ApiException>(() => _userService.GetUserAsync(model));
        }

        [TestMethod]
        public async Task GetUser_ExistentModel_ReturnsUser()
        {
            var model = UserIdentityFake.GetFakeUserModel();
            _repositoryMock.Setup(r => r.FindUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(model.Name);

            var result = await _userService.GetUserAsync(model);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, model.Name);
        }
    }
}
