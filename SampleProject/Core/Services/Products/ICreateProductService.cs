using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Users
{
    public interface ICreateProductService
    {
        Product Add(Guid id, string name, string description, decimal price, ProductCategory category);
    }
}