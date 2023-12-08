// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using MiniStore.Models;
using MiniStore.Models.Entities;

namespace MiniStore.Controllers
{
    [Authorize(Roles = clsRole.roleAdmin)]
    public class RoleController : Controller
    {
        
        private readonly RoleManager<IdentityRole> _roles;
        private readonly UserManager<Customer> _user;
        public RoleController(RoleManager<IdentityRole> roles, UserManager<Customer> user)
        {
            _user = user;
            _roles = roles;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _user.Users. ToListAsync    ();
            return View(users);
        }
        public async Task<IActionResult> addRoles(string userId)
        {
            var users = await _user.FindByIdAsync(userId);
            var userRoles = await _user.GetRolesAsync(users);

            var allRoles = _roles.Roles.ToList();
            if(allRoles != null)
            {
                var roleList = allRoles.Select(r => new roleViewModel
                {
                    roleId = r.Id,
                    roleName = r.Name,
                    userRole = userRoles.Any(x => x == r.Name)
                });
                ViewBag.userName = users.UserName;
                ViewBag.userId = userId;
                return View(roleList);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addRoles(string userId,string jsonRoles)
        {
            var user = await _user.FindByIdAsync(userId);
             List < roleViewModel > myRoles =
                JsonConvert.DeserializeObject<List<roleViewModel>>(jsonRoles);
            if(user != null)
            {
                var userRole = await _user.GetRolesAsync(user);
                foreach(var role in myRoles)
                {
                    if(userRole.Any(x=>x == role.roleName.Trim())&& !role.userRole)
                    {
                        await _user.RemoveFromRoleAsync(user, role.roleName.Trim());
                    }
                    if (!userRole.Any(x => x == role.roleName.Trim()) && role.userRole)
                    {
                        await _user.AddToRoleAsync(user, role.roleName.Trim());
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
