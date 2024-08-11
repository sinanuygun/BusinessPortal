using System;
using System.Collections.Generic;

namespace BusinessPortal.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
