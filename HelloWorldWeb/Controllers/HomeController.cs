// <copyright file="HomeController.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;

        

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// Home controller constructor.
        /// </summary>
        /// <param name="logger"> Necesary parameter for superclass.</param>
        /// <param name="teamService"> Team service param.</param>
        /// <param name="timeService">Time service param.</param>
        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService, IBroadcastService broadcastService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
            this.broadcastService = broadcastService;
        }

        /// <summary>
        /// Post endpoint which adds a new team member.
        /// </summary>
        /// <param name="newTeammate">Name of the new team member.</param>
        /// <returns>TeamMember id.</returns>
        [HttpPost]
        public int AddTeamMember(string newTeammate)
        {
            TeamMember newTeamMember = new TeamMember(newTeammate, timeService);
            var returnVal = teamService.AddTeamMember(newTeamMember);

            broadcastService.NewTeamMemberAdded(newTeamMember.Name, newTeamMember.Id);

            return returnVal;
        }

        /// <summary>
        /// Post endpoint which adds a new team member.
        /// </summary>
        /// <param name="memberId">Unique identifier for the team member.</param>
        /// <param name="memberName">New name of the team member.</param>
        /// <returns>memberId on succes or -1 on if the member was not found.</returns>
        [HttpPost]
        public int UpdateTeamMember(int memberId, string memberName)
        {
            var returnVal = teamService.UpdateTeamMember(memberId, memberName);

            broadcastService.UpdatedTeamMember(memberId, memberName);

            return returnVal;
        }

        /// <summary>
        /// Get endpoint which returns the number of team members.
        /// </summary>
        /// <returns>Number of team members.</returns>
        [HttpGet]
        public int GetTeamCount()
        {
            return teamService.GetTeamInfo().TeamMembers.Count();
        }

        /// <summary>
        /// Deletes a memeber.
        /// </summary>
        /// <param name="id">MemberId that needs to be deleted.</param>
        [HttpDelete]
        public void DeleteTeamMember(int id)
        {
            this.teamService.DeleteTeamMember(id);
            broadcastService.TeamMemberDeleted(id);
        }

        /// <summary>
        /// Loads the Index page.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult which has the teamInfo member.</returns>
        public IActionResult Index()
        {
            return View(teamService.GetTeamInfo());
        }

        /// <summary>
        /// Loads the privacy page.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Loads an error page.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult which cotains error informations.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Creates the Chat view.
        /// </summary>
        /// <returns>Returns the chat view.</returns>
        public IActionResult Chat()
        {
            return View();
        }
    }
}
