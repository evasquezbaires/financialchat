using AutoMapper;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Models;

namespace FinancialChat.Domain.Mappers
{
    public class UserIdentityMapper : Profile
    {
        public UserIdentityMapper()
        {
            CreateMap<UserModel, UserIdentity>();

            CreateMap<UserIdentity, UserModel>();
        }
    }
}
