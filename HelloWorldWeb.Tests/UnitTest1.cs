using HelloWorldWeb.Models;
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
            teamService.AddTeamMember(new Models.TeamMember("George"));

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void GetItemByIdNotNull()
        {
            // Assume
            ITeamService teamService = new TeamService();
            int existingId= teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            TeamMember member = teamService.GetTeamMemberById(existingId);

            // Assert
            Assert.NotNull(member);
        }

        [Fact]
        public void GetItemByIdNull()
        {
            // Assume
            ITeamService teamService = new TeamService();
            int givenId = 1010101;

            // Act
            TeamMember member = teamService.GetTeamMemberById(givenId);

            // Assert
            Assert.Null(member);
        }

        [Fact]
        public void GetItemByIdFound()
        {
            // Assume
            ITeamService teamService = new TeamService();
            int givenId = 100;

            // Act
            teamService.AddTeamMember(new TeamMember(givenId, "Cat"));
            TeamMember member = teamService.GetTeamMemberById(givenId);

            // Assert
            Assert.True(member.Equals(new TeamMember(givenId, "Cat")));
        }

        [Fact]
        public void DeleteDefaultMemberByIdTest()
        {
            // Assume
            ITeamService teamService = new TeamService();
            int idCounter = TeamMember.GetIdCounter();

            // Act
            teamService.DeleteTeamMember(idCounter);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(idCounter));
        }

        [Fact]
        public void DeleteNewMemberByStaticIdTest()
        {
            // Assume
            ITeamService teamService = new TeamService();


            // Act
            TeamMember newTeamMember = new TeamMember("Cthulhu");
            teamService.AddTeamMember(newTeamMember);
            teamService.DeleteTeamMember(newTeamMember.Id);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(newTeamMember.Id));
        }


        [Fact]
        public void DeleteNewMemberByGivenIdTest()
        {
            // Assume
            ITeamService teamService = new TeamService();
            int givenId = 2000;

            // Act
            TeamMember newTeamMember = new TeamMember(givenId, "Cthulhu");
            teamService.AddTeamMember(newTeamMember);
            teamService.DeleteTeamMember(givenId);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(givenId));
        }
    }
}
