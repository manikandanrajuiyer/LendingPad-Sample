using System;

namespace BusinessEntities
{
    public class OrderItem
    {

        private Guid _productId;
        private int _quantity;

        public int Quantity
        {
            get => _quantity;

            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity is mandatory, must be greater than 0");

                _quantity = value;
            }

        }

        public Guid ProductId
        {
            get => _productId;

            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("Product Id is mandatory.");

                _productId = value;
            }

        }

    }
}