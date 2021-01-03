using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public string OrderAddress { get; set; }
        public int CustomerId { get; set; }   
        public Customer Customer { get; set; } 
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
