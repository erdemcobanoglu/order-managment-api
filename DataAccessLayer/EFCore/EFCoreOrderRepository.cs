using DataAccessLayer.EFCore.Interfaces;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EFCore
{
    public  class EFCoreOrderRepository: EFCoreRepositoryBase<Order>,  IOrderRepository
    {
        private EFContext _context;
        public EFCoreOrderRepository(EFContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
        }

        public OrderDetail GetOrderDetailsById(int orderId, int productId)
        {
            return _context.OrderDetails.Where(o => o.OrderId == orderId && o.ProductId == productId).FirstOrDefault();
        }

        public ICollection<OrderDetail> GetOrderDetailsDeleteModelById(int orderId)
        {
            return _context.OrderDetails.Where(o => o.OrderId == orderId).ToList();
        }
    }
}
