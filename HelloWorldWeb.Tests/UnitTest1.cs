using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        /// <summary>
        /// Assume // Act // Assert
        /// </summary>
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.AddTeamMember("George");

            // Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);
        }
    }
}
