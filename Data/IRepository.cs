using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
    }
}
