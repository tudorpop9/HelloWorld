﻿using System;
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
        private readonly UserManager<IdentityUser> userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await userManager.Users.ToListAsync());
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
            return View("Index", await userManager.Users.ToListAsync());
        }

        public async Task<IActionResult> AssignRegularUserRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Administrators");
            return View("Index", await userManager.Users.ToListAsync());
        }

        /* // POST: Users/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("Id,Name,Role")] User user)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(user);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(user);
         }

         // GET: Users/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var user = await _context.User.FindAsync(id);
             if (user == null)
             {
                 return NotFound();
             }
             return View(user);
         }

         // POST: Users/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Role")] User user)
         {
             if (id != user.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(user);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!UserExists(user.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(user);
         }

         // GET: Users/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var user = await _context.User
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (user == null)
             {
                 return NotFound();
             }

             return View(user);
         }

         // POST: Users/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var user = await _context.User.FindAsync(id);
             _context.User.Remove(user);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool UserExists(int id)
         {
             return _context.User.Any(e => e.Id == id);
         }*/
    }
}
