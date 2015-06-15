using System;
using System.Linq;
using System.Linq.Expressions;

namespace Bookstore.Application.Queries.Common
{
    public static class CommonExtensionMethods 
    {
        public static IQueryable<TSource> OrderByWithDirection<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> key, bool ascending)
        {
            return ascending ? source.OrderBy(key) : source.OrderByDescending(key);
        }
    }
}
