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
                TeamMembers = new List<string>(new string[] { "Fineas", "Patrick", "Radu", "Tudor", "Ema" }),
            };
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
        /// <param name="newTeammate"> newTeammate name</param>
        public void AddTeamMember(string newTeammate)
        {
            teamInfo.TeamMembers.Add(newTeammate);
        }
    }
}
