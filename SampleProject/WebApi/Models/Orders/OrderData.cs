using System;
using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            CustomerId = order.CustomerId;
            OrderItems = order.OrderItems;
            TotalPrice = order.TotalPrice;
        }

        public Guid CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}