using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace HelloWorldWeb.Controllers
{
    public class UsersController : Controller
    {
        public static readonly string ADMIN_ROLE = "Administrators";
        public static readonly string REGULAR_USER_ROLE = "Users";

        private readonly UserManager<IdentityUser> userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await GetUsersWithRole());
        }

        // GET: Users/Details/[ugly string id]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> AssignAdminRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Administrators");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AssignRegularUserRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Administrators");
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<UserWithRole>> GetUsersWithRole()
        {
            List<UserWithRole> users = new List<UserWithRole>();
            var allUsers = await userManager.Users.ToListAsync();
            var admins = await userManager.GetUsersInRoleAsync(ADMIN_ROLE);

            var regularUsers = allUsers.Except(admins).ToList();

            foreach (var admin in admins)
            {
                users.Add(new UserWithRole(admin.Id, admin.Email, ADMIN_ROLE));
            }

            foreach (var user in regularUsers)
            {
                users.Add(new UserWithRole(user.Id, user.Email, REGULAR_USER_ROLE));
            }

            return users;
        }

        
    }
}
