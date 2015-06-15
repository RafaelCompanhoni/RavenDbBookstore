namespace Bookstore.Domain.Entities.Books
{
    public class Review
    {
        public int Rating { get; set; } 
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}