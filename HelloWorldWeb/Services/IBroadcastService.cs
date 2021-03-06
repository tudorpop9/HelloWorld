// <copyright file="IBroadcastService.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int id);

        void TeamMemberDeleted(int id);

        void UpdatedTeamMember(int memberId, string memberName);
    }
}