using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MiniStore.Data;
using MiniStore.Models.Entities;

namespace MiniStore.Repositories
{
    public class GeneralRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly UserManager<Customer> _userManager;

        public GeneralRepository(DbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        //public async IEnumerable<TEntity> Details(int? id)
        //{
        //    return await _context.Set<TEntity>().FindAsync(id);
        //}

        public void Find(Expression<Func<TEntity, bool>> predicate)
        {
            _context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
       
        public TEntity Get(int id)
        {

            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);
        }

        public void update(TEntity entity)
        {

            _context.Set<TEntity>().Update(entity);
        }
    }
}
