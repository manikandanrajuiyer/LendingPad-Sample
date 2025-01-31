using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        string Create(Guid id, Guid customerId, List<OrderItem> orderItems);
    }
}