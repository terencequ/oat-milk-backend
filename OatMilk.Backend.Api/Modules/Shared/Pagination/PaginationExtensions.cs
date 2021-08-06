using System;
using System.Linq;

namespace OatMilk.Backend.Api.Modules.Shared.Pagination
{
    public static class PaginationExtensions
    {
        /// <summary>
        /// Get the page of a queryable, given a page filter specifying page number and page size.
        /// </summary>
        /// <param name="queryable">Queryable to paginate</param>
        /// <param name="filter">Details of page number and page size</param>
        /// <typeparam name="TEntity">Entity stored within the IQueryable</typeparam>
        /// <returns></returns>
        public static PageResponse<TEntity> GetPageResponse<TEntity>(this IQueryable<TEntity> queryable,
            PageFilter filter)
        {
            var pageIndex = filter.PageIndex is <= 0 or null ? 0 : filter.PageIndex.GetValueOrDefault();
            var pageSize = filter.PageSize is <= 0 or null ? Math.Max(queryable.Count(), 1) : filter.PageSize.GetValueOrDefault();
            var totalCount = queryable.Count();
            var totalPages = (int) Math.Ceiling(totalCount / (double) pageSize);
            var hasPreviousPage = pageIndex > 0;
            var hasNextPage = pageIndex + 1 < totalPages;
            var items = queryable.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            
            return new PageResponse<TEntity>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                HasPreviousPage = hasPreviousPage,
                HasNextPage = hasNextPage,
                Items = items
            };
        }
    }
}