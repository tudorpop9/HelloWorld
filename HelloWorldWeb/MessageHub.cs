// <copyright file="MessageHub.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}