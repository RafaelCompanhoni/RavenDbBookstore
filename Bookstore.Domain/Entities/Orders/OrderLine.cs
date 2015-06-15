namespace Bookstore.Domain.Entities.Orders
{
    public class OrderLine
    {
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}