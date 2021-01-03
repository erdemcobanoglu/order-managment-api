using DataAccessLayer.EFCore.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EFCore
{
    public class EFCoreProductRepository : EFCoreRepositoryBase<Product>, IProductRepository
    {
        private EFContext _context;
        public EFCoreProductRepository(EFContext context) : base(context)
        {
            _context = context;
        }
         
        public Product GetById(int productId)
        {
            return _context.Products.Where(p => p.Id == productId).FirstOrDefault();
        }
    }
}
