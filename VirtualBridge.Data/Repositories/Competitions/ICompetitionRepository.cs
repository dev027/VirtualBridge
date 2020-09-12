// <copyright file="ICompetitionRepository.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Competitions;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Repositories.Competitions
{
    /// <summary>
    /// Competition Repository.
    /// </summary>
    public interface ICompetitionRepository
    {
        #region Create

        /// <summary>
        /// Creates the Competition.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header.</param>
        /// <param name="competition">Competition.</param>
        /// <returns>Nothing.</returns>
        Task CreateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            ICompetition competition);

        #endregion Create

        #region Read

        /// <summary>
        /// Gets all competitions.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <returns>List of Competitions.</returns>
        Task<IList<ICompetition>> GetAllAsync(IWho who);

        /// <summary>
        /// Gets the Competition by Id.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="competitionId">Competition Id.</param>
        /// <returns>Competition (Null=Not Found).</returns>
        Task<ICompetition> GetByIdAsync(
            IWho who,
            Guid competitionId);

        /// <summary>
        /// Checks if we have Competitions.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <returns>True if Competition exist.</returns>
        Task<bool> HaveAsync(IWho who);

        #endregion Read

        #region Update

        /// <summary>
        /// Updates the Competition.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header.</param>
        /// <param name="competition">Competition.</param>
        /// <returns>Nothing.</returns>
        Task UpdateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            ICompetition competition);

        #endregion Update
    }
}