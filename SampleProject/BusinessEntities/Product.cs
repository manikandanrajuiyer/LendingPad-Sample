using System;
using System.Collections.Generic;
using Common.Extensions;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _name;
        private decimal _price;
        private ProductCategory _category;
        private string _description;

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public ProductCategory Category
        {
            get => _category;
            private set => _category = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public void SetCategory(ProductCategory category)
        {
            if (!Enum.IsDefined(typeof(ProductCategory), category))
            {
                throw new ArgumentNullException("Product Category was not valid.");
            }
            _category = category;
        }

    }
}