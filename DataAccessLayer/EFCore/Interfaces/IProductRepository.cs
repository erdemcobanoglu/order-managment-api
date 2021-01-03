using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EFCore.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Product GetById(int productId);
    }
}
