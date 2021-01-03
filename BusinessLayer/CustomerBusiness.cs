using BusinessLayer.Interfaces;
using DataAccessLayer.EFCore.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class CustomerBusiness : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerBusiness(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // ToDo: elden geçir.
        public bool IsCustomerExist(int customerId)
        {
            if (customerId <= 0)
                return false;

            Customer customer = _customerRepository.Find(c => c.Id == customerId);

            if (customer == null)
                return false;

            return true;
        }
    }
}
