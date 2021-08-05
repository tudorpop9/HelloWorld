// <copyright file="ITeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
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
        int AddTeamMember(TeamMember newTeamMember);

        TeamInfo GetTeamInfo();
        void DeleteTeamMember(int index);
    }
}