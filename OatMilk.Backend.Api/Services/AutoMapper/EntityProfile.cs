using AutoMapper;

namespace OatMilk.Backend.Api.Services.AutoMapper
{
    public class EntityProfile<TRequest, TEntity, TResponse> : Profile
    {
        public EntityProfile() : base()
        {
            CreateMap<TRequest, TEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TEntity, TResponse>();
        }
    }
}