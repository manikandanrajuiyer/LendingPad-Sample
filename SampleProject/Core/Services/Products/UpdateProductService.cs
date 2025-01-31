
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class UpdateProductService : IUpdateProductService
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Update(Product product, string name, string description, decimal price, ProductCategory category)
        {
            product.Name = name;
            product.Description = description;
            product.SetCategory(category);
            product.Price = price;

            _productRepository.Update(product);
        }

    }
}