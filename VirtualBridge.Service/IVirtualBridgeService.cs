// <copyright file="IVirtualBridgeService.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Service
{
    /// <summary>
    /// Virtual Bridge Service.
    /// </summary>
    public interface IVirtualBridgeService
    {
        #region Organisation

        #region Create

        /// <summary>
        /// Creates the organisation.
        /// </summary>
        /// <param name="who">Who Details.</param>
        /// <param name="auditEvent">Audit Event.</param>
        /// <param name="organisation">Organisation.</param>
        /// <returns>Nothing.</returns>
        Task CreateOrganisationAsync(
            IWho who,
            EAuditEvent auditEvent,
            IOrganisation organisation);

        #endregion Create

        #endregion Organisation
    }
}