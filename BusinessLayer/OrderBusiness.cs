using BusinessLayer.Helpers;
using BusinessLayer.Interfaces;
using DataAccessLayer.EFCore.Interfaces;
using EntityLayer;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class OrderBusiness : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public OrderBusiness(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public Order Add(OrderForCreationDto orderDto)
        {
            var order = orderDto.MapToOrder(); 

            _orderRepository.Add(order); 

            UpdateProductQuantity(order.OrderDetails);
            _unitOfWork.SaveChanges();
            return order;
        }
        public Order Update(OrderForCreationDto orderDto, int orderId)
        {
            var order = orderDto.MapToOrder(orderId);
            order.Id = orderId;
            order.ModifiedDate = DateTime.Now;

            _orderRepository.Update(order);

            UpdateProductQuantity(order.OrderDetails);
            _unitOfWork.SaveChanges();
            return order;
        }
        public bool Delete(Order order)
        {  
            _orderRepository.Delete(order);


            var productUpdateModel = _orderRepository.GetOrderDetailsDeleteModelById(order.Id);
            DeleteOperationUpdateProductQuantity(productUpdateModel);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteOrderDetail(OrderDetail orderDetail)
        {
            _orderRepository.DeleteOrderDetail(orderDetail);
            _unitOfWork.SaveChanges();
            return true;
        }

        public Order GetOrder(int orderId)
        {
            return _orderRepository.Find(o => o.Id == orderId);
        }

        public OrderDetail GetOrderDetail(int id, int productId)
        {
            return _orderRepository.GetOrderDetailsById(id, productId);
        }

         

        private void UpdateProductQuantity(ICollection<OrderDetail> orderDetail)
        { 
             foreach (var details in orderDetail)
             {
                 var productDbModel = _productRepository.GetById(details.ProductId);
                 productDbModel.QuantityPerUnit = (Int16)(productDbModel.QuantityPerUnit - details.Quantity);
                 _productRepository.Update(productDbModel);
             }  
        }

        private void DeleteOperationUpdateProductQuantity(ICollection<OrderDetail> orderDetail)
        {
            foreach (var details in orderDetail)
            {
                var productDbModel = _productRepository.GetById(details.ProductId);
                productDbModel.QuantityPerUnit = (Int16)(productDbModel.QuantityPerUnit + details.Quantity);
                _productRepository.Update(productDbModel);
            }    
        }


    }
}
