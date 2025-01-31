using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Users
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetAllProductsByCategory(string category);
    }
}