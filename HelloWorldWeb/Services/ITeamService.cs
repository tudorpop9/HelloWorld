// <copyright file="ITeamService.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
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
        /// <returns>Returns new member id.</returns>
        int AddTeamMember(TeamMember newTeamMember);

        int UpdateTeamMember(int memberId, string memberName);

        TeamInfo GetTeamInfo();

        void DeleteTeamMember(int id);

        TeamMember GetTeamMemberById(int id);
    }
}