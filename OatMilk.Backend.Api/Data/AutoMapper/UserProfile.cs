using AutoMapper;
using OatMilk.Backend.Api.Data.Models.Entities;
using OatMilk.Backend.Api.Data.Models.Requests;
using OatMilk.Backend.Api.Data.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile() : base()
        {
            CreateMap<UserRegisterRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
