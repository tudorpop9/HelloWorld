// <copyright file="20210825091752_Birthdate.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloWorldWeb.Migrations
{
    /// <summary>
    /// Migration added after branch merge to create another column in TeamMember entity.
    /// </summary>
    public partial class Birthdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "TeamMembers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "TeamMembers");
        }
    }
}
