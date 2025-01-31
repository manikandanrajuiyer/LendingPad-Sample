
using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Update(Order order, Guid customerId, List<OrderItem> orderItems)
        {
            order.OrderItems = orderItems;
            order.CustomerId = customerId;
            _orderRepository.Update(order);
        }

    }
}