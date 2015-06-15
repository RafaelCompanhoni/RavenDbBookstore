using System.Collections.Generic;

namespace Bookstore.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(string id);
        void Create(TEntity obj);
        void Delete(TEntity obj);
    }
}
