using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Products;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IUpdateProductService _updateProductService;
        private readonly IIdObjectFactory<Product> _productFactory;
        private readonly IProductRepository _productRepository;

        public CreateProductService(IIdObjectFactory<Product> productFactory, IUpdateProductService updateProductService, IProductRepository productRepository)
        {
            _productFactory = productFactory;
            _productRepository = productRepository;
            _updateProductService = updateProductService;
        }

        public Product Add(Guid id, string name, string description, decimal price, ProductCategory category)
        {
            var product = _productFactory.Create(id);
            _updateProductService.Update(product, name, description, price, category);
            _productRepository.Add(product);

            return product;
        }
    }
}