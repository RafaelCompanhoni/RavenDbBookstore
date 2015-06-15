using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Domain.Entities.Orders.ValueObjects
{
    public enum OrderStatus
    {
        Create = 0,
        Processed = 1,
        Canceled = 2
    }
}