using System;
using System.Collections;
using Bookstore.Domain.Interfaces;
using Bookstore.Persistence.DataAccess.Repositories;
using Raven.Client;

namespace Bookstore.Persistence.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IDocumentSession _session;
        private Hashtable _repositories;

        public UnitOfWork(IDocumentSession session)
        {
            _session = session;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            // Retorna repositório previamente inicializado
            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)_repositories[type];
            }

            // Instancia novo repositório passando o contexto único comum a todos
            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _session));

            return (IRepository<TEntity>)_repositories[type];
        }

        public void SaveChanges()
        {
            _session.SaveChanges();
        }
    }
}
