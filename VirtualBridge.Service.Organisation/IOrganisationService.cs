// <copyright file="IOrganisationService.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Service.Organisation
{
    /// <summary>
    /// Organisation Service Layer.
    /// </summary>
    public interface IOrganisationService
    {
        /// <summary>
        /// Creates the organisation.
        /// </summary>
        /// <param name="who">Who Details.</param>
        /// <param name="auditEvent">Audit Event.</param>
        /// <param name="organisation">Organisation.</param>
        /// <returns>Nothing.</returns>
        Task CreateAsync(
            IWho who,
            EAuditEvent auditEvent,
            IOrganisation organisation);
    }
}