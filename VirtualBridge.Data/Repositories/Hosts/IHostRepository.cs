// <copyright file="IHostRepository.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Hosts;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Repositories.Hosts
{
    /// <summary>
    /// Host Repository.
    /// </summary>
    public interface IHostRepository
    {
        #region Create

        /// <summary>
        /// Creates the Host.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header.</param>
        /// <param name="host">Host.</param>
        /// <returns>Nothing.</returns>
        Task CreateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IHost host);

        #endregion Create

        #region Read

        /// <summary>
        /// Gets all hosts.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <returns>List of Hosts.</returns>
        Task<IList<IHost>> GetAllAsync(IWho who);

        /// <summary>
        /// Gets the Host by Id.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="hostId">Host Id.</param>
        /// <returns>Host (Null=Not Found).</returns>
        Task<IHost> GetByIdAsync(
            IWho who,
            Guid hostId);

        /// <summary>
        /// Checks if we have Hosts.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <returns>True if Host exist.</returns>
        Task<bool> HaveAsync(IWho who);

        #endregion Read

        #region Update

        /// <summary>
        /// Updates the Host.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header.</param>
        /// <param name="host">Host.</param>
        /// <returns>Nothing.</returns>
        Task UpdateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IHost host);

        #endregion Update
    }
}