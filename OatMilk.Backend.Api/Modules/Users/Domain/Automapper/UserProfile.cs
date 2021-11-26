using AutoMapper;
using OatMilk.Backend.Api.Modules.Users.Data;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Users.Domain.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
