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
        private Mock<IBroadcastService> broadcastServiceMock = null;

        /// <summary>
        /// Assume // Act // Assert.
        /// </summary>
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            var bcService = GetBroadCastService();
            ITeamService teamService = new TeamService(bcService);
            TeamMember newTeamMember = new Models.TeamMember("George", timeService);

            // Act
            teamService.AddTeamMember(newTeamMember);

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
            Mock.Get(bcService).Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void GetItemByIdNotNull()
        {
            // Assume
            ITeamService teamService = new TeamService(GetBroadCastService());
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
            ITeamService teamService = new TeamService(GetBroadCastService());
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
            var bcService = GetBroadCastService();
            ITeamService teamService = new TeamService(bcService);
            int givenId = 100;

            // Act
            teamService.AddTeamMember(new TeamMember(givenId, "Cat", timeService));
            TeamMember member = teamService.GetTeamMemberById(givenId);

            // Assert
            Assert.True(member.Equals(new TeamMember(givenId, "Cat", timeService)));
            Mock.Get(bcService).Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void DeleteDefaultMemberByIdTest()
        {
            // Assume
            ITeamService teamService = new TeamService(GetBroadCastService());
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
            var bcService = GetBroadCastService();
            ITeamService teamService = new TeamService(bcService);

            // Act
            TeamMember newTeamMember = new TeamMember("Cthulhu", timeService);
            teamService.AddTeamMember(newTeamMember);
            teamService.DeleteTeamMember(newTeamMember.Id);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(newTeamMember.Id));
            Mock.Get(bcService).Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void DeleteNewMemberByGivenIdTest()
        {
            // Assume
            var bcService = GetBroadCastService();
            ITeamService teamService = new TeamService(bcService);
            int givenId = 2000;

            // Act
            TeamMember newTeamMember = new TeamMember(givenId, "Cthulhu", timeService);
            teamService.AddTeamMember(newTeamMember);
            teamService.DeleteTeamMember(givenId);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(givenId));
            Mock.Get(bcService).Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once());

        }

        [Fact]
        public void UpdateExistingMemberTest()
        {
            // Assume
            var bcService = GetBroadCastService();
            ITeamService teamService = new TeamService(bcService);
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
            Mock.Get(bcService).Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once());

        }

        [Fact]
        public void UpdateUnexistingMemberTest()
        {
            // Assume
            ITeamService teamService = new TeamService(GetBroadCastService());
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
            var bcService = GetBroadCastService();
            ITeamService teamService = new TeamService(bcService);
            var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMemberName = "Borys";

            // Act
            teamService.DeleteTeamMember(memberToBeDeleted.Id);
            var id = teamService.AddTeamMember(new TeamMember(newMemberName, timeService));
            teamService.DeleteTeamMember(id);

            // Assert
            var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == newMemberName);
            Assert.Null(member);
            Mock.Get(bcService).Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once());

        }

        /* [Fact]
         public void CheckLine60()
         {
             // Assume
             InitializeMessageHubMock();
             hubAllClientsMock.Setup(_ => _.SendAsync("NewTeamMemberAdded", "Tudor", 2, It.IsAny<CancellationToken>()));
             var messageHub = messageHubMock.Object;

             // Act
             messageHub.Clients.All.SendAsync("NewTeamMemberAdded", "Tudor", 2);

             // Assert
             //It.IsAny<string>()
             hubAllClientsMock.Verify(hubAllClients => hubAllClients.SendAsync("NewTeamMemberAdded", "Tudor", 2, It.IsAny<CancellationToken>()), Times.Once(), "I expect SendAsync to be called once.");
             //Mock.Get(hubAllClientsMock).Verify(_ => _.SendAsync("NewTeamMemberAdded", "Tudor", 2), Times.Once());

         }*/

        /*private Mock<IHubClients> hubClientsMock;
        private Mock<IClientProxy> hubAllClientsMock;*/

        private void InitializeBroadcastServiceMock()
        {
            /*// https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            hubAllClientsMock = new Mock<IClientProxy>();
            hubClientsMock = new Mock<IHubClients>();
            hubClientsMock.Setup(_ => _.All).Returns(hubAllClientsMock.Object);
            messageHubMock = new Mock<IHubContext<MessageHub>>();

            messageHubMock.SetupGet(_ => _.Clients).Returns(hubClientsMock.Object);*/
            this.broadcastServiceMock = new Mock<IBroadcastService>();
        }

        private IBroadcastService GetBroadCastService()
        {
            if (broadcastServiceMock == null)
            {
                InitializeBroadcastServiceMock();
            }

            return broadcastServiceMock.Object;
        }
    }
}
