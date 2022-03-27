using AutoMapper;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Models;

namespace FinancialChat.Domain.Mapper
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
