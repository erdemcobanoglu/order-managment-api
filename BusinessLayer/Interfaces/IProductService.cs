using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{ 
    public interface IProductService
    {
        bool IsProductAndStockExist(int productId);
        Product GetById(int productId);
    }
}
