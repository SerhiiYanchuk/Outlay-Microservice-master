using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CardMicroservice.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Finding object
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        // Adding object
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Removing object
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
