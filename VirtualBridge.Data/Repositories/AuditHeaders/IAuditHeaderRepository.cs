// <copyright file="IAuditHeaderRepository.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Repositories.AuditHeaders
{
    /// <summary>
    /// Audit Header Repository.
    /// </summary>
    public interface IAuditHeaderRepository
    {
        /// <summary>
        /// Creates the Audit Header with Audit Details.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header with Audit Details.</param>
        /// <returns>Nothing.</returns>
        public Task CreateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader);
    }
}