﻿

using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
 
    }
}