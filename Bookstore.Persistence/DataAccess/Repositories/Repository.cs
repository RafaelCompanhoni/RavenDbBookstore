using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Domain.Interfaces;
using Bookstore.Persistence.Interfaces;
using Raven.Client;

namespace Bookstore.Persistence.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDocumentSession _session;

        public Repository(IDocumentSession store)
        {
            _session = store;
        }

        public List<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public void Create(TEntity obj)
        {
            _session.Store(obj);
        }

        public void Delete(TEntity obj)
        {
            _session.Delete(obj);
        }
    }
}
