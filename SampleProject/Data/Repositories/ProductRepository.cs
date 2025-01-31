using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : IProductRepository
    {

        private static List<Product> _products = new List<Product>();

        public ProductRepository()
        {
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            Enum.TryParse(category, out ProductCategory _category);
            return _products?.Where(p => p.Category == _category);
        }

        public Product GetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.SetCategory(product.Category);
                existingProduct.Description = product.Description;
            }
        }

        public void Delete(Guid id)
        {
            var product = GetById(id);

            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}