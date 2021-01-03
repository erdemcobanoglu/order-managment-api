using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
