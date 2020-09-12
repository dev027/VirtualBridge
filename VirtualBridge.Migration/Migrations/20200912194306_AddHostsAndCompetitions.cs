// <copyright file="20200912194306_AddHostsAndCompetitions.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualBridge.Migration.Migrations
{
    /// <summary>
    /// Add tables Hosts and Competitions.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    public partial class AddHostsAndCompetitions : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.CreateTable(
                name: "AuditHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditEvent = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    CorrelationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    DayOfWeek = table.Column<string>(maxLength: 10, nullable: false),
                    TimeOfDay = table.Column<TimeSpan>(nullable: false),
                    TimePeriod = table.Column<string>(maxLength: 10, nullable: false),
                    OrganisationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    Surname = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditHeaderId = table.Column<Guid>(nullable: false),
                    TableName = table.Column<string>(nullable: false),
                    ColumnName = table.Column<string>(nullable: false),
                    RecordId = table.Column<Guid>(nullable: false),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    DatabaseAction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditDetails_AuditHeaders_AuditHeaderId",
                        column: x => x.AuditHeaderId,
                        principalTable: "AuditHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditDetails_AuditHeaderId",
                table: "AuditDetails",
                column: "AuditHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_OrganisationId",
                table: "Competitions",
                column: "OrganisationId");
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropTable(
                name: "AuditDetails");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "AuditHeaders");
        }
    }
}