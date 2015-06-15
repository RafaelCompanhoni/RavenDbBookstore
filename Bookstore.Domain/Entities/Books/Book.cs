using System.Collections.Generic;

namespace Bookstore.Domain.Entities.Books
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int YearPublished { get; set; }
        public List<string> Departments { get; set; }
        public List<Review> CustomerReviews { get; set; }
    }
}