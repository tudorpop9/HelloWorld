// <copyright file="ApplicationDbContext.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Skill> Skill { get; set; }

        public DbSet<HelloWorldWeb.Models.TeamMember> TeamMembers { get; set; }

    }
}
