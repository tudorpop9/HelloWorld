// <copyright file="ITeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using WebApplication1.Models;

namespace WebApplication1.Services
{
    /// <summary>
    /// Dummy comment.
    /// </summary>
    public interface ITeamService
    {

        /// <summary>
        /// Dummy comment.
        /// </summary>
        /// <param name="newTeamMember">what?.</param>
        int AddTeamMember(TeamMember newTeamMember);

        int UpdateTeamMember(int memberId, string memberName);

        TeamInfo GetTeamInfo();

        void DeleteTeamMember(int id);

        TeamMember GetTeamMemberById(int id);
    }
}