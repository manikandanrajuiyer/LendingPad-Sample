

using System;
using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrdersModel
    {
        public Guid CustomerId { get; set; }
        public List<OrderItem> Order { get; set; }
    }
}