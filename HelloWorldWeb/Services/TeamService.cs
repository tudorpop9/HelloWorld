// <copyright file="TeamService.cs" company="Principal33">
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
            
            teamInfo.TeamMembers.Add(new TeamMember(1, "Sorina"));
            teamInfo.TeamMembers.Add(new TeamMember(2, "Ema"));
            teamInfo.TeamMembers.Add(new TeamMember(3, "Radu"));
            teamInfo.TeamMembers.Add(new TeamMember(4, "Patrick"));
            teamInfo.TeamMembers.Add(new TeamMember(5, "Tudor"));
            teamInfo.TeamMembers.Add(new TeamMember(6, "Fineas"));
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

        public void DeleteTeamMember(int index)
        {
            this.teamInfo.TeamMembers.RemoveAt(index);
        }
    }
}
