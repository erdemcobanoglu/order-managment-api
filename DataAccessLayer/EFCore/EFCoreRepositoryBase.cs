using DataAccessLayer.EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.EFCore
{
    public class EFCoreRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,  new()
    {
        private EFContext _context;
        public EFCoreRepositoryBase(EFContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity); 
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression = null)
        {
             return  _context.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public ICollection<TEntity> FindList(Expression<Func<TEntity, bool>> expression = null)
        {
             return _context.Set<TEntity>().Where(expression).ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
