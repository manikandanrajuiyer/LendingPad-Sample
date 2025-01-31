using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        IEnumerable<Product> GetProductByCategory(string category);
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}