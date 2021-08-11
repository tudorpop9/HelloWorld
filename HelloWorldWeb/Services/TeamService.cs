﻿// <copyright file="TeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    /// <summary>
    /// Team service class.
    /// </summary>
    public class TeamService : ITeamService
    {
        private TeamInfo teamInfo;
        private ITimeService timeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamService"/> class.
        /// </summary>
        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team1",
                TeamMembers = new List<TeamMember>(),
            };

            teamInfo.TeamMembers.Add(new TeamMember("Sorina", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Ema", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Radu", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Patrick", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Tudor", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Fineas", timeService));
        }

        /// <summary>
        /// Dummy comment.
        /// </summary>
        /// <returns>Retruns TeamInfo object.</returns>
        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        /// <summary>
        /// Adds a new team member
        /// </summary>
        /// <param name="newTeamMember"> newTeammate name</param>
        public int AddTeamMember(TeamMember newTeamMember)
        {
            teamInfo.TeamMembers.Add(newTeamMember);
            return newTeamMember.Id;
        }

        /// <inheritdoc/>
        public void DeleteTeamMember(int id)
        {
            TeamMember teamMember = this.GetTeamMemberById(id);
            if (teamMember != null)
            {
                this.teamInfo.TeamMembers.Remove(teamMember);
            }

        }

        /// <inheritdoc/>
        public TeamMember GetTeamMemberById(int id)
        {
            foreach (TeamMember member in this.teamInfo.TeamMembers)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }

            return null;
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

            return returnId;
        }
    }
}
