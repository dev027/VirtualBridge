// <copyright file="IOrganisationRepository.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Repositories.Organisations
{
    /// <summary>
    /// Organisation Repository.
    /// </summary>
    public interface IOrganisationRepository
    {
        #region Create

        /// <summary>
        /// Creates the Organisation.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header.</param>
        /// <param name="organisation">Organisation.</param>
        /// <returns>Nothing.</returns>
        Task CreateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IOrganisation organisation);

        #endregion Create

        #region Read

        /// <summary>
        /// Gets all organisations.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <returns>List of Organisations.</returns>
        Task<IList<IOrganisation>> GetAllAsync(IWho who);

        /// <summary>
        /// Gets the Organisation by Id.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="organisationId">Organisation Id.</param>
        /// <returns>Organisation (Null=Not Found).</returns>
        Task<IOrganisation> GetByIdAsync(
            IWho who,
            Guid organisationId);

        /// <summary>
        /// Checks if we have Organisations.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <returns>True if Organisations exist.</returns>
        Task<bool> HaveAsync(IWho who);

        #endregion Read

        #region Update

        /// <summary>
        /// Updates the Organisation.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header.</param>
        /// <param name="organisation">Organisation.</param>
        /// <returns>Nothing.</returns>
        Task UpdateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IOrganisation organisation);

        #endregion Update
    }
}