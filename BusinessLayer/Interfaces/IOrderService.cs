using EntityLayer;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrderService
    {
        Order Add(OrderForCreationDto order);
        Order Update(OrderForCreationDto order, int orderId);
        bool Delete(Order order);
        bool DeleteOrderDetail(OrderDetail orderDetail);

        OrderDetail GetOrderDetail(int id, int productId);
        Order GetOrder(int orderId); 


        //Order Delete(OrderForCreationDto order);
        //Order Add(OrderForCreationDto order);
        //Order Add(OrderForCreationDto order);
    }
}
