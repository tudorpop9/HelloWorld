// <copyright file="DbTeamService.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Data;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext dbContext;

        public DbTeamService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        public int AddTeamMember(TeamMember newTeamMember)
        {
            TeamMember anotherTeamMember = new TeamMember() { Name = newTeamMember.Name };
            dbContext.Add(newTeamMember);
            dbContext.SaveChanges();
            return newTeamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = dbContext.TeamMembers.Find(id);
            dbContext.TeamMembers.Remove(teamMember);
            dbContext.SaveChanges();
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo newTeamInfo = new TeamInfo();
            newTeamInfo.Name = "PlaceholderName";
            newTeamInfo.TeamMembers = dbContext.TeamMembers.ToList();

            return newTeamInfo;
        }

        public int UpdateTeamMember(int memberId, string memberName)
        {
            int returnId = -1;
            TeamMember existingMember = this.GetTeamMemberById(memberId);

            if (existingMember != null)
            {
                existingMember.Name = memberName;
                returnId = memberId;
            }

            dbContext.SaveChanges();
            return returnId;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            List<TeamMember> members = dbContext.TeamMembers.ToList();
            foreach (TeamMember member in members)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }

            return null;
        }
    }
}
