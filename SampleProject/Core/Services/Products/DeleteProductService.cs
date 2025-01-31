using System;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products

{
    [AutoRegister]
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }
    }
}