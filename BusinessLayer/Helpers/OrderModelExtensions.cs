using EntityLayer;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Helpers
{
    public static class OrderModelExtensions
    {
        public static Order MapToOrder(this OrderForCreationDto orderDto, int orderId = 0)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (var orderDetailDto in orderDto.OrderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = orderDetailDto.ProductId,
                    Quantity = orderDetailDto.Quantity,
                    OrderId=orderId
                };

                orderDetails.Add(orderDetail);
            }

            var model = new Order()
            {
                CustomerId = orderDto.CustomerId,
                OrderDetails = orderDetails,
                CreatedDate = DateTime.Now,
                OrderAddress = orderDto.OrderAddress
            };



            return model;
        }
    }
}
