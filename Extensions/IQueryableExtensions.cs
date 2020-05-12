using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoreManagement.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, string SortBy, bool IsSortAscending,
  Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (string.IsNullOrWhiteSpace(SortBy) || !columnsMap.ContainsKey(SortBy))
                return query;

            if (IsSortAscending)
                return query.OrderBy(columnsMap[SortBy]).AsQueryable();
            else
                return query.OrderByDescending(columnsMap[SortBy]).AsQueryable();
        }
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int Page, int PageSize)
        {
            if (Page <= 0)
                Page = 1;

            if (PageSize <= 0)
                PageSize = 10;

            return query.Skip((Page - 1) * PageSize).Take(PageSize);
        }
    }
}