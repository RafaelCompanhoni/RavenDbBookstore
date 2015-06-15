using System;
using System.Collections.Generic;
using Bookstore.Domain.Entities.Orders.ValueObjects;

namespace Bookstore.Domain.Entities.Orders
{
    public class Order
    {
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CustomerId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}