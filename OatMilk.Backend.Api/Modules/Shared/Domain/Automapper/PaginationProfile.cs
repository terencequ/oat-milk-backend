using AutoMapper;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Automapper
{
    /// <summary>
    /// Automapper profile for Pagination.
    /// </summary>
    public class PaginationProfile : Profile
    {
        public PaginationProfile()
        {
            CreateMap(typeof(PageResponse<>), typeof(PageResponse<>));
        }
    }
}