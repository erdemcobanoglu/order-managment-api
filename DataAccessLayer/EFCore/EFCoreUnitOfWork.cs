using DataAccessLayer.EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EFCore
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        private EFContext _context;
        public EFCoreUnitOfWork(EFContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
