using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Dtos
{
    public class OrderForCreationDto 
    {
        public string OrderAddress { get; set; }
        public int CustomerId { get; set; } 
        public List<OrderDetailsForCreationDto> OrderDetails { get; set; }
    }
}
