// <copyright file="TeamMember.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Services;

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        private static int idCounter = 0;
        private readonly ITimeService timeService;

        public TeamMember(int id, string name, ITimeService timeService)
        {
            this.timeService = timeService;
            this.Id = id;
            this.Name = name;
        }

        public TeamMember(string name, ITimeService timeService)
        {
            this.timeService = timeService;
            this.Id = idCounter;
            this.Name = name;

            idCounter++;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public static int GetIdCounter()
        {
            return idCounter;
        }

        public int GetAge()
        {
            TimeSpan age;
            DateTime birthDate;
            birthDate = this.BirthDate;

            DateTime zeroTime = new DateTime(1, 1, 1);
            age = timeService.Now() - birthDate;
            int years = (zeroTime + age).Year - 1;

            return years;
        }

        public override bool Equals(object obj)
        {
            TeamMember comparableMember = (TeamMember)obj;
            return this.Id.Equals(comparableMember.Id) &&
                   this.Name.Equals(comparableMember.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
