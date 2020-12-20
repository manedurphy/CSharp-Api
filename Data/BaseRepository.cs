using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Data
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly WebAPIContext _context;
        public BaseRepository(WebAPIContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
