// <copyright file="DataContext.DbSets.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using VirtualBridge.Data.Dtos;

namespace VirtualBridge.Data.DbContexts
{
    /// <summary>
    /// Database Context - DB Sets.
    /// </summary>
    /// <seealso cref="DbContext" />
    public partial class DataContext
    {
        /// <summary>
        /// Gets or sets the Audit Headers.
        /// </summary>
        public DbSet<AuditHeaderDto> AuditHeaders { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Audit Details.
        /// </summary>
        public DbSet<AuditDetailDto> AuditDetails { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Competitions.
        /// </summary>
        public DbSet<CompetitionDto> Competitions { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Hosts.
        /// </summary>
        public DbSet<HostDto> Hosts { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Organisations.
        /// </summary>
        public DbSet<OrganisationDto> Organisations { get; set; } = null!;
    }
}