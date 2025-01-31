using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(Guid id);
        IEnumerable<Order> GetAllOrdersByCustomer(Guid customerId);
        string Create(Order product);
        string Update(Order product);
        void Delete(Guid id);
    }
}