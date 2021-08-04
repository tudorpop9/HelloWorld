﻿// <copyright file="HomeController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
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
        private readonly TeamInfo teamInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// Home controller constructor.
        /// </summary>
        /// <param name="logger"> Necesary parameter for superclass.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
            this.teamInfo = new TeamInfo
            {
                Name = "Team1",
                TeamMembers = new List<string>(new string[] { "Fineas", "Patrick", "Radu", "Tudor", "Ema" }),
            };
        }

        /// <summary>
        /// Post endpoint which adds a new team member.
        /// </summary>
        /// <param name="newTeammate">Name of the new team member.</param>
        [HttpPost]
        public void AddTeamMember(string newTeammate)
        {
            teamInfo.TeamMembers.Add(newTeammate);
        }

        /// <summary>
        /// Get endpoint which returns the number of team members.
        /// </summary>
        /// <returns>Number of team members.</returns>
        [HttpGet]
        public int GetTeamCount()
        {
            return teamInfo.TeamMembers.Count();
        }

        /// <summary>
        /// Loads the Index page.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult which has the teamInfo member.</returns>
        public IActionResult Index()
        {
            return View(teamInfo);
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
    }
}