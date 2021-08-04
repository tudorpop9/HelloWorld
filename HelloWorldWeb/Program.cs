// <copyright file="Program.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb
{
    /// <summary>
    /// A class that contains the main function.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method which starts the applicatin.
        /// </summary>
        /// <param name="args">Program argument list.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Web app host builder.
        /// </summary>
        /// <param name="args">Program argument list.</param>
        /// <returns>Returns an implementation of IHostBuilder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
