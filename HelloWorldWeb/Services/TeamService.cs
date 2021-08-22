// <copyright file="TeamService.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System.Collections.Generic;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    /// <summary>
    /// Team service class.
    /// </summary>
    public class TeamService : ITeamService
    {
        private readonly IHubContext<MessageHub> messageHub;

        private TeamInfo teamInfo;
        private ITimeService timeService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamService"/> class.
        /// </summary>
        /// <param name="messageHubContext"> Notifies cliets of data chages.</param>
        public TeamService(IHubContext<MessageHub> messageHubContext)
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

            this.messageHub = messageHubContext;
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
        /// Adds a new team member.
        /// </summary>
        /// <param name="newTeamMember"> newTeammate name.</param>
        /// <returns> Returns new member id.</returns>.
        public int AddTeamMember(TeamMember newTeamMember)
        {
            teamInfo.TeamMembers.Add(newTeamMember);
            messageHub.Clients.All.SendAsync("NewTeamMemberAdded", newTeamMember.Name, newTeamMember.Id);

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
