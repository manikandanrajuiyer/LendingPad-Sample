using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Products;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IUpdateOrderService updateOrderService, IOrderRepository orderRepository)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        
        public string Create(Guid id, Guid customerId, List<OrderItem> orderItems)
        {
            var order = _orderFactory.Create(id);
            _updateOrderService.Update(order, customerId, orderItems);
            return _orderRepository.Create(order);
        }
    }
}