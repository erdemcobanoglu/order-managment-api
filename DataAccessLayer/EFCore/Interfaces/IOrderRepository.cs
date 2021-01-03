using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EFCore.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        OrderDetail GetOrderDetailsById(int orderId, int productId);
        void DeleteOrderDetail(OrderDetail orderDetail);


        ICollection<OrderDetail> GetOrderDetailsDeleteModelById(int orderId);

    }
}
