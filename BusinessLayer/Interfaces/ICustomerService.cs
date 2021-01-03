using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{ 
    public interface ICustomerService
    {
        bool IsCustomerExist(int customerId); 
    }
}
