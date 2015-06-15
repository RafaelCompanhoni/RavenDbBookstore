using System.Collections.Generic;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.Repository<TEntity>();
        }

        // TODO -- temporário; a leitura deve ser feita através do contexto de leitura
        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(TEntity entity)
        {
            _repository.Create(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            UnitOfWork.SaveChanges();
        }
    }
}
