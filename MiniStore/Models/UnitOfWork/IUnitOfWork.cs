using MiniStore.Models.Entities;
using MiniStore.Repositories;

namespace MiniStore.Models.UnitOfWork.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository products { get; }
        IOrderRepository orders { get; }
        IRepository<Category> categories { get; }
        IRepository<Customer> customers { get; }
        IRepository<Employee> employees { get; }
        IRepository<OrderDetail> orderDetails { get; }
        int Complete();
    }
}
