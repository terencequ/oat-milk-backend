using AutoMapper;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Automapper
{
    public class PaginationProfile : Profile
    {
        public PaginationProfile()
        {
            CreateMap(typeof(PageResponse<>), typeof(PageResponse<>));
        }
    }
}