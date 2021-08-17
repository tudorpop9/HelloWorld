using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public DbTeamService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public int AddTeamMember(TeamMember newTeamMember)
        {
            TeamMember anotherTeamMember = new TeamMember() { Name = newTeamMember.Name };
            _context.Add(newTeamMember);
            _context.SaveChanges();
            return newTeamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = _context.TeamMembers.Find(id);
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo newTeamInfo = new TeamInfo();
            newTeamInfo.Name = "PlaceholderName";
            newTeamInfo.TeamMembers = _context.TeamMembers.ToList();

            return newTeamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateTeamMember(int memberId, string memberName)
        {
            throw new NotImplementedException();
        }
    }
}
