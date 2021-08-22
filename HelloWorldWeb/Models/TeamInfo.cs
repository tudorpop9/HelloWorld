// <copyright file="TeamInfo.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace HelloWorldWeb.Models
{
    /// <summary>
    /// Custom team info class.
    /// </summary>
    public class TeamInfo
    {
        /// <summary>
        /// Gets or sets team name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets team members.
        /// </summary>
        public List<TeamMember> TeamMembers { get; set; }
    }
}