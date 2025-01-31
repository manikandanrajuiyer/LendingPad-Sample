using System;
using System.Collections.Generic;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private Guid _customerId;
       
        public List<OrderItem> OrderItems { get; set; }
        
        public decimal TotalPrice { get; set; }
        public Guid CustomerId
        {
            get => _customerId; 
            
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("Customer Id is mandatory.");
                
                _customerId = value;
            }
        }
    }
}