using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Models.Filters
{
    public class AbilityFilter : SortedPageFilter
    {
        public string SearchByName { get; set; }
    }
}