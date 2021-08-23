// <copyright file="TeamServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System.Threading;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        private ITimeService timeService = null;
        private Mock<IHubContext<MessageHub>> messageHubMock = null;

        /// <summary>
        /// Assume // Act // Assert.
        /// </summary>
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());

            // Act
            teamService.AddTeamMember(new Models.TeamMember("George", timeService));

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void GetItemByIdNotNull()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            int existingId = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            TeamMember member = teamService.GetTeamMemberById(existingId);

            // Assert
            Assert.NotNull(member);
        }

        [Fact]
        public void GetItemByIdNull()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            int givenId = 100;

            // Act
            teamService.AddTeamMember(new TeamMember(givenId, "Cat", timeService));
            TeamMember member = teamService.GetTeamMemberById(givenId);

            // Assert
            Assert.True(member.Equals(new TeamMember(givenId, "Cat", timeService)));
        }

        [Fact]
        public void DeleteDefaultMemberByIdTest()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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
            ITeamService teamService = new TeamService(GetMockedMessageHub());

            // Act
            TeamMember newTeamMember = new TeamMember("Cthulhu", timeService);
            teamService.AddTeamMember(newTeamMember);
            teamService.DeleteTeamMember(newTeamMember.Id);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(newTeamMember.Id));
        }

        [Fact]
        public void DeleteNewMemberByGivenIdTest()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            int givenId = 2000;

            // Act
            TeamMember newTeamMember = new TeamMember(givenId, "Cthulhu", timeService);
            teamService.AddTeamMember(newTeamMember);
            teamService.DeleteTeamMember(givenId);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(givenId));
        }

        [Fact]
        public void UpdateExistingMemberTest()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            int givenId = 2000;
            string newName = "Andrei";
            TeamMember newTeamMember = new TeamMember(givenId, "Cthulhu", timeService);
            teamService.AddTeamMember(newTeamMember);

            // Act
            int returnedId = teamService.UpdateTeamMember(givenId, newName);
            TeamMember memberReference = teamService.GetTeamMemberById(givenId);

            // Assert
            Assert.Equal(returnedId, givenId);
            Assert.Equal(newName, memberReference.Name);
        }

        [Fact]
        public void UpdateUnexistingMemberTest()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            int givenId = 2500;
            int expectedId = -1;
            string newName = "Andrei";

            // Act
            int returnedId = teamService.UpdateTeamMember(givenId, newName);
            TeamMember memberReference = teamService.GetTeamMemberById(givenId);

            // Assert
            Assert.Null(memberReference);
            Assert.Equal(expectedId, returnedId);
        }

        // test function from Sorina
        [Fact]
        public void CheckIdProblemTest()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMemberName = "Borys";

            // Act
            teamService.DeleteTeamMember(memberToBeDeleted.Id);
            var id = teamService.AddTeamMember(new TeamMember(newMemberName, timeService));
            teamService.DeleteTeamMember(id);

            // Assert
            var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == newMemberName);
            Assert.Null(member);
        }

        [Fact]
        public void CheckLine60()
        {
            // Assume
            InitializeMessageHubMock();
            var messageHub = messageHubMock.Object;

            // Act
            messageHub.Clients.All.SendAsync("NewTeamMemberAdded", "Tudor", 2);

            // Assert
            //It.IsAny<string>()
            hubAllClientsMock.Verify(hubAllClients => hubAllClients.SendAsync("NewTeamMemberAdded", "Tudor", 2, It.IsAny<CancellationToken>()), Times.Once(), "I expect SendAsync to be called once.");
            //Mock.Get(hubAllClientsMock).Verify(_ => _.SendAsync("NewTeamMemberAdded", "Tudor", 2), Times.Once());

        }

        private Mock<IHubClients> hubClientsMock;
        private Mock<IClientProxy> hubAllClientsMock;

        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            hubAllClientsMock = new Mock<IClientProxy>();
            hubClientsMock = new Mock<IHubClients>();
            hubClientsMock.Setup(_ => _.All).Returns(hubAllClientsMock.Object);
            messageHubMock = new Mock<IHubContext<MessageHub>>();

            messageHubMock.SetupGet(_ => _.Clients).Returns(hubClientsMock.Object);
        }

        private IHubContext<MessageHub> GetMockedMessageHub()
        {
            if (messageHubMock == null)
            {
                InitializeMessageHubMock();
            }

            return messageHubMock.Object;
        }
    }
}
