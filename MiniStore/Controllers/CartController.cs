using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MiniStore.Data;
using MiniStore.Models.UnitOfWork.UnitOfWork;
using MiniStore.Repositories;

namespace MiniStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _cartRepo;
        //private readonly IOrderRepository _cartRepo;
        private string UserIdTest = "4c544feb-8a58-4853-a83c-8d0cf2df2fe5";

        public CartController(IUnitOfWork cartRepo)
        {
            _cartRepo = cartRepo;
        }

        // GET: Customers

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            return View(await _cartRepo.orders.GetUserCart(userId));
        }
        
        
        public async Task<IActionResult> AddItemToCart(int ProductId)
        {
            var output = await _cartRepo.orders.AddToCart(ProductId, 1);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteItemInCart(int ProductId)
        {
            var output =await _cartRepo.orders.DeleteItemInCart(ProductId);
            if(output >= 1)
            return RedirectToAction("Index");
            else 
                return Problem("Can't remove item");
        }

        public async Task<IActionResult> CheckOut(float Total)
        {
            var output =await  _cartRepo.orders.CheckOut(Total);
            return RedirectToAction("Index", "Home");
        }

    }
}
