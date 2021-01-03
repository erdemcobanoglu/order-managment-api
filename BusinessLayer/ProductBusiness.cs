using BusinessLayer.Interfaces;
using DataAccessLayer.EFCore.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class ProductBusiness : IProductService 
    {
        private IProductRepository _productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetById(int productId)
        {
            return _productRepository.Find(p => p.Id == productId);
        }

        public bool IsProductAndStockExist(int productId)
        {
            if (productId <= 0)
                return false;

            Product product = _productRepository.Find(p => p.Id == productId);

            if (product == null || product.QuantityPerUnit <= 0)
                return false;

            return true;
        }

         
    }
}
