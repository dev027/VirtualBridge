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
        /// Gets or sets the Organisations.
        /// </summary>
        public DbSet<OrganisationDto> Organisations { get; set; } = null!;
    }
}