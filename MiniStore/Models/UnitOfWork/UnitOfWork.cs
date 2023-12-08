using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using MiniStore.Data;
using MiniStore.Models.Entities;
using MiniStore.Models.UnitOfWork.UnitOfWork;
using MiniStore.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly UserManager<Customer> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor ,UserManager<Customer> userManager)
    {
        _context = context;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        products = new ProductRepository(_context, _httpContextAccessor, _userManager);
        orders = new OrderRepository(_context,_httpContextAccessor, _userManager);
        //categories = new GeneralRepository<Category>(_context, _userManager);
        //customers = new GeneralRepository<Customer>(_context, _userManager);
        //employees = new GeneralRepository<Employee>(_context, _userManager);
        //orderDetails = new GeneralRepository<OrderDetail>(_context, _userManager);
    }

    public IProductRepository products { get; private set; }
    public IOrderRepository orders { get; private set; }
    public IRepository<Category> categories { get; private set; }
    public IRepository<Customer> customers { get; private set; }
    public IRepository<Employee> employees { get; private set; }
    public IRepository<OrderDetail> orderDetails { get; private set; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
