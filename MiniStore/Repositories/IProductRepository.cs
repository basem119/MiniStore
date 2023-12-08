using MiniStore.Models.Entities;

namespace MiniStore.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {

        IEnumerable<Product> TopExpensiveProducts(int count);
        IEnumerable<Product> TopQuantityProducts(int count);

    }
}
