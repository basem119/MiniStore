using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MiniStore.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void update(TEntity entity);
        void Remove(TEntity entity);



    }

}
