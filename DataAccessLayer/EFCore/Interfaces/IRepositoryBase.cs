using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.EFCore.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity); 
        TEntity Find(Expression<Func<TEntity, bool>> expression=null);
        ICollection<TEntity> FindList(Expression<Func<TEntity, bool>> expression=null);
    }
}
