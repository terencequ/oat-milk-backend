using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Repositories
{
    public class CharacterRepository: UserEntityRepository<Character>
    {
        public CharacterRepository(OatMilkContext oatMilkContext, IHttpContextAccessor httpContextAccessor) : base(oatMilkContext, httpContextAccessor)
        {
        }
    }
}