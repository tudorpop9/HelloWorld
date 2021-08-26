// <copyright file="Startup.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HelloWorldWeb.Controllers;
using HelloWorldWeb.Data;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HelloWorldWeb
{
    /// <summary>
    /// Dummy comment.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// Dummy comment.
        /// </summary>
        /// <param name="configuration">Constructor parameter.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration property.
        /// Dummy comment.
        /// </summary>
        public IConfiguration Configuration { get; }

        public static string ConvertHerokuConnToAspNetConnString(string herokuConnectionString)
        {
            var databaseUri = new Uri(herokuConnectionString);

            // Username is on index 0 and password is on index 1
            string[] userInfo = databaseUri.UserInfo.Split(":");

            // "/dbName" => "dbName"
            string databaseName = databaseUri.AbsolutePath.TrimStart('/');

            return $"Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseName};User Id={userInfo[0]};Password={userInfo[1]};Pooling=true;SSL Mode=Require;TrustServerCertificate=True;Include Error Detail=True;";
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Metohd paramerter.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
            ObtainConnectionString()));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            /*services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();*/

            services.AddControllersWithViews();

            services.AddSingleton<IWeatherControllerSettings, WeatherControllerSettings>();
            services.AddSingleton<ITimeService>(new TimeService());

            services.AddSignalR();
            services.AddSingleton<IBroadcastService, BroadcastService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hello World API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
            services.AddScoped<ITeamService, DbTeamService>();

            AssignRoleProgramaticaly(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<MessageHub>("/messagehub");
                endpoints.MapRazorPages();
            });
        }

        private async void AssignRoleProgramaticaly(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByNameAsync("tudor.pop@principal33.com");
            await userManager.AddToRoleAsync(user, "Administrators");
        }

        // returns dbConnectionString from DATABASE_URL environment variable, or the PostgresHerokuConnection if the variable is not initialized
        private string ObtainConnectionString()
        {
            string envVarDbString = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (envVarDbString == null)
            {
               // return Configuration.GetConnectionString("PostgresHerokuConnection");
                return Configuration.GetConnectionString("DefaultConnection");
            }

            return ConvertHerokuConnToAspNetConnString(envVarDbString);
        }
    }
}
