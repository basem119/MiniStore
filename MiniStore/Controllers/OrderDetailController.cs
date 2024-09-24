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
    public class OrderDetailController : Controller
    {

        private readonly IUnitOfWork _orderDetail;
        
        public OrderDetailController(IUnitOfWork orderDetail)
        {
            _orderDetail = orderDetail;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View( _orderDetail.orderDetails.Find(x=>x.Id == id));
        }





    }
}

