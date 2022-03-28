using Bogus;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Models;

namespace FinancialChat.Test.Fakes
{
    public static class UserIdentityFake
    {
        public static UserModel GetFakeUserModel()
        {
            return new Faker<UserModel>()
                .RuleFor(c => c.Name, f => f.Internet.UserName())
                .RuleFor(c => c.Password, f => f.Internet.Password())
                .Generate();
        }

        public static UserIdentity GetFakeUserEntity()
        {
            return new Faker<UserIdentity>()
                .RuleFor(c => c.Id, f => f.UniqueIndex)
                .RuleFor(c => c.Name, f => f.Internet.UserName())
                .RuleFor(c => c.Password, f => f.Internet.Password())
                .RuleFor(c => c.CreatedDate, f => f.Date.Recent())
                .Generate();
        }
    }
}
