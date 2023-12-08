using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MiniStore.Data;
using MiniStore.Models.Entities;

namespace MiniStore.Repositories
{
    public class ProductRepository : GeneralRepository<Product>, IProductRepository
    {

        public ProductRepository(DbContext context, IHttpContextAccessor httpContextAccessor, UserManager<Customer> userManager) : base(context,userManager)
        {

        }

        public IEnumerable<Product> TopExpensiveProducts(int count)
        {
            return AppDbContext.Products.OrderByDescending(p => p.Price2).Take(count);
        }

        public IEnumerable<Product> TopQuantityProducts(int count)
        {
            return AppDbContext.Products.OrderByDescending(p => p.Quantity).Take(count);
        }
        public AppDbContext AppDbContext
        {
            get { return _context as AppDbContext; }
        }
    }
}
