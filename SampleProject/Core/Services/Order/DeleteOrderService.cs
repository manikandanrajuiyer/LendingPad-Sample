using System;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders

{
    [AutoRegister]
    public class DeleteOrderService : IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Delete(Guid id)
        {
            _orderRepository.Delete(id);
        }
    }
}