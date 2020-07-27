// <copyright file="MigrationContext.DbSets.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using VirtualBridge.Data.Dtos;

namespace VirtualBridge.Migration.DbContexts
{
    /// <summary>
    /// Migration Context - DB Sets.
    /// </summary>
    /// <seealso cref="DbContext" />
    public partial class MigrationContext
    {
        /// <summary>
        /// Gets or sets the Organisations.
        /// </summary>
        public DbSet<OrganisationDto> Organisations { get; set; } = null!;
    }
}