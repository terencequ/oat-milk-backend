using System.Collections.Generic;

namespace OatMilk.Backend.Api.Modules.Shared.Pagination
{
    public class PageResponse<TEntity>
    {
        public int PageIndex  { get; set; }
        public int PageSize   { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        
        public ICollection<TEntity> Items { get; set; }
    }
}