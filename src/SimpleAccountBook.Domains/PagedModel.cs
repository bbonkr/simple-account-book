using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace SimpleAccountBook.Domains
{
    public class PagedModel<TModel> : IPagedModel<TModel>
    {
        public int CurrentPage { get; init; }

        public int Limit { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public IEnumerable<TModel> Items { get; init; }
    }

    public static class PagedModelExtensions
    {
        private const int PAGE = 1;
        private const int LIMIT = 10;
       
        public static async Task<IPagedModel<TModel>> ToPagedModelAsync<TModel>(this IQueryable<TModel> query, int page = PAGE, int limit = LIMIT, CancellationToken cancellationToken = default) where TModel : class 
        {
            var currentPage = page < 0 ? 1 : page;
            var totalItems = await query.CountAsync(cancellationToken);
            var totalPages = (int)(Math.Ceiling(totalItems / (double)limit));

            var skip = (currentPage - 1) * limit;

            var items = await query.Skip(skip).Take(limit).ToListAsync(cancellationToken);

            return new PagedModel<TModel>
            {
                CurrentPage = currentPage,
                Items = items,
                Limit = limit,
                TotalItems = totalItems,
                TotalPages = totalPages,
            };
        }

        public static TResult ToPagedModel<TModel, TResult>(this IQueryable<TModel> query, int page = PAGE, int limit = LIMIT) where TModel : class where TResult : class, IPagedModel<TModel>
        {
            var currentPage = page < 0 ? 1 : page;
            var totalItems = query.Count();
            var totalPages = (int)(Math.Ceiling(totalItems / (double)limit));

            var skip = (currentPage - 1) * limit;

            var items = query.Skip(skip).Take(limit).ToList();

            var result = new PagedModel<TModel>
            {
                CurrentPage = currentPage,
                Items = items,
                Limit = limit,
                TotalItems = totalItems,
                TotalPages = totalPages,
            };

            return result as TResult;
        }
    }
}
