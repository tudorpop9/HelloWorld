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
        private static int idCounter = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public TeamMember(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public TeamMember(string name)
        {
            this.Id = idCounter;
            this.Name = name;

            idCounter++;
        }

        public static int GetIdCounter()
        {
            return idCounter;
        }

        public override bool Equals(object obj)
        {
            TeamMember comparableMember = (TeamMember)obj;
            return this.Id.Equals(comparableMember.Id) &&
                   this.Name.Equals(comparableMember.Name);
        }

    }
}
