using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private readonly ITimeService timeService;

        public TeamMemberTests()
        {
            var mock = new Mock<ITimeService>();
           
            mock.Setup(_ => _.Now()).Returns(new DateTime(2021, 08, 11));

            timeService = mock.Object;
        }

        [Fact]
        public void TestEqualsTrue()
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
            TeamMember teamMember = new TeamMember("Ioan", timeService);
            teamMember.BirthDate = new DateTime(2000, 01, 01);
            int expectedAge = 21;

            // Act
            int computedAge = teamMember.getAge();

            // Assert
            Assert.Equal(expectedAge, computedAge);
        }
    }
}
