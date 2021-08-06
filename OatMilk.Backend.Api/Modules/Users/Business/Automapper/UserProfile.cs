using AutoMapper;
using OatMilk.Backend.Api.Modules.Users.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Users.Data;

namespace OatMilk.Backend.Api.Modules.Users.Business.Automapper
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
