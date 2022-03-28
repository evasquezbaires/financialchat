using AutoMapper;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Models;

namespace FinancialChat.Domain.Mappers
{
    public class MessageViewMapper : Profile
    {
        public MessageViewMapper()
        {
            CreateMap<MessageViewModel, MessageView>();

            CreateMap<MessageView, MessageViewModel>();
        }
    }
}
