using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Dtos
{
    public class OrderDetailsForCreationDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
