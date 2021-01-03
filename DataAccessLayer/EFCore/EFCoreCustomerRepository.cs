using DataAccessLayer.EFCore.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EFCore
{  
    public class EFCoreCustomerRepository : EFCoreRepositoryBase<Customer>, ICustomerRepository
    {
        public EFCoreCustomerRepository(EFContext context) : base(context)
        {
        }
    }
}
