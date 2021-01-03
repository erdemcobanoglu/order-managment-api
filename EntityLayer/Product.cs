using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class Product: BaseEntity
    {
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public Int16 QuantityPerUnit { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}