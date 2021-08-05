using HelloWorldWeb.Models;
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
        [Fact]
        public void TestEqualsTrue()
        {
            // Assume

            // Act
            TeamMember member1 = new TeamMember(0, "Tudor");
            TeamMember member2 = new TeamMember(0, "Tudor");

            // Assert
            Assert.True(member1.Equals(member2));
        }

        [Fact]
        public void TestEqualsIdFalse()
        {
            // Assume

            // Act
            TeamMember member1 = new TeamMember(0, "Tudor");
            TeamMember member2 = new TeamMember(1, "Tudor");

            // Assert
            Assert.False(member1.Equals(member2));
        }

        [Fact]
        public void TestEqualsNameFalse()
        {
            // Assume

            // Act
            TeamMember member1 = new TeamMember(0, "Tudor");
            TeamMember member2 = new TeamMember(0, "Cioara");

            // Assert
            Assert.False(member1.Equals(member2));
        }

        [Fact]
        public void TestIdCounterIncrement()
        {
            // Assume
            int idCounter = TeamMember.GetIdCounter();

            // Act
            TeamMember member1 = new TeamMember("Tudor");

            // Assert
            Assert.Equal(idCounter + 1, TeamMember.GetIdCounter());
        }
    }
}
