using Bogus;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Models;

namespace FinancialChat.Test.Fakes
{
    public static class MessageChatFake
    {
        public static MessageChatModel GetFakeMessageChatModel()
        {
            return new Faker<MessageChatModel>()
                .RuleFor(c => c.FromUser, f => f.Random.Number(1, 100))
                .RuleFor(c => c.ToUser, f => f.Random.Number(1, 100))
                .RuleFor(c => c.Message, f => f.Random.AlphaNumeric(20))
                .Generate();
        }

        public static MessageChat GetFakeMessageChatEntity()
        {
            return new Faker<MessageChat>()
                .RuleFor(c => c.Id, f => f.UniqueIndex)
                .RuleFor(c => c.FromUser, f => f.Random.Number(1, 100))
                .RuleFor(c => c.ToUser, f => f.Random.Number(1, 100))
                .RuleFor(c => c.Message, f => f.Random.AlphaNumeric(20))
                .RuleFor(c => c.CreatedDate, f => f.Date.Recent())
                .Generate();
        }
    }
}
