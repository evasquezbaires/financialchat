using Bogus;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Models;

namespace FinancialChat.Test.Fakes
{
    public static class MessageViewFake
    {
        public static MessageViewModel GetFakeMessageViewModel()
        {
            return new Faker<MessageViewModel>()
                .RuleFor(c => c.FromUser, f => f.Random.Number(1, 100))
                .RuleFor(c => c.ToUser, f => f.Random.Number(1, 100))
                .Generate();
        }

        public static MessageView GetFakeMessageViewEntity()
        {
            return new Faker<MessageView>()
                .RuleFor(c => c.FromUser, f => f.Random.Number(1, 100))
                .RuleFor(c => c.ToUser, f => f.Random.Number(1, 100))
                .RuleFor(c => c.Top, f => f.Random.Number(1,50))
                .Generate();
        }
    }
}
