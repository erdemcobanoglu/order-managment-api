using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using EntityLayer;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        private ICustomerService _customerService;
        private IProductService _productService;
        public OrdersController(IOrderService orderService, ICustomerService customerService, IProductService productService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderForCreationDto order)
        {

            var validation = PreInsertAndUpdateValidation(order);


            if (!validation.FirstOrDefault().Value)
                return BadRequest(validation.FirstOrDefault().Key);

            var result = _orderService.Add(order);


            if (result != null)
                return Ok(result);
            else
                return BadRequest("Sipariş Kaydedilemedi!");

        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
           
            if (orderId < 1)
                return BadRequest("Hatalı sipariş numarası!");



            Order orderModel = _orderService.GetOrder(orderId);

            if (orderModel == null)
                return BadRequest("Kayıt bulunamadı!");

             

            var result = _orderService.Delete(orderModel);
            if (result)
                return Ok(result);
            else
                return BadRequest("Silme işlemi yapılamadı!");

        }

        [HttpDelete("{orderId}/products/{productId}")]
        public IActionResult DeleteOrderDetail(int orderId, int productId)
        {
            var validation = PreDeleteOrderDetailsValidation(orderId, productId);
            if(!validation.FirstOrDefault().Value)
                return BadRequest(validation.FirstOrDefault().Key);



            var orderDetailModel = _orderService.GetOrderDetail(orderId, productId); 
            if(orderDetailModel == null)
                return BadRequest("Kayıt bulunamadı!");


            var result = _orderService.DeleteOrderDetail(orderDetailModel);
            if (result)
                return Ok(result);
            else
                return BadRequest("Silme işlemi yapılamadı!");

        }

        //Todo: change ModelName
        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder([FromBody] OrderForCreationDto order, int orderId)
        {
            if (orderId < 1)
                return BadRequest("Hatalı sipariş numarası!");

            var validation = PreInsertAndUpdateValidation(order);
            if (!validation.FirstOrDefault().Value)
                return BadRequest(validation.FirstOrDefault().Key);

            var result = _orderService.Update(order, orderId);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Sipariş Kaydedilemedi!");

        }

        private Dictionary<string, bool> PreInsertAndUpdateValidation(OrderForCreationDto order)
        {
            Dictionary<string, bool> validation = new Dictionary<string, bool>();

            var checkCustomerExist = _customerService.IsCustomerExist(order.CustomerId);
             

            foreach (var orderDto in order.OrderDetails)
            {
                var checkProduct = _productService.IsProductAndStockExist(orderDto.ProductId);

                if (!checkProduct)
                {
                    validation.Add("Ürün bulunamadı!", false);
                    return validation;
                }

                var productQuantity = _productService.GetById(orderDto.ProductId);
                if(productQuantity.QuantityPerUnit < orderDto.Quantity)
                {
                    validation.Add($"yeterli miktarda ürün yok {productQuantity.Name} ürününden {orderDto.Quantity - productQuantity.QuantityPerUnit} Adet siliniz!", false);
                    return validation;
                }
            }
            if (!checkCustomerExist)
            {
                validation.Add("Müşteri bulunamadı!", false);
                return validation;
            }
            else
            {
                validation.Add("İşlem devam ediyor.!", true);
                return validation;
            }

        }

        private Dictionary<string, bool> PreDeleteOrderDetailsValidation(int orderId, int productId)
        {
            Dictionary<string, bool> validation = new Dictionary<string, bool>();

            if (orderId < 1)
            {
                validation.Add("sipariş numarası hatası!", false);
                return validation;
            }
            if(productId < 1)
            {
                validation.Add("ürün numarası hatası!", false);
                return validation;
            }
            else
            {
                validation.Add("İşlem devam ediyor.!", true);
                return validation;
            }

        }

    }
}
