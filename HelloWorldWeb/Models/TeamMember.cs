// <copyright file="Member.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TeamMember(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}
