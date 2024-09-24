using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Models.Entities;
using MiniStore.Models.UnitOfWork.UnitOfWork;
using System.Security.Claims;

namespace MiniStore.Controllers
{
    [Authorize(Roles = clsRole.roleAdmin )]
    public class OrderController : Controller
    {

        private readonly IUnitOfWork _order;
        
        public OrderController(IUnitOfWork order)
        {
            _order = order;
        }

        public async Task<IActionResult> Index()
        {
            return View (await _order.orders.GetOrders());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _order.orders.GetOrderDetails( id));
        }




    }
}

