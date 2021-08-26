// <copyright file="UserWithRole.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class UserWithRole
    {
        public UserWithRole(string id, string email, string role)
        {
            Id = id;
            Email = email;
            Role = role;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
