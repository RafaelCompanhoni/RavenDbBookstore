using System.Linq;
using Bookstore.Domain.Entities.Books;

namespace Bookstore.Application.Queries.Books
{
    static class ByPriceLimitQuery
    {
        public static IQueryable<Book> ListByPriceLimit(this IQueryable<Book> books, double price)
        {
            return books.Where(b => b.Price <= price);
        }
    }
}
