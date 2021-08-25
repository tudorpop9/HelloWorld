// <copyright file="TeamMemberTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private ITimeService timeService;
        private Mock<ITimeService> timeMock;

        public TeamMemberTests()
        {
        }

        [Fact]
        public void TestEquals()
        {
            // Assume

            // Act
            TeamMember member1 = new TeamMember(0, "Tudor", timeService);
            TeamMember member2 = new TeamMember(0, "Tudor", timeService);

            // Assert
            Assert.True(member1.Equals(member2));
        }

        [Fact]
        public void TestEqualsIdFalse()
        {
            // Assume

            // Act
            TeamMember member1 = new TeamMember(0, "Tudor", timeService);
            TeamMember member2 = new TeamMember(1, "Tudor", timeService);

            // Assert
            Assert.False(member1.Equals(member2));
        }

        [Fact]
        public void TestEqualsNameFalse()
        {
            // Assume

            // Act
            TeamMember member1 = new TeamMember(0, "Tudor", timeService);
            TeamMember member2 = new TeamMember(0, "Cioara", timeService);

            // Assert
            Assert.False(member1.Equals(member2));
        }

        [Fact]
        public void TestIdCounterIncrement()
        {
            // Assume
            int idCounter = TeamMember.GetIdCounter();

            // Act
            TeamMember member1 = new TeamMember("Tudor", timeService);

            // Assert
            Assert.Equal(idCounter + 1, TeamMember.GetIdCounter());
        }

        [Fact]
        public void TestGetAge()
        {
            // Assume
            InitializeTimeServiceMock();
            timeService = timeMock.Object;

            TeamMember teamMember = new TeamMember("Ioan", timeService);
            teamMember.BirthDate = new DateTime(2000, 01, 01);
            int expectedAge = 21;

            // Act
            int computedAge = teamMember.GetAge();

            // Assert
            Assert.Equal(expectedAge, computedAge);
            Mock.Get(timeService).Verify(_ => _.Now(), Times.Once());
        }

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.Now()).Returns(new DateTime(2021, 08, 11));
        }
    }
}
