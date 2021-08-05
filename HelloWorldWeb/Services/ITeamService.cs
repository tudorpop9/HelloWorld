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
        /// <param name="newTeammate">what?.</param>
        void AddTeamMember(string newTeammate);

        TeamInfo GetTeamInfo();
        void DeleteTeamMember(int index);
    }
}