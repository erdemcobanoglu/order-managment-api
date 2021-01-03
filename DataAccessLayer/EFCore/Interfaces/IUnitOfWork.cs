using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EFCore.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
