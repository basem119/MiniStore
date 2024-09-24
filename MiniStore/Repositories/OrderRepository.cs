using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using MiniStore.Data;
using MiniStore.Models.Entities;
using Microsoft.CodeAnalysis;

namespace MiniStore.Repositories
{
    public class OrderRepository : GeneralRepository<Order>, IOrderRepository
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderRepository(DbContext context, IHttpContextAccessor httpContextAccessor, UserManager<Customer> userManager) : base(context, userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Order> GetUserCart(string userId)
        {

            return await AppDbContext.Orders.Where(x => x.CustomerId == userId && x.OrderStatus == 0)
                                            .Include(x => x.OrderDetails)
                                            .ThenInclude(x => x.Product)
                                            .FirstOrDefaultAsync();
        }
        public async Task<Order> GetCart(string userId)
        {

            var users = await _userManager.FindByIdAsync(userId);

            return AppDbContext.Orders.Where(x => x.CustomerId == userId && x.OrderStatus == 0).FirstOrDefault();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = AppDbContext.Orders.Include(x => x.Customer).Include(x => x.OrderDetails).ThenInclude(x => x.Product);
            return orders;
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails(int OrderId)
        {
            var OrderDetail = AppDbContext.OrderDetails.Where(x => x.OrderId == OrderId);

            return OrderDetail;

        }
        public async Task<int> AddToCart(int productId, int quantity)
        {

            using var transaction = AppDbContext.Database.BeginTransaction();
            try
            {
                var userId = GetUserId();
                if (userId == null)
                    throw new Exception("Invalid userid");
                var cart = await GetCart(userId);
           
                if (cart is null)
                {
                    cart = new Order
                    {
                        CustomerId = userId,
                        OrderStatus = 0,
                        OrderDate = DateTime.Now,
                        
                    };

                    AppDbContext.Orders.Add(cart);
                }
                AppDbContext.SaveChanges();
                var checkproduct = AppDbContext.OrderDetails.FirstOrDefault(x => x.Product.Id == productId && x.OrderId == cart.Id);
                if (checkproduct != null)
                {
                    checkproduct.Quantity += quantity;
                }
                else
                {
                    var product = AppDbContext.Products.FirstOrDefault(x => x.Id == productId);
                    var detail = new OrderDetail
                    {
                        Product = product,
                        Quantity = quantity,
                        UnitPrice = product.Price2,
                        ProductId = product.Id,
                        OrderId = cart.Id
                    };
                    AppDbContext.OrderDetails.Add(detail);
                }
                AppDbContext.SaveChanges();
                transaction.Commit();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
            //revision on it --------------------------
            //var count = cart.OrderDetails.Count();
           
            return 1;
        }
        public  async Task<int> DeleteItemInCart(int productId)
        {
            using var transaction = AppDbContext.Database.BeginTransaction();
            try
            {
                var userId = GetUserId();
                if (userId == null)
                    throw new Exception("Invalid userid");
                var cart = await GetCart(userId);
                var item = AppDbContext.OrderDetails.FirstOrDefault(x => x.ProductId == productId && x.OrderId == cart.Id);
                if (cart == null) {  throw new Exception("Not items in cart"); }
                if (item == null){  throw new Exception("No product found"); }
                if(item.Quantity ==1)
                { AppDbContext.OrderDetails.Remove(item); }
                else if(item.Quantity >1) { 
                    item.Quantity  -= 1;
                }
                else { return 0; }
                
                AppDbContext.SaveChanges();
                transaction.Commit();
            }
            catch(Exception ex) { throw new Exception("error in delete item"); }
            return 1;

        }
        public async Task<int> CheckOut(float Total)
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("Invalid userid");
            var cart = await GetCart(userId);

            var user = AppDbContext.Customers.FirstOrDefault(x => x.Id == userId);
            if (cart == null) { throw new Exception("Not items in cart"); }
            if (user == null) { throw new Exception("Not user found"); }
            cart.OrderStatus = 1;
            cart.Total = Total;
            AppDbContext.Orders.Update(cart);
            AppDbContext.SaveChanges();
            return 1;
        }
        public AppDbContext AppDbContext
        {
            get { return _context as AppDbContext; }
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }

    }
}
