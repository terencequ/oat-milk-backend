using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public override IQueryable<Character> GetWithIncludes()
        {
            return Get()
                .Include(character => character.Attributes);
        }

        public override void Remove(Character entity)
        {
            OatMilkContext.Attribute.RemoveRange(entity.Attributes);
            entity.ClearAttributes();
            base.Remove(entity);
        }
    }
}