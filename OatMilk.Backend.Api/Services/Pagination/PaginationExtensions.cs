using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OatMilk.Backend.Api.Services.Pagination
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
        public static async Task<PageResponse<TEntity>> GetPageResponseAsync<TEntity>(this IQueryable<TEntity> queryable, PageFilter filter)
        {
            var pageIndex = filter.PageIndex is <= 0 or null ? 0 : filter.PageIndex.GetValueOrDefault();
            var pageSize = filter.PageSize is <= 0 or null ? Math.Max(queryable.Count(), 1) : filter.PageSize.GetValueOrDefault();
            var totalCount = await queryable.CountAsync();
            var totalPages = (int) Math.Ceiling(totalCount / (double) pageSize);
            var hasPreviousPage = pageIndex > 0;
            var hasNextPage = pageIndex + 1 < totalPages;
            var items = await queryable.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            
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