using MiniStore.Models.Entities;

namespace MiniStore.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {

        Task<Order> GetUserCart(String userId);
        Task<int> AddToCart(int productId, int quantity);
        Task<int> DeleteItemInCart(int productId);
        Task<int> CheckOut();
        IEnumerable<Order> GetOrders(string userId);

    }
}
