using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : IOrderRepository
    {

        private static List<Order> _orders = new List<Order>();
        private readonly IProductRepository _productRepository;
        public OrderRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        public string Create(Order order)
        {
            decimal totalPrice = 0;
            foreach(var item in order.OrderItems)
            {
                var product = _productRepository.GetById(item.ProductId);

                if (product == null) return $"Product {item.ProductId} not found.";

                totalPrice += item.Quantity * product.Price;
            }


            order.TotalPrice = totalPrice;

            _orders.Add(order);

            return null;
        }

        public void Delete(Guid id)
        {
            var order = GetById(id);

           _orders.Remove(order);

        }

        public IEnumerable<Order> GetAll() => _orders;


        public Order GetById(Guid id) => _orders?.FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetAllOrdersByCustomer(Guid customerId)
        {
            return _orders?.Where(o => o.CustomerId == customerId);
        }

        public string Update(Order order)
        {
            decimal totalPrice = 0;
            var existing = GetById(order.Id);
            if (existing == null) return "Order not found.";
            foreach( var item in order.OrderItems)
            {
                var product = _productRepository.GetById(item.ProductId);
                if (product == null) return "Product not found.";

                totalPrice += item.Quantity * product.Price;

            }
            

            existing.OrderItems = order.OrderItems;
            existing.TotalPrice = totalPrice;

            return null;
        }
    }
}