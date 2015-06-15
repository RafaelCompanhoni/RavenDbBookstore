using System.Collections.Generic;

namespace Bookstore.Domain.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(string id);
        void Create(TEntity entity);
        void Update();
        void Delete(TEntity entity);
    }
}
