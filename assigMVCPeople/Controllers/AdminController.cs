﻿using assigMVCPeople.Models;
using assigMVCPeople.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager=roleManager;
            _userManager=userManager;

        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            IdentityRole role = new IdentityRole(name);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var identityError in result.Errors)
            {
                ModelState.AddModelError(identityError.Code, identityError.Description);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string id, string msg = null)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null)
            {
                return RedirectToAction("Index");
            }
            ManageRolesViewModel manageRoles = new Models.ViewModels.ManageRolesViewModel();
            manageRoles.Role = role;
            manageRoles.UsersWithRole = await _userManager.GetUsersInRoleAsync(role.Name);
            manageRoles.UsersNoRole = _userManager.Users.ToList();

            foreach (var item in manageRoles.UsersWithRole)
            {
                manageRoles.UsersNoRole.Remove(item);
            }
            ViewBag.Msg = msg;
            return View(manageRoles);
        }

        [HttpGet]
        public async Task<IActionResult> AddToRole(string userId, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if(role == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(ManageUserRoles), new { msg = " Add role to user" });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromRole(string userId, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ManageUserRoles), new { msg = " User have been"});
            }
            return RedirectToAction(nameof(ManageUserRoles), new { msg = " Remove the role"});
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
