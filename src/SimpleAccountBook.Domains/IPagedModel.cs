using System.Collections.Generic;

namespace SimpleAccountBook.Domains
{
    public interface IPagedModel<TModel>
    {
        int CurrentPage { get; init; }
        IEnumerable<TModel> Items { get; init; }
        int Limit { get; init; }
        int TotalItems { get; init; }
        int TotalPages { get; init; }
    }
}