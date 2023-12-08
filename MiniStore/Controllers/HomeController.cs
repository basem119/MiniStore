using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MiniStore.Data;
using  MiniStore.Models;

namespace  MiniStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
       // UnitOfWork unitofwork = new UnitOfWork(new AppDbContext());

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.ProductCategories.Include(x=>x.Product).Include(x=>x.Category) != null ?
                        View(await _context.ProductCategories.Include(x => x.Product).Include(x => x.Category).ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Products'  is null.");
        }
        public async Task<IActionResult> Cart()
        {
            return _context.Products != null ?
                        View(await _context.Products.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Products'  is null.");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email , string password)
        {
            var user =_context.People.FirstOrDefault(x => x.email == email);
            if (user == null)
                return RedirectToAction(nameof(Login));
            if (user.password != password)
                RedirectToAction(nameof(Login));
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}