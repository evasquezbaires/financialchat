using AutoMapper;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Models;

namespace FinancialChat.Domain.Mappers
{
    public class MessageChatMapper : Profile
    {
        public MessageChatMapper()
        {
            CreateMap<MessageChatModel, MessageChat>();

            CreateMap<MessageChat, MessageChatModel>();
        }
    }
}
